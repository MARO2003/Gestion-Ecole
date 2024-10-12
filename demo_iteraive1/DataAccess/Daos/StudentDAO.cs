using demo_iteraive1.Buisness.Domain;
using demo_iteraive1.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data_Access_Module.Daos
{
    public class StudentDAO
    {
        private SqlConnection connection;
        private string tableName = "Student";
        private string datetimeDbFormat = "yyyy-MM-dd HH:mm:ss.ffffff";
        private DataTable table;
        private SqlDataAdapter dataAdapter;
        public StudentDAO()
        {
            this.connection = DbConnectionProvider.GetConnection();
            this.table = new DataTable(this.tableName);

            this.dataAdapter = this.CreateDataAdapter();

        }


        //mode deconnecte avec adapdateur 
        public DataTable GetDataTable()
        {
            return this.table;
        }


        public void ReloadDataTable()
        {
            this.table.Clear();
            this.dataAdapter.Fill(this.table);
        }

        public void SaveChanges()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
            this.dataAdapter.Update(this.table);

        }

        public SqlDataAdapter CreateDataAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();


            SqlCommand selectCommand = this.connection.CreateCommand();
            selectCommand.CommandText = $"SELECT * FROM {this.tableName};";
            adapter.SelectCommand = selectCommand;

            SqlCommand insertCommand = this.connection.CreateCommand();
            insertCommand.CommandText = $"INSERT INTO {this.tableName} ('CourseName','CourseCode') VALUES (@courseName,@courseCode);";
            insertCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 64, "FirstName");
            /*manuellement :
            SqlParameter firstNameParam2 = insertCommand.CreateParameter();
            firstNameParam2.ParameterName = "@firstName";
            firstNameParam2.DbType = DbType.String;
            firstNameParam2.Size = 64;
            firstNameParam2.SourceColumn = "FirstName";
            insertCommand.Parameters.Add(firstNameParam2);
            */
            insertCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 64, "LastName");

            adapter.InsertCommand = insertCommand;

            SqlCommand updateCommand = this.connection.CreateCommand();
            updateCommand.CommandText = $"UPDATE `{this.tableName}` " +
                $" SET FirstName = @firstName ," +
                "LastName = @lastName   ," +
                "Code = @code   ," +
                "DateRegistration = @dateRegistration " +
                "WHERE Id = @id;" +
                "AND FirstName =@oldFirstName " +
                "AND LastName = @olfLAstName " +
                "AND Code = @oldCode " +
                "AND DateRegistration = @oldDateRegistration";
            updateCommand.Parameters.Add("@firstName", SqlDbType.NVarChar, 64, "FirstName");
            updateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 64, "LastName");
            updateCommand.Parameters.Add("@code", SqlDbType.NVarChar, 12, "Code");
            updateCommand.Parameters.Add("@dateRegistration", SqlDbType.DateTime2, 7, "DateRegistration");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            updateCommand.Parameters.Add("@oldFirstName", SqlDbType.NVarChar, 64, "FirstName").SourceVersion = DataRowVersion.Original;
            updateCommand.Parameters.Add("@oldLastName", SqlDbType.NVarChar, 64, "LastName").SourceVersion = DataRowVersion.Original;
            updateCommand.Parameters.Add("@oldCode", SqlDbType.NVarChar, 12, "Code").SourceVersion = DataRowVersion.Original;
            updateCommand.Parameters.Add("@oldDateRegistration", SqlDbType.DateTime2, 7, "DateRegistration").SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = updateCommand;
            

            SqlCommand deleteCommand = this.connection.CreateCommand();
            deleteCommand.CommandText = $"DELETE FROM {this.tableName} WHERE Id = @id;";
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            adapter.DeleteCommand = deleteCommand;

            return adapter;

        }
        //mode connecte:
        // a reutiliser lors de l'entitry framework
        /*
        public List<Student> GetAll(SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection; 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {this.tableName};";
            if(this.connection.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                int db_id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);
                string code = reader.GetString(3);
                DateTime dateRegistration = reader.GetDateTime(4);
                DateTime dateCreated = reader.GetDateTime(5);
                DateTime dateModified = reader.GetValue(6) == DBNull.Value ? Convert.ToDateTime(null) : reader.GetDateTime(6);
                DateTime dateDeleted = reader.GetValue(7) == DBNull.Value ? Convert.ToDateTime(null) : reader.GetDateTime(7);

                Student student = new Student(db_id, firstName, lastName,code, dateRegistration, dateCreated, dateModified, dateDeleted);
                students.Add(student);
            }
            reader.Close();
            return students;
        }
        public Student GetById(int id , SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {this.tableName} WHERE Id = @id;";
            SqlParameter idParam = cmd.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.DbType = DbType.Int32;
            cmd.Parameters.Add(idParam);

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
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
        public Student Create(Student student , SqlTransaction? transaction = null )
        {
            // si j'ai pas de transaction je prend la connection normale
            SqlConnection conn = transaction?.Connection ?? this.connection; 
            SqlCommand insertCommand = this.connection.CreateCommand();
            insertCommand.CommandText = $"INSERT INTO {this.tableName} ('FirstName','LastName','Code'," +
                $"'DateRegistration', 'DateCreated','DateModified' ,'DateDeleted') VALUES (@firstName,@lastName," +
                $"@code,@dateRegistration); SELECT SCOPE_INDENTITY();";
            SqlParameter firstNameParam = insertCommand.CreateParameter();
            firstNameParam.ParameterName = "@firstName";
            firstNameParam.Value = student.FirstName;
            firstNameParam.DbType = DbType.String;
            insertCommand.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = insertCommand.CreateParameter();
            lastNameParam.ParameterName = "@firstName";
            lastNameParam.Value = student.LastName;
            lastNameParam.DbType = DbType.String;
            insertCommand.Parameters.Add(lastNameParam);

            SqlParameter codeParam = insertCommand.CreateParameter();
            codeParam.ParameterName = "@firstName";
            codeParam.Value = student.Code;
            codeParam.DbType = DbType.String;
            insertCommand.Parameters.Add(codeParam);

            SqlParameter dateRegParam = insertCommand.CreateParameter();
            dateRegParam.ParameterName = "@firstName";
            dateRegParam.Value = student.DateRegistration;
            dateRegParam.DbType = DbType.DateTime2;
            insertCommand.Parameters.Add(dateRegParam);

            if(transaction != null)
            {
                insertCommand.Transaction = transaction;
            }

            if (this.connection.State != System.Data.ConnectionState.Open)
            {
                this.connection.Open();
            }
            int insertedId = (int)insertCommand.ExecuteScalar();
            return this.GetById(insertedId , transaction);
        }
        public Student Update(Student student, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            SqlCommand updateCommand = conn.CreateCommand();
            updateCommand.CommandText = $"UPDATE `{this.tableName}` " +
                $" SET FirstName = @firstName ," +
                "LastName = @lastName   ," +
                "Code = @code   ," +
                "DateRegistration = @dateRegistration " +
                "WHERE Id = @id;";
            SqlParameter firstNameParam = updateCommand.CreateParameter();
            firstNameParam.ParameterName = "@firstName";
            firstNameParam.Value = student.FirstName;
            firstNameParam.DbType = DbType.String;
            updateCommand.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = updateCommand.CreateParameter();
            lastNameParam.ParameterName = "@firstName";
            lastNameParam.Value = student.LastName;
            lastNameParam.DbType = DbType.String;
            updateCommand.Parameters.Add(lastNameParam);

            SqlParameter codeParam = updateCommand.CreateParameter();
            codeParam.ParameterName = "@firstName";
            codeParam.Value = student.Code;
            codeParam.DbType = DbType.String;
            updateCommand.Parameters.Add(codeParam);

            SqlParameter dateRegParam = updateCommand.CreateParameter();
            dateRegParam.ParameterName = "@firstName";
            dateRegParam.Value = student.DateRegistration;
            dateRegParam.DbType = DbType.DateTime2;
            updateCommand.Parameters.Add(dateRegParam);

            SqlParameter idParam = updateCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = student.Id;
            idParam.DbType = DbType.Int32;
            updateCommand.Parameters.Add(idParam);

            if(transaction != null)
            {
                updateCommand.Transaction = transaction;
            }

            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            int numRows = updateCommand.ExecuteNonQuery();
            if(numRows == 0)
            {
                throw new Exception($"Failed student update in database: Student id #{student.Id} was not found.");
            }
            return this.GetById(student.Id , transaction);

        }
        public void Delete(Student student, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            SqlCommand deleteCommand = conn.CreateCommand();

            deleteCommand.CommandText = $"DELETE FROM {this.tableName} WHERE Id = @id;";

            SqlParameter idParam = deleteCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = student.Id;
            idParam.DbType = DbType.Int32;
            deleteCommand.Parameters.Add(idParam);

            if (transaction != null)
            {
                deleteCommand.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            int numRows = deleteCommand.ExecuteNonQuery();
            if (numRows == 0)
            {
                throw new Exception($"Failed student deletion in database: Student id #{student.Id} was not found.");
            }
        }
        */
    }

}
