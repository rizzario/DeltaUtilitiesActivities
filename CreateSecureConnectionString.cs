using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;
using Delta_Utilities_Activities.Helpers;

namespace Delta_Utilities_Activities
{
    public enum DatabaseType
    {
        [Description("Microsoft SQL Server")]
        SQLServer,
        [Description("Oracle Database")]
        Oracle,
        [Description("ODBC Data Source")]
        ODBC,
        [Description("OLE DB")]
        OleDb
    }

    [DisplayName("Create Secure Connection String")]
    [Description("Combines connection details into a single SecureString for Database connection.")]
    public class CreateSecureConnectionString : CodeActivity // This base class exposes an OutArgument named Result
    {
        [Category("Connection Configuration")]
        [DisplayName("Database Type")]
        [RequiredArgument]
        public DatabaseType DBType { get; set; } = DatabaseType.SQLServer;

        [Category("Connection Configuration")]
        [DisplayName("Server / Data Source")]
        [RequiredArgument]
        public InArgument<string> Server { get; set; }

        [Category("Connection Configuration")]
        [DisplayName("Initial Catalog / DB Name")]
        public InArgument<string> DatabaseName { get; set; }

        [Category("Connection Configuration")]
        [DisplayName("Username")]
        public InArgument<string> Username { get; set; }

        [Category("Connection Configuration")]
        [DisplayName("Password (Secure)")]
        [RequiredArgument]
        public InArgument<SecureString> Password { get; set; }

        [Category("Misc")]
        [DisplayName("Additional Settings")]
        public InArgument<string> AdditionalSettings { get; set; }

        [Category("Output")]
        [DisplayName("Secure Connection String")]
        [RequiredArgument]
        public OutArgument<SecureString> SecureConnectionString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var type = DBType;
            string server = Server.Get(context);
            string db = DatabaseName.Get(context);
            string user = Username.Get(context);
            SecureString pass = Password.Get(context);
            string extra = AdditionalSettings.Get(context) ?? "";

            // Add trust server certificate for SQL Server if no extra settings provided (common for local dev environments)
            if (string.IsNullOrEmpty(extra) && DBType == DatabaseType.SQLServer)
            {
                extra = "TrustServerCertificate=True;";
            }

            string template = type switch
            {
                DatabaseType.SQLServer => $"Data Source={server};Initial Catalog={db};User ID={user};Password=",
                DatabaseType.Oracle => $"Data Source={server};User Id={user};Password=",
                DatabaseType.ODBC => $"Dsn={server};Uid={user};Pwd=",
                _ => $"Data Source={server};Password="
            };

            SecureString result = new SecureString();

            // Append Template
            foreach (char c in template) result.AppendChar(c);

            // Append Secure Password (Safe Memory Management)
            if (pass != null)
            {
                IntPtr ptr = Marshal.SecureStringToGlobalAllocUnicode(pass);
                try
                {
                    for (int i = 0; i < pass.Length; i++)
                    {
                        short character = Marshal.ReadInt16(ptr, i * 2);
                        result.AppendChar((char)character);
                    }
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(ptr);
                }
            }

            // Append Extra Settings
            if (!string.IsNullOrEmpty(extra))
            {
                if (!extra.StartsWith(";")) result.AppendChar(';');
                foreach (char c in extra) result.AppendChar(c);
            }

            result.MakeReadOnly();
            SecureConnectionString.Set(context, result);
        }

        public int ExecuteInternal()
        {
            // use this to automatically attach the debugger to the process
            //Debugger.Launch();
            throw new NotImplementedException();
        }


    }
}
