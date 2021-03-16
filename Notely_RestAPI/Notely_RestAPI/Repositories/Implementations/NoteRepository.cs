using NotelyRestApi.Database;
using NotelyRestApi.Repositories.Interfaces;
using NotelyRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotelyRestApi.Repositories.Implementations
{
    public class NoteRepository : INoteRepository
    {
        private NotelyContext context;

        public NoteRepository(NotelyContext context_)
        {
            context = context_;
        }

        public Note GetNoteById(long id)
        {
            return context.Notes.Find(id);
        }

        public IEnumerable<Note> GetNotes()
        {
            return context.Notes;
        }

        public void AddNote(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
        }

        public void UpdateNote(Note note)
        {
            context.Notes.Update(note);
            context.SaveChanges();
        }

        public void DeleteNote(long id)
        {
            Note note = context.Notes.Find(id);
            context.Notes.Remove(note);
            context.SaveChanges();
        }
    }
}
