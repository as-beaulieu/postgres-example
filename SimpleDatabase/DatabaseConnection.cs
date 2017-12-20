using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDatabase
{
    public class DatabaseConnection
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string NetLocation { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string[] Args { get; set; }

        //PostgreSQL conection string: postgresql://user:password@netlocation:port/dbname?param1=value1&...
        //Example: postgresql://user:secret@localhost:51067/SimpleDatabase?connect_timeout=10&application_name=myapp

        public DatabaseConnection(
            string user,
            string password,
            string netLocation,
            int port, //Default is 5432
            string dbName,
            string[] args
            )
        {
            User = user;
            Password = password;
            NetLocation = netLocation;
            Port = port;
            DbName = dbName;
            if (args != null)
            {
                Args = args;
            }
            
        }



        public string CreateConnectionString()
        {
            var separatedArgs = SeparateArgs(Args);

            return $"postgresql://{User}:{Password}@{NetLocation}:{Port}/{DbName}?{separatedArgs}";
        }

        public string SeparateArgs(string[] args)
        {
            return String.Join("&", args);
        }

    }
}
