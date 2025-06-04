using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Banco_Arquivo
{
    internal class Program
    {
        private static string bpcp = "serverl=localhost;user=root;database=pcp;port=3306;password=root";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Conectado");
                MySqlConnection mconn = new MySqlConnection(bpcp);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
      
        }
    }

    


