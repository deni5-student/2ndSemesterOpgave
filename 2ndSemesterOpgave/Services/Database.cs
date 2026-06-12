using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Services
{
    public class Database
    {
        private static string _dbPath = "skole.db";

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Database                              ║
        // ║  METODE      : GetConnection()                       ║
        // ║  BESKRIVELSE : opretter en forbindelse til           ║
        // ║                SQLite databasen - bruges af alle     ║
        // ║                CRUD klasser                          ║
        // ╚══════════════════════════════════════════════════════╝
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Database                              ║
        // ║  METODE      : Initialize()                          ║
        // ║  BESKRIVELSE : Den kører ved program start og        ║
        // ║                opretter tabeller samt en lokal       ║
        // ║                admin bruger for at kunne logge på    ║
        // ╚══════════════════════════════════════════════════════╝
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

                CREATE TABLE IF NOT EXISTS Flow (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Content TEXT NOT NULL,
                    UserId INTEGER NOT NULL,
                    FOREIGN KEY(UserId) REFERENCES User(Id)
                );

                CREATE TABLE IF NOT EXISTS UnderFlow (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Content TEXT NOT NULL,
                    FlowId INTEGER NOT NULL,
                    FOREIGN KEY(FlowId) REFERENCES Flow(Id)
                    );

                INSERT OR IGNORE INTO User (Name, Username, Password, Role) VALUES ('Administrator','admin', '1234', 'Administrator');

            ";
            command.ExecuteNonQuery();
        }
    }
}
