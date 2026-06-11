using _2ndSemesterOpgave.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Services
{
    public class CRUD_UnderFlow
    {
        public static List<UnderFlow> GetByFlow(int flowId)
        {
            var underflows = new List<UnderFlow>();

            using var connection = Database.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, Content, FlowId FROM UnderFlow WHERE FlowId = @flowId";
            command.Parameters.AddWithValue("@flowId", flowId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                underflows.Add(new UnderFlow
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Content = reader.GetString(2),
                    FlowId = reader.GetInt32(3)
                });
            }

            return underflows;
        }

        public static void Add(string title, string content, int flowId)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO UnderFlow (Title, Content, FlowId) VALUES (@title, @content, @flowId)";
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@flowId", flowId);
            command.ExecuteNonQuery();
        }
    }
}
