using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Models
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private string path = "Log.txt";
        
        public static Log Instance
        {
            get
            {
                return _instance;
            }
        }
        private Log() { }

        public void Save(string message)
        {
            File.AppendAllText(path, message + Environment.NewLine );
        }

    }
}
