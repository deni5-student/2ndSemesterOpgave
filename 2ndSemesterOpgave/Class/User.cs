using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Class
{
    public class User
    {
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : User                                  ║
        // ║  METODE      :                                       ║
        // ║  BESKRIVELSE : klasse for User der bruges til at     ║
        // ║                håndtere data mellem database og UI   ║
        // ╚══════════════════════════════════════════════════════╝
        public int Id { get; set; }   // den får en Id så man nemmere kan håndtere dem
        public string Name { get; set; }  // Navn til User
        public string Username { get; set; } // string til at indholde tekseten i Username
        public string Password { get; set; } // string til at indholde tekseten i Password
        public string Role { get; set; } // string til at indholde tekseten i Role

    }
}
