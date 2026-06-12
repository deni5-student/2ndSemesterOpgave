using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndSemesterOpgave.Class
{
    public class UnderFlow
    {
        // ╔══════════════════════════════════════════════════════╗
        // ║  FORFATTER   : Dennis                                ║
        // ║  KLASSE      : UnderFlow                             ║
        // ║  METODE      :                                       ║
        // ║  BESKRIVELSE : klasse for UnderFlow der bruges til at║
        // ║                håndtere data mellem database og UI   ║
        // ╚══════════════════════════════════════════════════════╝
        public int Id { get; set; }         // den får en Id så man nemmere kan håndtere dem
        public string Title { get; set; }   // titel til flowet
        public string Content { get; set; }  // string til at indholde tekseten i flowet
        public int FlowId { get; set; }   // Id på den flow den tilhøre

    }
}
