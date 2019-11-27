using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class DatabaseConfiguration:ConfigurationBase
    {
        private static string _prefix = "DataBase";
        private string _dataConntectionKey = $"{_prefix}:DataConnectionString";
        private string _authConntectionKey = $"{_prefix}:AuthConnectionString";
        public string GetDataConnectionString()
        {
            return GetConfiguration()[_dataConntectionKey];
        } 
        public string GetAuthConnectionString()
        {
            return GetConfiguration()[_authConntectionKey];
        }
    }
}
