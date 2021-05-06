using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoIndividual.Actions
{
    class Select
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6QMNAK5;Initial Catalog = PizzaShop; integrated security=true");
        public List<List<Object>> SelectStatement(String table, int numItems)
        {
            connection.Open();
            String query = $"SELECT * FROM {table}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader sqlDataReader = null;

            List<List<Object>> response = new List<List<Object>>();
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception err)
            {
                return null;
            }
            while (sqlDataReader.Read())
            {
                List<Object> temp = new List<Object>();

                for (int i = 0; i < numItems; i++)
                {
                    temp.Add(sqlDataReader[i]);
                }

                response.Add(temp);
            }

            connection.Close();
            return response;
        }
        public DataTable SelectStatementDatatable   (String table)
        {
            connection.Open();
            String query = $"SELECT * FROM {table}";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
        public List<List<Object>> SelectStatement(String table, int numItems, String where)
        {
            connection.Open();
            String query = $"SELECT * FROM {table} WHERE {where}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader sqlDataReader = null;

            List<List<Object>> response = new List<List<Object>>();
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception err)
            {
                return null;
            }
            while (sqlDataReader.Read())
            {
                List<Object> temp = new List<Object>();

                for (int i = 0; i < numItems; i++)
                {
                    temp.Add(sqlDataReader[i]);
                }

                response.Add(temp);
            }

            connection.Close();
            return response;
        }
        public List<Object> SelectOneStatement(String table, String where, int numItems)
        {
            connection.Open();
            String query = $"SELECT * FROM {table} WHERE {where}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader sqlDataReader;

            List<Object> response = new List<Object>();
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception err)
            {
                return null;
            }
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < numItems; i++)
                {
                    response.Add(sqlDataReader[i]);
                }
            }

            connection.Close();
            return response;
        }
        public Object SelectLast(String table, String order)
        {
            connection.Open();
            String query = $" SELECT TOP 1 * FROM {table} ORDER BY {order} DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader sqlDataReader = null;
            int response = 0;
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception err)
            {
                return null;
            }
            while (sqlDataReader.Read())
            {
                response = (int)sqlDataReader[0];
            }
            connection.Close();
            return response;

        }
    }
}
