using SuperDB.Config;

using System.Data;
using System.Data.Odbc;

namespace SuperDB.Access
{
    public class AccessFactory : DBFactory
    {
        private IDbConnection _Connection;

        public static AccessFactory Create()
        {
            return new AccessFactory();
        }

        public override IDbConnection Connection
        {
            get
            {
                if (_Connection == default)
                {
                    _Connection = new OdbcConnection(DBConfig.ConnectionString);
                }
                if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }
    }
}
