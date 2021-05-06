using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProyectoIndividual.Actions
{
    class Register
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6QMNAK5;Initial Catalog = PizzaShop; integrated security=true");
        public void RegisterStatement(String table, String insert, String values)
        {
            connection.Open();
            String query = $"INSERT INTO {table} ({insert}) VALUES ({values})";
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
