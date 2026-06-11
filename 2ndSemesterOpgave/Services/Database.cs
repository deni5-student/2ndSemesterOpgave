using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Services
{
    public class Database
    {
        private static string _dbPath = "skole.db";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        public static void Initialize()
        {
            using var connection = GetConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS User (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Courses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Content TEXT NOT NULL,
                    UserId INTEGER NOT NULL,
                    FOREIGN KEY(UserId) REFERENCES Uses(Id)
                );

                CREATE TABLE IF NOT EXISTS UnderFlow (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Content TEXT NOT NULL,
                    FlowId INTEGER NOT NULL,
                    FOREIGN KEY(FlowId) REFERENCES Courses(Id)
                    );

                INSERT OR IGNORE INTO User (Name, Username, Password, Role) VALUES ('Administrator','admin', '1234', 'Administrator');

            ";
            command.ExecuteNonQuery();
        }
    }
}
