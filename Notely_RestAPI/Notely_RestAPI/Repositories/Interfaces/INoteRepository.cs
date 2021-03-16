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

        long AddNote(Note note);

        bool UpdateNote(Note note);

        bool DeleteNote(long id);
    }
}
