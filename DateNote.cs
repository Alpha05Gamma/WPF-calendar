using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class DateNote
    {
        private static string filePath = JSON.FilePath;
        public static List<DateNote> days = JSON.Deserialize<List<DateNote>>(filePath);
        public DateTime day { get; set; }
        public List<Note> notes { get; set; }
    }
    internal class Note
    {
        public string name { get; set; }
        public string iconPath { get; set; }
        public bool isSelected { get; set; }
    }
}
