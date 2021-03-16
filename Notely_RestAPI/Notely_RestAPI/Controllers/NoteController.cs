using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using NotelyRestApi.Models;
using NotelyRestApi.Repositories.Implementations;
using NotelyRestApi.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotelyRestApi.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository repository;

        public NoteController(INoteRepository repository_)
        {
            repository = repository_;
        }

        // GET: api/<NoteController>
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNotes()
        {
            return repository.GetNotes().ToList();  
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteById(long id)
        {
            return repository.GetNoteById(id);
        }

        // POST api/<NoteController>
        [HttpPost]
        public ActionResult<Note> AddNote(Note note)
        {
            note.CreatedDate = DateTime.Now;
            note.LastModified = DateTime.Now;
            repository.AddNote(note);
            return note;
        }

        // PUT api/<NoteController>/5
        [HttpPut]
        public ActionResult<Note> UpdateNote(Note note)
        {
            note.LastModified = DateTime.Now;
            repository.UpdateNote(note);
            return note;
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public ActionResult<Note> DeleteNote(long id)
        {
            repository.DeleteNote(id);
            return repository.GetNoteById(id);  
        }
    }
}
