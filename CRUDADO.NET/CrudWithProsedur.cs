using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDADO.NET.Model;
using System.Xml.Linq;

namespace CRUDADO.NET
{
    public class CrudWithProsedur
    {
        string connectionString = "Data Source=DESKTOP-PHRL2VS;Initial Catalog=Mentor137;Integrated Security=True";

        public CrudWithProsedur()
        {

        }

        public CrudWithProsedur(string connection)
        {
            connectionString = connection;
        }

        public bool AddActor(Actor obj, string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();

                        //command.Parameters.Add(new SqlParameter())

                        command.Parameters.AddWithValue("@Name", obj.Name);

                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        if (result == -1) //prosedur -1 donur nese
                        {
                            return true;
                        }
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                //connection.Close();
            }

        }

        public List<Actor> GetActorsWithDataAdapter(string commandText)
        {
            List<Actor> list = new List<Actor>();
            DataTable dataTable = null;
            //DataSet dataSet = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(commandText, connection))
                    {
                        dataTable = new DataTable();
                        sqlData.Fill(dataTable);

                        try
                        {
                            //if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0) dataset isletsek
                            if (dataTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    Actor newActor = new Actor();

                                    newActor.Id = (int)dataTable.Rows[i]["Id"];
                                    newActor.Name = dataTable.Rows[i]["Name"].ToString();

                                    list.Add(newActor);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Data Tapilmadi...");
                            }

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                            //return list;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;

        }

        public Actor GetByIdActorWithoutDataAdapter(int actorId, string commandText)
        {
            Actor actor = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Id", actorId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                actor = new Actor
                                {
                                    // Veritabanından gelen sütunları okuyarak Actor nesnesini doldur
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    // Diğer sütunlar...
                                };

                                return actor;
                            }
                            else
                            {
                                Console.WriteLine("Data Tapilmadi...");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return actor;
        }


        //Dto ilsede bilerik idsiz
        public bool UpdateActor(Actor actor, string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();

                        //command.Parameters.Add(new SqlParameter())

                        command.Parameters.AddWithValue("@Name", actor.Name);
                        command.Parameters.AddWithValue("@Id", actor.Id); //where serti ucun

                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        if (result < 0) //prosedur -1 donur nese
                        {
                            return true;
                        }
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                //connection.Close();
            }
        }

        public bool DeleteActor(int Id, string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();

                        //command.Parameters.Add(new SqlParameter())

                        command.Parameters.AddWithValue("@Id", Id); //where serti ucun

                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        if (result < 0) //prosedur -1 donur nese
                        {
                            return true;
                        }
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                //connection.Close();
            }
        }

    }
}
