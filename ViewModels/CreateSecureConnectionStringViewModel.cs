using System.Activities.DesignViewModels;
using System.Diagnostics;
using System.Security;

namespace Delta_Utilities_Activities.ViewModels
{
    public class CreateSecureConnectionStringViewModel : DesignPropertiesViewModel
    {
        public DesignProperty<DatabaseType> DBType { get; set; }
        public DesignInArgument<string> Server { get; set; }
        public DesignInArgument<string> DatabaseNametabase { get; set; }
        public DesignInArgument<string> Username { get; set; }
        public DesignInArgument<SecureString> Password { get; set; }
        public DesignInArgument<string> AdditionalSettings { get; set; }
        public DesignOutArgument<SecureString> SecureConnectionString { get; set; }

        public CreateSecureConnectionStringViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            base.InitializeModel();

            PersistValuesChangedDuringInit(); // mandatory call only when you change the values of properties during initialization

            var orderIndex = 0;

            DBType.DisplayName = Resources.CreateSecureConnectionString_DBType_DisplayName;
            DBType.Tooltip = Resources.CreateSecureConnectionString_DBType_Tooltip;
            DBType.IsRequired = true;
            DBType.IsPrincipal = true;
            DBType.OrderIndex = orderIndex++;

            Server.DisplayName = Resources.CreateSecureConnectionString_Server_DisplayName;
            Server.Tooltip = Resources.CreateSecureConnectionString_Server_Tooltip;
            Server.IsRequired = true;
            Server.IsPrincipal = true;
            Server.OrderIndex = orderIndex++;

            DatabaseNametabase.DisplayName = Resources.CreateSecureConnectionString_DatabaseName_DisplayName;
            DatabaseNametabase.Tooltip = Resources.CreateSecureConnectionString_DatabaseName_Tooltip;
            DatabaseNametabase.IsRequired = true;
            DatabaseNametabase.IsPrincipal = true;
            DatabaseNametabase.OrderIndex = orderIndex++;

            Username.DisplayName = Resources.CreateSecureConnectionString_Username_DisplayName;
            Username.Tooltip = Resources.CreateSecureConnectionString_Username_Tooltip;
            Username.IsRequired = true;
            Username.IsPrincipal = true;
            Username.OrderIndex = orderIndex++;

            Password.DisplayName = Resources.CreateSecureConnectionString_Password_DisplayName;
            Password.Tooltip = Resources.CreateSecureConnectionString_Password_Tooltip;
            Password.IsRequired = true;
            Password.IsPrincipal = true;
            Password.OrderIndex = orderIndex++;

            AdditionalSettings.DisplayName = Resources.CreateSecureConnectionString_AdditionalSettings_DisplayName;
            AdditionalSettings.Tooltip = Resources.CreateSecureConnectionString_AdditionalSettings_Tooltip;
            AdditionalSettings.IsRequired = false;
            AdditionalSettings.IsPrincipal = false;
            AdditionalSettings.OrderIndex = orderIndex++;

            SecureConnectionString.DisplayName = Resources.CreateSecureConnectionString_SecureConnectionString_DisplayName;
            SecureConnectionString.Tooltip = Resources.CreateSecureConnectionString_SecureConnectionString_Tooltip;
            SecureConnectionString.IsRequired = true;
            SecureConnectionString.IsPrincipal = true;
            SecureConnectionString.OrderIndex = orderIndex;
            
        }
    }
}
