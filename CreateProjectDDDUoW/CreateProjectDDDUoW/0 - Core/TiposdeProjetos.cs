using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._0___Core
{
    class EnumGuid : Attribute
    {
        public Guid Guid;

        public EnumGuid(string guid)
        {
            Guid = new Guid(guid);
        }
    }
    public enum TiposdeProjetos
    {

        [EnumGuid("8BB2217D-0F2D-49D1-97BC-3654ED321F3B")]
        ASPNET_5,

        [EnumGuid("603C0E0B-DB56-11DC-BE95-000D561079B0")]
        ASPNET_MVC_1,

        [EnumGuid("F85E285D-A4E0-4152-9332-AB1D724D3325")]
        ASPNET_MVC_2,

        [EnumGuid("E53F8FEA-EAE0-44A6-8774-FFD645390401")]
        ASPNET_MVC_3,

        [EnumGuid("E3E379DF-F4C6-4180-9B81-6769533ABE47")]
        ASPNET_MVC_4,

        [EnumGuid("349C5851-65DF-11DA-9384-00065B846F21")]
        ASPNET_MVC_5,

        [EnumGuid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC")]
        CSharp,

        [EnumGuid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942")]
        CPlusPlus,

        [EnumGuid("A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124")]
        Database,

        [EnumGuid("4F174C21-8C12-11D0-8340-0000F80270F8")]
        Database_other_project_types,

        [EnumGuid("3EA9E505-35AC-4774-B492-AD1749C4943A")]
        Deployment_Cab,

        [EnumGuid("06A35CCD-C46D-44D5-987B-CF40FF872267")]
        Deployment_Merge_Module,

        [EnumGuid("978C614F-708E-4E1A-B201-565925725DBA")]
        Deployment_Setup,

        [EnumGuid("AB322303-2255-48EF-A496-5904EB18DA55")]
        Deployment_Smart_Device_Cab,

        [EnumGuid("F135691A-BF7E-435D-8960-F99683D2D49C")]
        Distributed_System,

        [EnumGuid("BF6F8E12-879D-49E7-ADF0-5503146B24B8")]
        Dynamics_2012_AX_CSharp_in_AOT,

        [EnumGuid("F2A71F9B-5D33-465A-A702-920D77279786")]
        FSharp,

        [EnumGuid("E6FDF86B-F3D1-11D4-8576-0002A516ECE8")]
        JSharp,

        [EnumGuid("20D4826A-C6FA-45DB-90F4-C717570B9F32")]
        Legacy_2003_Smart_Device_CSharp,

        [EnumGuid("CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8")]
        Legacy_2003_Smart_Device_VBNET,

        [EnumGuid("b69e3092-b931-443c-abe7-7e7b65f2a37f")]
        Micro_Framework,

        [EnumGuid("F85E285D-A4E0-4152-9332-AB1D724D3325")]
        Model_View_Controller_v2_MVC_2,

        [EnumGuid("E53F8FEA-EAE0-44A6-8774-FFD645390401")]
        Model_View_Controller_v3_MVC_3,

        [EnumGuid("E3E379DF-F4C6-4180-9B81-6769533ABE47")]
        Model_View_Controller_v4_MVC_4,

        [EnumGuid("349C5851-65DF-11DA-9384-00065B846F21")]
        Model_View_Controller_v5_MVC_5,

        [EnumGuid("EFBA0AD7-5A72-4C68-AF49-83D382785DCF")]
        Mono_for_Android,

        [EnumGuid("6BC8ED88-2882-458C-8E55-DFD12B67127B")]
        MonoTouch,

        [EnumGuid("F5B4F3BC-B597-4E2B-B552-EF5D8A32436F")]
        MonoTouch_Binding,

        [EnumGuid("786C830F-07A1-408B-BD7F-6EE04809D6DB")]
        Portable_Class_Library,

        [EnumGuid("66A26720-8FB5-11D2-AA7E-00C04F688DDE")]
        Project_Folders,

        [EnumGuid("593B0543-81F6-4436-BA1E-4747859CAAE2")]
        SharePoint_CSharp,

        [EnumGuid("EC05E597-79D4-47f3-ADA0-324C4F7C7484")]
        SharePoint_VBNET,

        [EnumGuid("F8810EC1-6754-47FC-A15F-DFABD2E3FA90")]
        SharePoint_Workflow,

        [EnumGuid("A1591282-1198-4647-A2B1-27E5FF5F6F3B")]
        Silverlight,

        [EnumGuid("4D628B5B-2FBC-4AA6-8C16-197242AEB884")]
        Smart_Device_CSharp,

        [EnumGuid("68B1623D-7FB9-47D8-8664-7ECEA3297D4F")]
        Smart_Device_VBNET,

        [EnumGuid("2150E333-8FDC-42A3-9474-1A3956D46DE8")]
        Solution_Folder,

        [EnumGuid("3AC096D0-A1C2-E12C-1390-A8335801FDAB")]
        Test,

        [EnumGuid("A5A43C5B-DE2A-4C0C-9213-0A381AF9435A")]
        Universal_Windows_Class_Library,

        [EnumGuid("F184B08F-C81C-45F6-A57F-5ABD9991F28F")]
        VBNET,

        [EnumGuid("C252FEB5-A946-4202-B1D4-9916A0590387")]
        Visual_Database_Tools,

        [EnumGuid("54435603-DBB4-11D2-8724-00A0C9A8B90C")]
        Visual_Studio_2015_Installer_Project_Extension,

        [EnumGuid("A860303F-1F3F-4691-B57E-529FC101A107")]
        Visual_Studio_Tools_for_Applications_VSTA,

        [EnumGuid("BAA0C2D2-18E2-41B9-852F-F413020CAA33")]
        Visual_Studio_Tools_for_Office_VSTO,

        [EnumGuid("349C5851-65DF-11DA-9384-00065B846F21")]
        Web_Application,

        [EnumGuid("E24C65DC-7377-472B-9ABA-BC803B73C61A")]
        Web_Site,

        [EnumGuid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC")]
        Windows_CSharp,

        [EnumGuid("F184B08F-C81C-45F6-A57F-5ABD9991F28F")]
        Windows_VBNET,

        [EnumGuid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942")]
        Windows_Visual_CPlusPlus,

        [EnumGuid("3D9AD99F-2412-4246-B90B-4EAA41C64699")]
        Windows_Communication_Foundation_WCF,

        [EnumGuid("76F1466A-8B6D-4E39-A767-685A06062A39")]
        Windows_Phone_8_81_Blank_Hub_Webview_App,

        [EnumGuid("C089C8C0-30E0-4E22-80C0-CE093F111A43")]
        Windows_Phone_8_81_App_CSharp,

        [EnumGuid("DB03555F-0C8B-43BE-9FF9-57896B3C5E56")]
        Windows_Phone_8_81_App_VBNET,

        [EnumGuid("60DC8134-EBA5-43B8-BCC9-BB4BC16C2548")]
        Windows_Presentation_Foundation_WPF,

        [EnumGuid("BC8A1FFA-BEE3-4634-8014-F334798102B3")]
        Windows_Store_Metro_Apps_E_Components,

        [EnumGuid("14822709-B5A1-4724-98CA-57A101D1B079")]
        Workflow_CSharp,

        [EnumGuid("D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8")]
        Workflow_VBNET,

        [EnumGuid("32F31D43-81CC-4C15-9DE6-3FC5453562B6")]
        Workflow_Foundation,

        [EnumGuid("EFBA0AD7-5A72-4C68-AF49-83D382785DCF")]
        XamarinAndroid,

        [EnumGuid("6BC8ED88-2882-458C-8E55-DFD12B67127B")]
        XamariniOS,

        [EnumGuid("6D335F3A-9D43-41b4-9D22-F6F17C4BE596")]
        XNA_Windows,

        [EnumGuid("2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2")]
        XNA_XBox,

        [EnumGuid("D399B71A-8929-442a-A9AC-8BEC78BB2433")]
        XNA_Zune

    }
}
