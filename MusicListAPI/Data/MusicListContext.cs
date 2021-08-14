using Microsoft.EntityFrameworkCore;
using MusicListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicListAPI.Data
{
    public class MusicListContext :DbContext
    {
        public MusicListContext(DbContextOptions<MusicListContext> options) : base(options)
        {
            
        }

        public DbSet<MusicList> MusicLists { get; set; }
    }
}
