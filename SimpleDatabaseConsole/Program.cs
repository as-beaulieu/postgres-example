using Npgsql;
using System;

namespace SimpleDatabaseConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connString = "Host=localhost;Username=postgres;Password=postgres;Database=testdatabase";

            var id = new Guid();

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                //Insert data
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO testschema.testtable (name) VALUES (@name)"; //(Name),@Name = Column
                    command.Parameters.AddWithValue("name", "Phil"); //("Column", "Value)
                    command.ExecuteNonQuery();
                }

                //Insert multiple rows
                using(var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO testschema.testtable" +
                        "(name, id, number)" +
                        "VALUES (@name, @id, @number)";
                    command.Parameters.AddWithValue("name", "Greg");
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("number", 7);
                    command.ExecuteNonQuery(); //Needs to be inside the loop

                    //TODO: have the command ttext and parameters constructed once(Using the Parameters.Add for the parameters
                    // and change values in the loop.

                    //Also should have one oconnection open. So open just before the loop and close it after
                }

                //Retrieve all rows
                using (var command = new NpgsqlCommand("SELECT Name FROM testschema.testtable", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
}

