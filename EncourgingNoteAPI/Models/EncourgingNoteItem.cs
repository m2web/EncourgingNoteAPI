using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncourgingNoteAPI.Models
{
    public class EncourgingNoteItem
    {
        public int Id { get; set; }
        public int NoteNumber { get; set; }
        public string Text { get; set; }
    }
}
