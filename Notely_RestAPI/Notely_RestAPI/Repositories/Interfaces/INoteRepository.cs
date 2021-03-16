using NotelyRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotelyRestApi.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Note GetNoteById(long id);

        IEnumerable<Note> GetNotes();

        void AddNote(Note note);

        void UpdateNote(Note note);

        void DeleteNote(long id);
    }
}
