using CreateProjectDDDUoW._0___Core;
using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class H_CreateDTOProject
    {
        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "";
        protected string _enderecoProjeto = "";
        protected string _connectionString = "";
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        public H_CreateDTOProject(string nomeSolucao, string connectionstring, string enderecoRaiz, List<string> repositorios)
        {
            _connectionString = connectionstring;
            _nomeProjeto = $"{nomeSolucao}.DTO";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _baseSolution = nomeSolucao;

            CreateProject();


            foreach (var item in arquivos)
            {
                string arquivo = $"{_enderecoProjeto}\\{item.Key}";
                if (File.Exists(arquivo))
                {
                    File.Delete(arquivo);
                }

                File.WriteAllText(arquivo, item.Value.ToString());
            }
        }

        public void CreateProject()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup Label=\"Globals\">", 1);
            arquivo.AppendLine("<SccProjectName>SAK</SccProjectName>", 2);
            arquivo.AppendLine("<SccProvider>SAK</SccProvider>", 2);
            arquivo.AppendLine("<SccAuxPath>SAK</SccAuxPath>", 2);
            arquivo.AppendLine("<SccLocalPath>SAK</SccLocalPath>", 2);
            arquivo.AppendLine("<PackageId>ModeloDDD.DTO</PackageId>", 2);
            arquivo.AppendLine("<PackageVersion>1.0.0</PackageVersion>", 2);
            arquivo.AppendLine("<Authors></Authors>", 2);
            arquivo.AppendLine("<Description>Data Transfer Objects</Description>", 2);
            arquivo.AppendLine("<PackageRequireLicenseAcceptance>false</PackageRequireLicenseAcceptance>", 2);
            arquivo.AppendLine("<PackageReleaseNotes>First release</PackageReleaseNotes>", 2);
            arquivo.AppendLine("<Copyright>Copyright 2017 (c)</Copyright>", 2);
            arquivo.AppendLine("<PackageTags>DTO</PackageTags>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<TargetFramework>netstandard1.0</TargetFramework>", 2);
            arquivo.AppendLine("<GeneratePackageOnBuild>true</GeneratePackageOnBuild>", 2);
            arquivo.AppendLine("<NeutralLanguage>pt-BR</NeutralLanguage>", 2);
            arquivo.AppendLine("<PackageIconUrl></PackageIconUrl>", 2);
            arquivo.AppendLine("<PackageProjectUrl></PackageProjectUrl>", 2);
            arquivo.AppendLine("<Company />", 2);
            arquivo.AppendLine("<Version>1.0.0</Version>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");


            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }
        
    }
}
