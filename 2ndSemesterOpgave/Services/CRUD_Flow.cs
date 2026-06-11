using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;
using _2ndSemesterOpgave.Class;

namespace _2ndSemesterOpgave.Services
{
    public class CRUD_Flow
    {
        public static List<Flow> GetAll()
        {
            var flows = new List<Flow>();

            using var connection = Database.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, Content, UserId FROM Flow";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                flows.Add(new Flow
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Content = reader.GetString(2),
                    UserId = reader.GetInt32(3)
                });
            }
            return flows;
        }

        public static void Add(string title, string content, int userId)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Flow (Title, Content, UserId) VALUES (@title, @content, @userId)";
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }
    }
}