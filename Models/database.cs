using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Database.Connect
{
    public class ConnDatabase
    {
        private SqlConnection _connect;
        public SqlCommand _command;
        private DataTable d_table;
        private SqlDataAdapter d_adapter;

        public ConnDatabase()
        {
            _connect = new SqlConnection("Data Source=TafadzwaMu;Initial Catalog=SeatBooking;Integrated Security=True");
            _connect.Open();
        }

        public void sqlQuery(string query)
        {
            _command = new SqlCommand(query, _connect);
        }

        public DataTable Execute()
        {
            d_adapter = new SqlDataAdapter(_command);
            d_table = new DataTable();
            d_adapter.Fill(d_table);
            return d_table;
        }

        public void NonExecute()
        {
            _command.ExecuteNonQuery();
        }
    }
    
}