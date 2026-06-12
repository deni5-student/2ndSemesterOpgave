using System;
using System.Collections.Generic;
using System.Text;
using _2ndSemesterOpgave.Class;

namespace _2ndSemesterOpgave.Services
{
    public class CRUD_User
    {
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : CRUD_User                             ║
        // ║  METODE      : GetAll()                              ║
        // ║  BESKRIVELSE : Henter alle brugere fra databasen     ║
        // ║                og returnerer dem som en liste        ║
        // ╚══════════════════════════════════════════════════════╝
        public static async Task<List<User>> GetAll()
        {
            var users = new List<User>();

            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Username, Password, Role FROM User";

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Username = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = reader.GetString(4)
                });
            }

            return users;
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : CRUD_User                             ║
        // ║  METODE      : Add()                                 ║
        // ║  BESKRIVELSE : Opretter en ny bruger i databasen     ║
        // ║                med navn, brugernavn, adgangskode     ║
        // ║                og rolle                              ║
        // ╚══════════════════════════════════════════════════════╝
        public static async Task Add(string name, string username, string password, string role)
        {
            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO User (Name, Username, Password, Role) VALUES (@name, @username, @password, @role)";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@role", role);
            await command.ExecuteNonQueryAsync();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : CRUD_User                             ║
        // ║  METODE      : Update()                              ║
        // ║  BESKRIVELSE : Opdater bruger i databasen            ║
        // ║                baseret på Id                         ║
        // ╚══════════════════════════════════════════════════════╝
        public static async Task Update(int id, string name, string username, string password, string role)
        {
            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE User SET Name = @name, Username = @username, Password = @password, Role = @role WHERE Id = @id";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : CRUD_User                             ║
        // ║  METODE      : Delete()                              ║
        // ║  BESKRIVELSE : Sletter bruger i databaseasen         ║
        // ║                baseret på Id                         ║
        // ╚══════════════════════════════════════════════════════╝

        public static async Task Delete(int id)
        {
            using var connection = Database.GetConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM User WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            await command.ExecuteNonQueryAsync();
        }
    }
}
