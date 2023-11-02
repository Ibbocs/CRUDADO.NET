using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRUDADO.NET
{
    public class Crud
    {
        static string connectionStringGet = "Data Source=DESKTOP-PHRL2VS;Initial Catalog=Mentor137;Integrated Security=True";
        string connectionString = "Data Source=DESKTOP-PHRL2VS;Initial Catalog=Mentor137;Integrated Security=True";




        public int Create(string name)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Actor (Name) Values ('{name}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    int rowAffect = command.ExecuteNonQuery();
                    connection.Close();

                    command.Dispose();
                    connection.Dispose();
                    return rowAffect;
                }
            }
        }

        public void Sellect()
        {

            Dictionary<string, string> map = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From Actor";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        string columnName = dataReader.GetName(i);
                        if (!map.ContainsKey(columnName))
                        {
                            map.Add(columnName, null);
                        }
                    }

                    while (dataReader.Read())
                    {

                        //map.Add("Id", Convert.ToString(dataReader["Id"]);
                        //teacher.Id = Convert.ToInt32(dataReader["Id"]);
                        //teacher.Name = Convert.ToString(dataReader["Name"]);
                        //teacher.Skills = Convert.ToString(dataReader["Skills"]);
                        //teacher.TotalStudents = Convert.ToInt32(dataReader["TotalStudents"]);
                        //teacher.Salary = Convert.ToDecimal(dataReader["Salary"]);
                        //teacher.AddedOn = Convert.ToDateTime(dataReader["AddedOn"]);

                        //teacherList.Add(teacher);

                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            string columnName = dataReader.GetName(i);
                            if (!map.ContainsKey(columnName))
                            {
                                map.Add(columnName, null);
                            }
                        }
                    }
                }

                connection.Close();
            }
        }

        public static void Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionStringGet))
            {
                connection.Open();

                //string sqlQuery = "SELECT * FROM Actor WHERE ActorID = @ActorId";
                string sqlQuery = "SELECT * FROM Actor";
                //int actorIdToRetrieve = 1; // Örnek olarak müşteri kimliği 1 olan bir müşteriyi alalım.

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    //command.Parameters.Add(new SqlParameter("@ActorId", SqlDbType.Int));
                    //command.Parameters["@ActorId"].Value = actorIdToRetrieve;

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                                //string Name = reader.GetString(reader.GetOrdinal("Name"));

                                int ActorId = Convert.ToInt32(reader["Id"]);
                                string ActorName = Convert.ToString(reader["Name"]);

                                Console.WriteLine($"Actor ID: {ActorId}, Actor Name: {ActorName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yoxdur Hecne");
                        }

                        command.Dispose();

                    }
                }

                connection.Close();
                connection.Dispose();
            }
        }

        public int Update(string name, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Actor SET Name='{name}' Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    int rowAffect = command.ExecuteNonQuery();
                    connection.Close();
                    command.Dispose();
                    connection.Dispose();

                    return rowAffect;
                }
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From Actor Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        int rowAffect = command.ExecuteNonQuery();//0 gelirse id yoxdur demekdi, if ile nese elemek olar
                        return rowAffect;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Operation got error:" + ex.Message);
                        return -1;
                    }
                    finally
                    {
                        connection.Close();
                        command.Dispose();
                        connection.Dispose();
                    }

                    command.Dispose();
                    connection.Dispose();

                }

            }
        }


    }
}
