using CustomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW.Models;

namespace CreateProjectDDDUoW._1___Base
{
    public class A_CreateSolution
    {
        private StringBuilder _sLN = new StringBuilder();
        protected Dictionary<string,string> _pastas = new Dictionary<string, string>();
        protected Dictionary<string,string> _projetos = new Dictionary<string, string>();
        protected Dictionary<string, string> _sQLProjetos = new Dictionary<string, string>();

        protected Guid guidPasta = Extension.GetEnumGuid(TiposdeProjetos.Solution_Folder);
        protected Guid guidClass = Extension.GetEnumGuid(TiposdeProjetos.Core_Class_Library);
        protected Guid guidSQL = Extension.GetEnumGuid(TiposdeProjetos.SQL);

        protected string _nomeSolution = "Teste";
        protected string _enderecoProjeto = "";
        //VS 2015 12.0
        public string _formatVersion = "12.00";
        //VS 2015 14
        public string _vSVersion = "15";
        //VS 2015 14.0.22310.1
        public string _vSFullVersion = "15.0.26730.16";
        //VS 2015 10.0.40219.1
        public string _minimumVisualStudioVersion = "10.0.40219.1";

        public A_CreateSolution(string localToCreate, string nomeSolution)
        {
            _nomeSolution = nomeSolution;

            string diretorio = $"{localToCreate}/{_nomeSolution}";
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            _enderecoProjeto = diretorio;


            AddHeader();
            AddFolders();
            AddProjects();
            AddGlobalConfigs();

            string arquivo = $"{diretorio}/{_nomeSolution}.sln";
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }

            File.WriteAllText(arquivo, _sLN.ToString());
        }

        private void AddHeader()
        {
            _sLN.AppendLine($"Microsoft Visual Studio Solution File, Format Version {_formatVersion}");
            _sLN.AppendLine($"# Visual Studio {_vSVersion}");
            _sLN.AppendLine($"VisualStudioVersion = {_vSFullVersion}");
            _sLN.AppendLine($"MinimumVisualStudioVersion = {_minimumVisualStudioVersion}");
        }

        private string CriarLinhaFolder(string guidTipo, string nome, string local, string guid)
        {
            if (guidTipo == guidPasta.ToString())
            {
                _pastas.Add(nome, guid);
                //CriarPasta(nome);
            }

            if (guidTipo == guidClass.ToString())
            {
                _projetos.Add(nome, guid);
            }

            if (guidTipo == guidSQL.ToString())
            {
                _sQLProjetos.Add(nome, guid);
            }

            return ($"Project(\"{{{guidTipo}}}\") = \"{nome}\", \"{local}\", \"{{{guid}}}\"\r\nEndProject");
        }

        private void CriarPasta(string nome)
        {
            string enderecoPasta = $"{_enderecoProjeto}/{nome}";
            if (Directory.Exists(enderecoPasta))
            {
                Directory.Delete(enderecoPasta, true);
            }

            Directory.CreateDirectory(enderecoPasta);
        }

        private void AddFolders()
        {
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "1 - Testes", "1 - Testes", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "2 - Servicos", "2 - Servicos", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "3 - Aplicacao", "3 - Aplicacao", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "4 - Dominio", "4 - Dominio", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "5 - Infra", "5 - Infra", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "5.1 - CrossCutting", "5.1 - CrossCutting", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "5.2 - Dados", "5.2 - Dados", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidPasta.ToString(), "6 - DTO", "6 - DTO", Guid.NewGuid().ToString()));
        }

        private void AddProjects()
        {
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.Test", $"{_nomeSolution}.Test\\{_nomeSolution}.Test.csproj", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.Servicos.API", $"{_nomeSolution}.Servicos.API\\{_nomeSolution}.Servicos.API.csproj", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.Aplicacao", $"{_nomeSolution}.Aplicacao\\{_nomeSolution}.Aplicacao.csproj", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.Dominio", $"{_nomeSolution}.Dominio\\{_nomeSolution}.Dominio.csproj", Guid.NewGuid().ToString()));
            //_sLN.AppendLine(CriarLinhaFolder(guidSQL.ToString(), $"{_nomeSolution}.Infra.SQL", $"{_nomeSolution}.Infra.SQL\\{_nomeSolution}.Infra.SQL.sqlproj", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.Infra.Dados", $"{_nomeSolution}.Infra.Dados\\{_nomeSolution}.Infra.Dados.csproj", Guid.NewGuid().ToString()));
            _sLN.AppendLine(CriarLinhaFolder(guidClass.ToString(), $"{_nomeSolution}.DTO", $"{_nomeSolution}.DTO\\{_nomeSolution}.DTO.csproj", Guid.NewGuid().ToString()));
        }

        private void AddGlobalConfigs()
        {
            _sLN.AppendLine("Global");
            _sLN.AppendLine("GlobalSection(SolutionConfigurationPlatforms) = preSolution", 1);
            _sLN.AppendLine("Debug|Any CPU = Debug|Any CPU", 2);
            _sLN.AppendLine("Release|Any CPU = Release|Any CPU", 2);
            _sLN.AppendLine("EndGlobalSection", 1);
            _sLN.AppendLine("GlobalSection(ProjectConfigurationPlatforms) = postSolution", 1);

            foreach (var p in _projetos)
            {
                _sLN.AppendLine($"{{{p.Key}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            }

            foreach (var p in _sQLProjetos)
            {
                _sLN.AppendLine($"{{{p.Key}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
                _sLN.AppendLine($"{{{p.Key}}}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            }

            _sLN.AppendLine("EndGlobalSection", 1);
            _sLN.AppendLine("GlobalSection(SolutionProperties) = preSolution", 1);
            _sLN.AppendLine("HideSolutionNode = FALSE", 2);
            _sLN.AppendLine("EndGlobalSection", 1);


            _sLN.AppendLine("GlobalSection(NestedProjects) = preSolution", 1);


            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.Test"]}}} = {{{_pastas["1 - Testes"]}}}", 2);
            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.Servicos.API"]}}} = {{{_pastas["2 - Servicos"]}}}", 2);
            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.Aplicacao"]}}} = {{{_pastas["3 - Aplicacao"]}}}", 2);
            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.Dominio"]}}} = {{{_pastas["4 - Dominio"]}}}", 2);
            _sLN.AppendLine($"{{{_pastas["5.1 - CrossCutting"]}}} = {{{_pastas["5 - Infra"]}}}", 2);
            _sLN.AppendLine($"{{{_pastas["5.2 - Dados"]}}} = {{{_pastas["5 - Infra"]}}}", 2);
            //_sLN.AppendLine($"{{{_sQLProjetos[$"{_nomeSolution}.Infra.SQL"]}}} = {{{_pastas["5.2 - Dados"]}}}", 2);
            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.Infra.Dados"]}}} = {{{_pastas["5.2 - Dados"]}}}", 2);
            _sLN.AppendLine($"{{{_projetos[$"{_nomeSolution}.DTO"]}}} = {{{_pastas["6 - DTO"]}}}", 2);


            _sLN.AppendLine("EndGlobalSection", 2);
            _sLN.AppendLine("EndGlobal");
        }
    }
}
