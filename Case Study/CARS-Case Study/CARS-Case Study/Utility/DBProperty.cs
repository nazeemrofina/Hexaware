using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Utility
{
    class DBProperty
    {
        public static string GetProperty(string ConnectionString)
        {
            try {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db.properties");
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Properties File Not Found");
                }
                var file = File.ReadAllLines(path);
                foreach (var line in file)
                {
                    if (line.StartsWith(ConnectionString + "="))
                    {
                        return line.Substring(line.IndexOf('=') + 1).Trim();
                    }
                }
                throw new KeyNotFoundException($"Key {ConnectionString} does not exist.");
            }

             catch (Exception e){
                Console.WriteLine(e.Message);
                  }

            return "";
    }
    }
}
