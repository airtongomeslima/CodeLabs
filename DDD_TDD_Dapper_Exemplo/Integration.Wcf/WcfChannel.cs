using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace API.Integration.Wcf
{
    public static class WcfChannel
    {

        static EndpointAddress _endpointAddress;
        /// <summary>
        /// Retorna ChannelFactory do contrato
        /// </summary>
        /// <typeparam name="T">Interface do contrato WCF</typeparam>
        /// <param name="endpointAddress">Endereço do Endpoint</param>
        public static T CreateChannel<T>(string endpointAddress, WcfBinding wcfBinding)
        {
            Binding binding = null;

            #region ReaderQuotas
            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas()
            {
                MaxDepth = int.MaxValue,
                MaxStringContentLength = int.MaxValue,
                MaxArrayLength = int.MaxValue,
                MaxBytesPerRead = int.MaxValue,
                MaxNameTableCharCount = int.MaxValue
            };
            #endregion

            switch (wcfBinding)
            {
                case WcfBinding.BasicHttpBinding:
                case WcfBinding.NetMsmqBinding:
                case WcfBinding.NetNamedPipeBinding:
                    throw new NotImplementedException();

                case WcfBinding.NetTcpBinding:
                    binding = new NetTcpBinding()
                    {
                        Name = "NetTcpBinding",
                        MaxBufferPoolSize = long.MaxValue,
                        MaxBufferSize = int.MaxValue,
                        MaxReceivedMessageSize = int.MaxValue,
                        ReaderQuotas = readerQuotas,
                        Security = new NetTcpSecurity() { Mode = SecurityMode.None },
                        CloseTimeout = new TimeSpan(0, 5, 0),
                        OpenTimeout = new TimeSpan(0, 5, 0),
                        ReceiveTimeout = new TimeSpan(0, 5, 0),
                        SendTimeout = new TimeSpan(0, 5, 0)
                    };
                    break;

                case WcfBinding.NetTcpBindingStreamed:
                    binding = new NetTcpBinding()
                    {
                        Name = "NetTcpBindingStreamed",
                        TransferMode = TransferMode.Streamed,
                        MaxBufferPoolSize = long.MaxValue,
                        MaxBufferSize = int.MaxValue,
                        MaxReceivedMessageSize = int.MaxValue,
                        ReaderQuotas = readerQuotas,
                        Security = new NetTcpSecurity() { Mode = SecurityMode.None },
                        CloseTimeout = new TimeSpan(0, 5, 0),
                        OpenTimeout = new TimeSpan(0, 5, 0),
                        ReceiveTimeout = new TimeSpan(0, 5, 0),
                        SendTimeout = new TimeSpan(0, 5, 0)
                    };
                    break;
                case WcfBinding.WS2007HttpBinding:
                case WcfBinding.WSHttpBinding:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }

            _endpointAddress = new EndpointAddress(endpointAddress);

            var channelFactory = new ChannelFactory<T>(binding, _endpointAddress);

            var inspector = new CustomInspectorBehavior();

            channelFactory.Endpoint.EndpointBehaviors.Add(inspector);

            T channelObj = channelFactory.CreateChannel();

            return channelObj;
        }

        public static void CloseChannel(this object obj)
        {
            try
            {
                (obj as IClientChannel).Close();
            }
            catch (Exception)
            {
                (obj as IClientChannel).Abort();
            }

            (obj as IDisposable).Dispose();

            obj = null;
        }

        public enum WcfBinding
        {
            BasicHttpBinding,
            NetMsmqBinding,
            NetNamedPipeBinding,
            NetTcpBinding,
            NetTcpBindingStreamed,
            WS2007HttpBinding,
            WSHttpBinding
        }
    }

    public class CustomMessageInspector : IClientMessageInspector
    {
        public String Data { get; set; }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            var result = reply.ToString();

            Console.WriteLine(result);
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            this.Data = request.ToString();
            return null;
        }
    }

    public class CustomInspectorBehavior : IEndpointBehavior
    {
        private CustomMessageInspector custom = new CustomMessageInspector();

        public String Data { get { return this.custom.Data; } }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(custom);
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }
    }
}

