using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Journal
    {
        public int ID { get; set; }

        public string Book { get; set; } = string.Empty;

        public string Chapter { get; set; } = string.Empty;
        public string Verse { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}