using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Configuration;
using LinqToDB.Data;


namespace AcientBulletinBoard.DataModels
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}
