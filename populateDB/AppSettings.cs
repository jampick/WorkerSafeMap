using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace populateDB
{
    class AppSettings
    {
        public string StorageConnectionString { get; set; }
        public string StorageConnectionStringLocal { get; set; }
    }
}
