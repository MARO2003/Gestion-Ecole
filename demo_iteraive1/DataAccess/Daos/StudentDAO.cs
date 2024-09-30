using demo_iteraive1.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Module.Daos
{
    public class StudentDAO
    {
        private SqlConnection connection;
        private string tableName = "Student";

        public StudentDAO()
        {
            this.connection = DbConnectionProvider.GetConnection();
        }

        public Student GetById(int id)
        {
            SqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {this.tableName} WHERE Id = {id};";
            if(this.connection.State != System.Data.ConnectionState.Open)
            {
                this.connection.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                throw new Exception($"No database record for Student Id #{id}.");
            }
            int db_id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            string code = reader.GetString(3);
            DateTime dateRegistration = reader.GetDateTime(4);
            DateTime dateCreated = reader.GetDateTime(5);
            DateTime dateModified = reader.GetValue(6) == DBNull.Value ? Convert.ToDateTime(null) : reader.GetDateTime(6);
            DateTime dateDeleted = reader.GetValue(6) == DBNull.Value ? Convert.ToDateTime(null) : reader.GetDateTime(6);

            reader.Close();
            return new Student(db_id, firstName, lastName, code,dateRegistration,dateCreated,dateModified,dateDeleted);
        }

    }
}
