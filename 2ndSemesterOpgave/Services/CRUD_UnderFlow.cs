using _2ndSemesterOpgave.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Services
{
    public class CRUD_UnderFlow
    {
        public static async Task<List<UnderFlow>> GetByFlow(int flowId)
        {
            var underflows = new List<UnderFlow>();

            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, Content, FlowId FROM UnderFlow WHERE FlowId = @flowId";
            command.Parameters.AddWithValue("@flowId", flowId);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
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

        public static async Task Add(string title, string content, int flowId)
        {
            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO UnderFlow (Title, Content, FlowId) VALUES (@title, @content, @flowId)";
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@content", content);
            command.Parameters.AddWithValue("@flowId", flowId);
            await command.ExecuteNonQueryAsync();
        }
    }
}
