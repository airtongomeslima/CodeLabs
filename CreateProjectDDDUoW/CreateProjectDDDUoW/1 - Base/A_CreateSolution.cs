using CustomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreateProjectDDDUoW._1___Base
{
    public class A_CreateSolution
    {
        private StringBuilder SLN = new StringBuilder();
        public string FormatVersion = "12.0";
        public string VSVersion = "14";
        public string VSFullVersion = "14.0.22310.1";
        public string MinimumVisualStudioVersion = "10.0.40219.1";

        public A_CreateSolution(string LocalToCreate, string NomeSolution)
        {
            AddHeader();
            AddFolders();
            AddProjects();
            AddGlobalConfigs();

            string diretorio = $"{LocalToCreate}/{NomeSolution}";
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            string arquivo = $"{diretorio}/{NomeSolution}.sln";
            if (!File.Exists(arquivo))
            {
                //using (FileStream file = File.Create(arquivo))
                //{
                    File.WriteAllText(arquivo, SLN.ToString());
                //}
            }
            else
            {
                throw new Exception("Uma solution com este nome já existe no local selecionado.");
            }
        }

        private void AddHeader()
        {
            SLN.AppendLine($"Microsoft Visual Studio Solution File, Format Version {FormatVersion}");
            SLN.AppendLine($"# Visual Studio {VSVersion}");
            SLN.AppendLine($"VisualStudioVersion = {VSFullVersion}");
            SLN.AppendLine($"MinimumVisualStudioVersion = {MinimumVisualStudioVersion}");
        }

        private void AddFolders()
        {
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"0-Modeling and Design\", \"0-Modeling and Design\", \"{2B50C8C2-375A-42EA-A27F-1F61E5558351}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1-Layerss\", \"1-Layerss\", \"{C61707EA-6922-4543-8B04-FE4FEB467B99}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.1-Presentation\", \"1.1-Presentation\", \"{10F12706-7FED-45F8-AC60-D222C8E64494}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.2-Distributed Services\", \"1.2-Distributed Services\", \"{5E73ADC5-35FC-476E-81D1-F09FB6A307E8}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.3-Application\", \"1.3-Application\", \"{3DFE510B-2EBD-46A3-BA1A-62CD28E6427D}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.4-Domain\", \"1.4-Domain\", \"{5248E87F-EB51-4E16-9CE3-9F46F214054F}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5-Infrastructure\", \"1.5-Infrastructure\", \"{34934E1B-4B3C-4D85-A190-EA4E81B39746}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.1 Data\", \"1.5.1 Data\", \"{0CD72A40-B22F-4609-A7C9-95C82EC6F6D2}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.2 Cross Cutting\", \"1.5.2 Cross Cutting\", \"{E00E48EE-3D7E-41C7-94A6-09581A6D0BA1}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.2.1-Core\", \"1.5.2.1-Core\", \"{1E0B0AB0-45B5-400C-A6CA-5178D89BC073}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.2.2-BoundedContext\", \"1.5.2.2-BoundedContext\", \"{28416AB3-34AC-4DEE-BC8D-73877D9CB8AC}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.1.1-Core\", \"1.5.1.1-Core\", \"{5806D0C7-9543-40B4-85FE-86C174D16B42}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.5.1.2-BoundedContext\", \"1.5.1.2-BoundedContext\", \"{EB1C385A-F3F7-4789-97E0-1D4C2FBEA323}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.4.1-Core\", \"1.4.1-Core\", \"{0E75C193-3E2C-46B5-BD22-B16173689804}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.4.2-BoundedContext\", \"1.4.2-BoundedContext\", \"{9D397C15-304C-44ED-BE7B-F88E8DD78BF9}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.3.1-Core\", \"1.3.1-Core\", \"{F0334DDB-ADC4-4CC5-99C7-419A92DE9E32}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.3.2-BoundedContext\", \"1.3.2-BoundedContext\", \"{1A3CE60C-5FC6-4FCE-A327-89C2049F11B1}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.2.1-Core\", \"1.2.1-Core\", \"{21E5B6B4-FE9B-481E-8751-1A9BD1F3336B}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.2.2-BoundedContext\", \"1.2.2-BoundedContext\", \"{49EFF498-9487-489E-B502-4647D2ED3FBC}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.1.1-Web\", \"1.1.1-Web\", \"{376480D5-8D1F-4067-8CB1-C6A317A23BD9}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.1.2-Phone\", \"1.1.2-Phone\", \"{E70948C0-EFD6-4DEE-8C05-0660DE52CE73}\"");
            SLN.AppendLine("EndProject");
            SLN.AppendLine("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"1.1.3-Windows\", \"1.1.3-Windows\", \"{7A560683-3254-42A4-8B94-730D3761DABE}\"");
            SLN.AppendLine("EndProject");
        }

        private void AddProjects()
        {
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.CrossCutting.IoC\", \"Infrastructure.CrossCutting.IoC\\Infrastructure.CrossCutting.IoC.csproj\", \"{{394E94AE-29C8-48A7-8D54-DA80A5A43059}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.CrossCutting.NetFramework\", \"Infrastructure.CrossCutting.NetFramework\\Infrastructure.CrossCutting.NetFramework.csproj\", \"{{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.CrossCutting.SeedWork\", \"Infrastructure.CrossCutting.SeedWork\\Infrastructure.CrossCutting.SeedWork.csproj\", \"{{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.Data.BoundedContext\", \"Infrastructure.Data.BoundedContext\\Infrastructure.Data.BoundedContext.csproj\", \"{{3119482A-BFDC-4386-ACA0-189FFCFF855E}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.Data.Core\", \"Infrastructure.Data.Core\\Infrastructure.Data.Core.csproj\", \"{{B048D9BD-B503-47D9-8E05-9F01521AE8E8}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Domain.BoundedContext\", \"Domain.BoundedContext\\Domain.BoundedContext.csproj\", \"{{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Domain.Core.Tests\", \"Domain.Core.Tests\\Domain.Core.Tests.csproj\", \"{{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Domain.Core\", \"Domain.Core\\Domain.Core.csproj\", \"{{9F48320A-20E5-467D-A7DE-BBDAD7755692}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.Data.BoundedContext.Test\", \"Infrastructure.Data.BoundedContext.Test\\Infrastructure.Data.BoundedContext.Test.csproj\", \"{{8418BBCB-8952-4864-9092-9D2493D3DC66}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Infrastructure.CrossCutting.Test\", \"Infrastructure.CrossCutting.Test\\Infrastructure.CrossCutting.Test.csproj\", \"{{6654E672-4764-44C6-B2A0-6570FF5EC820}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Application.BoundedContext\", \"Application.BoundedContext\\Application.BoundedContext.csproj\", \"{{333D9451-7533-4E39-A512-C3CC6F1AFC44}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Application.BoundedContext.Tests\", \"Application.BoundedContext.Tests\\Application.BoundedContext.Tests.csproj\", \"{{B707729C-E441-4946-8D78-7C8BBB89AFE6}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"Application.Core\", \"Application.Core\\Application.Core.csproj\", \"{{CEEE0E39-E857-48E9-9008-732A8F7AEB4A}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{2150E333-8FDC-42A3-9474-1A3956D46DE8}}\") = \"1.1.1.1-ASPMVC5\", \"1.1.1.1-ASPMVC5\", \"{{DA4C8FBE-B5D5-46FB-938D-C57078489E1F}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"ASP.NET.MVC5.Client\", \"ASP.NET.MVC5.Client\\ASP.NET.MVC5.Client.csproj\", \"{{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"ASP.NET.MVC5.Client.Tests\", \"ASP.NET.MVC5.Client.Tests\\ASP.NET.MVC5.Client.Tests.csproj\", \"{{8A0549F8-E565-4413-AC10-915BFB88F025}}\"");
            SLN.AppendLine($"EndProject");
            SLN.AppendLine($"Project(\"{{F088123C-0E9E-452A-89E6-6BA2F21D5CAC}}\") = \"PolyGlotPersitence.Modeling\", \"PolyGlotPersitence.Modeling\\PolyGlotPersitence.Modeling.modelproj\", \"{{9DFC44FF-6713-4243-9BE5-5B6EAEC13178}}\"");
            SLN.AppendLine($"EndProject");
        }

        private void AddGlobalConfigs()
        {
            SLN.AppendLine("Global");
            SLN.AppendLine("GlobalSection(SolutionConfigurationPlatforms) = preSolution", 1);
            SLN.AppendLine("Debug|Any CPU = Debug|Any CPU", 2);
            SLN.AppendLine("Release|Any CPU = Release|Any CPU", 2);
            SLN.AppendLine("EndGlobalSection", 1);
            SLN.AppendLine("GlobalSection(ProjectConfigurationPlatforms) = postSolution", 1);
            SLN.AppendLine("{394E94AE-29C8-48A7-8D54-DA80A5A43059}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{394E94AE-29C8-48A7-8D54-DA80A5A43059}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{394E94AE-29C8-48A7-8D54-DA80A5A43059}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{394E94AE-29C8-48A7-8D54-DA80A5A43059}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{3119482A-BFDC-4386-ACA0-189FFCFF855E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{3119482A-BFDC-4386-ACA0-189FFCFF855E}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{3119482A-BFDC-4386-ACA0-189FFCFF855E}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{3119482A-BFDC-4386-ACA0-189FFCFF855E}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{B048D9BD-B503-47D9-8E05-9F01521AE8E8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{B048D9BD-B503-47D9-8E05-9F01521AE8E8}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{B048D9BD-B503-47D9-8E05-9F01521AE8E8}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{B048D9BD-B503-47D9-8E05-9F01521AE8E8}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{9F48320A-20E5-467D-A7DE-BBDAD7755692}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{9F48320A-20E5-467D-A7DE-BBDAD7755692}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{9F48320A-20E5-467D-A7DE-BBDAD7755692}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{9F48320A-20E5-467D-A7DE-BBDAD7755692}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{8418BBCB-8952-4864-9092-9D2493D3DC66}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{8418BBCB-8952-4864-9092-9D2493D3DC66}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{8418BBCB-8952-4864-9092-9D2493D3DC66}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{8418BBCB-8952-4864-9092-9D2493D3DC66}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{6654E672-4764-44C6-B2A0-6570FF5EC820}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{6654E672-4764-44C6-B2A0-6570FF5EC820}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{6654E672-4764-44C6-B2A0-6570FF5EC820}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{6654E672-4764-44C6-B2A0-6570FF5EC820}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{333D9451-7533-4E39-A512-C3CC6F1AFC44}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{333D9451-7533-4E39-A512-C3CC6F1AFC44}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{333D9451-7533-4E39-A512-C3CC6F1AFC44}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{333D9451-7533-4E39-A512-C3CC6F1AFC44}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{B707729C-E441-4946-8D78-7C8BBB89AFE6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{B707729C-E441-4946-8D78-7C8BBB89AFE6}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{B707729C-E441-4946-8D78-7C8BBB89AFE6}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{B707729C-E441-4946-8D78-7C8BBB89AFE6}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{CEEE0E39-E857-48E9-9008-732A8F7AEB4A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{CEEE0E39-E857-48E9-9008-732A8F7AEB4A}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{CEEE0E39-E857-48E9-9008-732A8F7AEB4A}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{CEEE0E39-E857-48E9-9008-732A8F7AEB4A}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{8A0549F8-E565-4413-AC10-915BFB88F025}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{8A0549F8-E565-4413-AC10-915BFB88F025}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{8A0549F8-E565-4413-AC10-915BFB88F025}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{8A0549F8-E565-4413-AC10-915BFB88F025}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("{9DFC44FF-6713-4243-9BE5-5B6EAEC13178}.Debug|Any CPU.ActiveCfg = Debug|Any CPU", 2);
            SLN.AppendLine("{9DFC44FF-6713-4243-9BE5-5B6EAEC13178}.Debug|Any CPU.Build.0 = Debug|Any CPU", 2);
            SLN.AppendLine("{9DFC44FF-6713-4243-9BE5-5B6EAEC13178}.Release|Any CPU.ActiveCfg = Release|Any CPU", 2);
            SLN.AppendLine("{9DFC44FF-6713-4243-9BE5-5B6EAEC13178}.Release|Any CPU.Build.0 = Release|Any CPU", 2);
            SLN.AppendLine("EndGlobalSection", 1);
            SLN.AppendLine("GlobalSection(SolutionProperties) = preSolution", 1);
            SLN.AppendLine("HideSolutionNode = FALSE", 2);
            SLN.AppendLine("EndGlobalSection", 1);
            SLN.AppendLine("GlobalSection(NestedProjects) = preSolution", 1);
            SLN.AppendLine("{10F12706-7FED-45F8-AC60-D222C8E64494} = {C61707EA-6922-4543-8B04-FE4FEB467B99}", 2);
            SLN.AppendLine("{5E73ADC5-35FC-476E-81D1-F09FB6A307E8} = {C61707EA-6922-4543-8B04-FE4FEB467B99}", 2);
            SLN.AppendLine("{3DFE510B-2EBD-46A3-BA1A-62CD28E6427D} = {C61707EA-6922-4543-8B04-FE4FEB467B99}", 2);
            SLN.AppendLine("{5248E87F-EB51-4E16-9CE3-9F46F214054F} = {C61707EA-6922-4543-8B04-FE4FEB467B99}", 2);
            SLN.AppendLine("{34934E1B-4B3C-4D85-A190-EA4E81B39746} = {C61707EA-6922-4543-8B04-FE4FEB467B99}", 2);
            SLN.AppendLine("{0CD72A40-B22F-4609-A7C9-95C82EC6F6D2} = {34934E1B-4B3C-4D85-A190-EA4E81B39746}", 2);
            SLN.AppendLine("{E00E48EE-3D7E-41C7-94A6-09581A6D0BA1} = {34934E1B-4B3C-4D85-A190-EA4E81B39746}", 2);
            SLN.AppendLine("{1E0B0AB0-45B5-400C-A6CA-5178D89BC073} = {E00E48EE-3D7E-41C7-94A6-09581A6D0BA1}", 2);
            SLN.AppendLine("{28416AB3-34AC-4DEE-BC8D-73877D9CB8AC} = {E00E48EE-3D7E-41C7-94A6-09581A6D0BA1}", 2);
            SLN.AppendLine("{5806D0C7-9543-40B4-85FE-86C174D16B42} = {0CD72A40-B22F-4609-A7C9-95C82EC6F6D2}", 2);
            SLN.AppendLine("{EB1C385A-F3F7-4789-97E0-1D4C2FBEA323} = {0CD72A40-B22F-4609-A7C9-95C82EC6F6D2}", 2);
            SLN.AppendLine("{0E75C193-3E2C-46B5-BD22-B16173689804} = {5248E87F-EB51-4E16-9CE3-9F46F214054F}", 2);
            SLN.AppendLine("{9D397C15-304C-44ED-BE7B-F88E8DD78BF9} = {5248E87F-EB51-4E16-9CE3-9F46F214054F}", 2);
            SLN.AppendLine("{F0334DDB-ADC4-4CC5-99C7-419A92DE9E32} = {3DFE510B-2EBD-46A3-BA1A-62CD28E6427D}", 2);
            SLN.AppendLine("{1A3CE60C-5FC6-4FCE-A327-89C2049F11B1} = {3DFE510B-2EBD-46A3-BA1A-62CD28E6427D}", 2);
            SLN.AppendLine("{21E5B6B4-FE9B-481E-8751-1A9BD1F3336B} = {5E73ADC5-35FC-476E-81D1-F09FB6A307E8}", 2);
            SLN.AppendLine("{49EFF498-9487-489E-B502-4647D2ED3FBC} = {5E73ADC5-35FC-476E-81D1-F09FB6A307E8}", 2);
            SLN.AppendLine("{376480D5-8D1F-4067-8CB1-C6A317A23BD9} = {10F12706-7FED-45F8-AC60-D222C8E64494}", 2);
            SLN.AppendLine("{E70948C0-EFD6-4DEE-8C05-0660DE52CE73} = {10F12706-7FED-45F8-AC60-D222C8E64494}", 2);
            SLN.AppendLine("{7A560683-3254-42A4-8B94-730D3761DABE} = {10F12706-7FED-45F8-AC60-D222C8E64494}", 2);
            SLN.AppendLine("{394E94AE-29C8-48A7-8D54-DA80A5A43059} = {28416AB3-34AC-4DEE-BC8D-73877D9CB8AC}", 2);
            SLN.AppendLine("{C8FDAD7A-B860-40B0-B9AE-39C51E6B8B7C} = {28416AB3-34AC-4DEE-BC8D-73877D9CB8AC}", 2);
            SLN.AppendLine("{DAE8F2E0-571B-4DE6-838F-5DC55E22CB41} = {1E0B0AB0-45B5-400C-A6CA-5178D89BC073}", 2);
            SLN.AppendLine("{3119482A-BFDC-4386-ACA0-189FFCFF855E} = {EB1C385A-F3F7-4789-97E0-1D4C2FBEA323}", 2);
            SLN.AppendLine("{B048D9BD-B503-47D9-8E05-9F01521AE8E8} = {5806D0C7-9543-40B4-85FE-86C174D16B42}", 2);
            SLN.AppendLine("{94B6A2A6-0750-4DED-8034-FE9A33C3E8D9} = {9D397C15-304C-44ED-BE7B-F88E8DD78BF9}", 2);
            SLN.AppendLine("{D1CE6ABD-C23A-415B-86C4-D0A7AEB2531B} = {0E75C193-3E2C-46B5-BD22-B16173689804}", 2);
            SLN.AppendLine("{9F48320A-20E5-467D-A7DE-BBDAD7755692} = {0E75C193-3E2C-46B5-BD22-B16173689804}", 2);
            SLN.AppendLine("{8418BBCB-8952-4864-9092-9D2493D3DC66} = {EB1C385A-F3F7-4789-97E0-1D4C2FBEA323}", 2);
            SLN.AppendLine("{6654E672-4764-44C6-B2A0-6570FF5EC820} = {28416AB3-34AC-4DEE-BC8D-73877D9CB8AC}", 2);
            SLN.AppendLine("{333D9451-7533-4E39-A512-C3CC6F1AFC44} = {1A3CE60C-5FC6-4FCE-A327-89C2049F11B1}", 2);
            SLN.AppendLine("{B707729C-E441-4946-8D78-7C8BBB89AFE6} = {1A3CE60C-5FC6-4FCE-A327-89C2049F11B1}", 2);
            SLN.AppendLine("{CEEE0E39-E857-48E9-9008-732A8F7AEB4A} = {F0334DDB-ADC4-4CC5-99C7-419A92DE9E32}", 2);
            SLN.AppendLine("{DA4C8FBE-B5D5-46FB-938D-C57078489E1F} = {376480D5-8D1F-4067-8CB1-C6A317A23BD9}", 2);
            SLN.AppendLine("{37C0A3E8-3808-4BBA-9D30-CD1BA941BFA0} = {DA4C8FBE-B5D5-46FB-938D-C57078489E1F}", 2);
            SLN.AppendLine("{8A0549F8-E565-4413-AC10-915BFB88F025} = {DA4C8FBE-B5D5-46FB-938D-C57078489E1F}", 2);
            SLN.AppendLine("{9DFC44FF-6713-4243-9BE5-5B6EAEC13178} = {2B50C8C2-375A-42EA-A27F-1F61E5558351}", 2);
            SLN.AppendLine("EndGlobalSection", 2);
            SLN.AppendLine("EndGlobal");
        }
    }
}
