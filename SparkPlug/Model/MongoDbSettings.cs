/*
 * This file contains a MongoDbSettings class with methods that gets the connection string to the db.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }

        }
    }
}
