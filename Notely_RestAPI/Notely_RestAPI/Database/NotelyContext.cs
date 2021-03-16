using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotelyRestApi.Models;

namespace NotelyRestApi.Database
{
    public class NotelyContext : DbContext
    {
        public NotelyContext(DbContextOptions<NotelyContext> options): base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
