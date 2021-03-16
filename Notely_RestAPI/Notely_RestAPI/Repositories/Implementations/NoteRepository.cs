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

        public long AddNote(Note note)
        {
            try
            {
                context.Notes.Add(note);
                context.SaveChanges();
                return note.Id;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdateNote(Note note)
        {
            try
            {
                Note oldNote = context.Notes.SingleOrDefault(x => x.Id == note.Id);

                if (oldNote != null)
                {
                    oldNote.Detail = note.Detail;
                    oldNote.Subject = note.Subject;
                    oldNote.IsDeleted = note.IsDeleted;
                    oldNote.LastModified = DateTime.Now;
                    context.Notes.Update(oldNote);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNote(long id)
        {
            try
            {
                Note note = context.Notes.Find(id);
                context.Notes.Remove(note);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
