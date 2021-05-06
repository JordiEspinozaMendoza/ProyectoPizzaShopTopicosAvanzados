using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoIndividual.Actions
{
    class Delete
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6QMNAK5;Initial Catalog = PizzaShop; integrated security=true");

        public void DeleteStatement(String table, String condition)
        {
            try
            {
                connection.Open();
                String query = $"DELETE FROM {table} WHERE {condition}";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
        }
    }
}
