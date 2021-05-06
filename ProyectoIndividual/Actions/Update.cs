using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoIndividual.Actions
{
    class Update
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6QMNAK5;Initial Catalog = PizzaShop; integrated security=true");
        public void UpdateStatement(String table, String set, String where)
        {
            connection.Open();
            String query = $"UPDATE {table} SET {set} WHERE {where}";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
