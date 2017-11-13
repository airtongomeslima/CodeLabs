using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModeloDDD.Servicos.API.Helpers
{
    /// <summary>
    /// Code by Rafael Nicoleti
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResult<T> : IEquatable<HttpResult<T>>
    {
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Answer;
                hashCode = (hashCode * 397) ^ (Data != null ? Data.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Model);
                hashCode = (hashCode * 397) ^ (Errors != null ? Errors.GetHashCode() : 0);
                return hashCode;
            }
        }

        public HttpStatusCode Answer { get; set; }
        public IEnumerable<T> Data { get; set; }
        public T Model { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public HttpResponseMessage Success(T model)
        {
            Answer = HttpStatusCode.OK;
            Model = model;
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        public HttpResponseMessage Success(object data)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Success(IEnumerable<T> data)
        {
            Answer = HttpStatusCode.OK;

            if (data != null)
                Data = data;
            else
                Data = new List<T>();

            TotalItems = data.Count();

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };

            return responseMessage;
        }

        public HttpResponseMessage Success()
        {
            Answer = HttpStatusCode.OK;
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        public HttpResponseMessage Error(IList<ValidationResult> errors)
        {
            Answer = HttpStatusCode.InternalServerError;
            Errors = errors.Select(_ => _.ErrorMessage);

            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        public HttpResponseMessage Error(string error)
        {
            Answer = HttpStatusCode.InternalServerError;
            Errors = new List<string> { error };
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        private HttpResponseMessage BadRequest(string error)
        {
            Answer = HttpStatusCode.BadRequest;
            Errors = new List<string> { error };
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        private HttpResponseMessage NotFound(string error)
        {
            Answer = HttpStatusCode.NotFound;
            Errors = new List<string> { error };
            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        private HttpResponseMessage AlreadyExists(string error)
        {
            Answer = HttpStatusCode.Conflict;
            Errors = new List<string> { error };
            var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        private HttpResponseMessage NotAuthorized(string error)
        {
            Answer = HttpStatusCode.Unauthorized;
            Errors = new List<string> { error };
            var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
            return responseMessage;
        }

        public HttpResponseMessage ReturnCustomException(Exception ex)
        {
            return Error($"{ex.Message}");
        }

        public bool Equals(HttpResult<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Answer == other.Answer && Equals(Data, other.Data) && EqualityComparer<T>.Default.Equals(Model, other.Model) && Equals(Errors, other.Errors);
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((HttpResult<T>)obj);
        }
    }
}
