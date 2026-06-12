using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Class
{
    public class Flow
    {
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : Flow                                  ║
        // ║  METODE      :                                       ║
        // ║  BESKRIVELSE : klasse for Flow der bruges til at     ║
        // ║                håndtere data mellem database og UI   ║
        // ╚══════════════════════════════════════════════════════╝
        public int Id { get; set; }  // den får en Id så man nemmere kan håndtere dem
        public string Title { get; set; }  // titel til flowet
        public string Content { get; set; }  // string til at indholde tekseten i flowet
        public int UserId { get; set; }   // Id på den lærer der opretter flowet
    }
}
