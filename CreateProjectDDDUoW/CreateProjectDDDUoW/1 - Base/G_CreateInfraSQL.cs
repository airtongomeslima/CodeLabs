using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW.Models;
using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class G_CreateInfraSQL
    {
        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "";
        protected string _enderecoProjeto = "";
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        public G_CreateInfraSQL(string nomeSolucao, string enderecoRaiz, List<Contexto> contextos)
        {
            _nomeProjeto = $"{nomeSolucao}.Infra.SQL";
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

            arquivo.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            arquivo.AppendLine("<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\" ToolsVersion=\"4.0\">");
            arquivo.AppendLine("<Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />", 1);
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>", 2);
            arquivo.AppendLine("<Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>", 2);
            arquivo.AppendLine($"<Name>{_nomeProjeto}</Name>", 2);
            arquivo.AppendLine("<SchemaVersion>2.0</SchemaVersion>", 2);
            arquivo.AppendLine("<ProjectVersion>4.1</ProjectVersion>", 2);
            arquivo.AppendLine("<ProjectGuid>{48f264fc-ae9e-4f8e-883a-c665e4492679}</ProjectGuid>", 2);
            arquivo.AppendLine("<DSP>Microsoft.Data.Tools.Schema.Sql.Sql130DatabaseSchemaProvider</DSP>", 2);
            arquivo.AppendLine("<OutputType>Database</OutputType>", 2);
            arquivo.AppendLine("<RootPath>", 2);
            arquivo.AppendLine("</RootPath>", 2);
            arquivo.AppendLine($"<RootNamespace>{_nomeProjeto}</RootNamespace>", 2);
            arquivo.AppendLine($"<AssemblyName>{_nomeProjeto}</AssemblyName>", 2);
            arquivo.AppendLine("<ModelCollation>1033, CI</ModelCollation>", 2);
            arquivo.AppendLine("<DefaultFileStructure>BySchemaAndSchemaType</DefaultFileStructure>", 2);
            arquivo.AppendLine("<DeployToDatabase>True</DeployToDatabase>", 2);
            arquivo.AppendLine("<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>", 2);
            arquivo.AppendLine("<TargetLanguage>CS</TargetLanguage>", 2);
            arquivo.AppendLine("<AppDesignerFolder>Properties</AppDesignerFolder>", 2);
            arquivo.AppendLine("<SqlServerVerification>False</SqlServerVerification>", 2);
            arquivo.AppendLine("<IncludeCompositeObjects>True</IncludeCompositeObjects>", 2);
            arquivo.AppendLine("<TargetDatabaseSet>True</TargetDatabaseSet>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("<PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">", 1);
            arquivo.AppendLine("<OutputPath>bin\\Release\\</OutputPath>", 2);
            arquivo.AppendLine("<BuildScriptName>$(MSBuildProjectName).sql</BuildScriptName>", 2);
            arquivo.AppendLine("<TreatWarningsAsErrors>False</TreatWarningsAsErrors>", 2);
            arquivo.AppendLine("<DebugType>pdbonly</DebugType>", 2);
            arquivo.AppendLine("<Optimize>true</Optimize>", 2);
            arquivo.AppendLine("<DefineDebug>false</DefineDebug>", 2);
            arquivo.AppendLine("<DefineTrace>true</DefineTrace>", 2);
            arquivo.AppendLine("<ErrorReport>prompt</ErrorReport>", 2);
            arquivo.AppendLine("<WarningLevel>4</WarningLevel>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("<PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">", 1);
            arquivo.AppendLine("<OutputPath>bin\\Debug\\</OutputPath>", 2);
            arquivo.AppendLine("<BuildScriptName>$(MSBuildProjectName).sql</BuildScriptName>", 2);
            arquivo.AppendLine("<TreatWarningsAsErrors>false</TreatWarningsAsErrors>", 2);
            arquivo.AppendLine("<DebugSymbols>true</DebugSymbols>", 2);
            arquivo.AppendLine("<DebugType>full</DebugType>", 2);
            arquivo.AppendLine("<Optimize>false</Optimize>", 2);
            arquivo.AppendLine("<DefineDebug>true</DefineDebug>", 2);
            arquivo.AppendLine("<DefineTrace>true</DefineTrace>", 2);
            arquivo.AppendLine("<ErrorReport>prompt</ErrorReport>", 2);
            arquivo.AppendLine("<WarningLevel>4</WarningLevel>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<VisualStudioVersion Condition=\"'$(VisualStudioVersion)' == ''\">11.0</VisualStudioVersion>", 2);
            arquivo.AppendLine("<!-- Default to the v11.0 targets path if the targets file for the current VS version is not found -->", 2);
            arquivo.AppendLine("<SSDTExists Condition=\"Exists('$(MSBuildExtensionsPath)\\Microsoft\\VisualStudio\v$(VisualStudioVersion)\\SSDT\\Microsoft.Data.Tools.Schema.SqlTasks.targets')\">True</SSDTExists>", 2);
            arquivo.AppendLine("<VisualStudioVersion Condition=\"'$(SSDTExists)' == ''\">11.0</VisualStudioVersion>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("<Import Condition=\"'$(SQLDBExtensionsRefPath)' != ''\" Project=\"$(SQLDBExtensionsRefPath)\\Microsoft.Data.Tools'.Schema.SqlTasks.targets\" />", 1);
            arquivo.AppendLine("<Import Condition=\"'$(SQLDBExtensionsRefPath)' == ''\" Project=\"$(MSBuildExtensionsPath)\\Microsoft\\VisualStudio\v$(VisualStudioVersion)\\SSDT\\Microsoft.Data.Tools.Schema.SqlTasks.targets\" />", 1);
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<Folder Include=\"Properties\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<Build Include=\"Cliente.sql\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<None Include=\"Readme.txt\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("</Project>");

            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }
        
    }
}
