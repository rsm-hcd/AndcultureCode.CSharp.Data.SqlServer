using AndcultureCode.CSharp.Core.Models;

namespace AndcultureCode.CSharp.Data.SqlServer
{
    public class SqlServerConnection : Connection
    {
        public override string ToString(string delimiter = ";")
            => $"Data Source={Datasource}; Database={Database}; User Id={UserId}; Password={Password}; {AdditionalParameters}";
    }
}
