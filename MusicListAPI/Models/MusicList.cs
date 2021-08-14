using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicListAPI.Models
{
    public class MusicList
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Titel { get; set; }
        public int Length { get; set; }
        public string Category { get; set; }
    }
}
