using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncourgingNoteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EncourgingNoteAPI.Controllers
{
    [Route("api/encouragingnote")]
    [ApiController]
    public class EncourgingNoteController : ControllerBase
    {
        private readonly EncourgingNoteContext _context;

        public EncourgingNoteController(EncourgingNoteContext context)
        {
            _context = context;

            if (_context.EncourgingNoteItems.Count() == 0)
            {
                // Create a new EncourgingNoteItem if collection is empty,
                // which means you can't delete all EncourgingNoteItems.
                var newNote =  new EncourgingNoteItem
                {
                    Text = "Have a great day!"
                };
                //set NoteNumber to the note's id
                newNote.NoteNumber = newNote.Id;

                _context.EncourgingNoteItems.Add(newNote);

                _context.SaveChanges();
            }
        }

        // GET: api/encouragingnote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncourgingNoteItem>>> GetEncourgingNoteItems()
        {
            return await _context.EncourgingNoteItems.ToListAsync();
        }

        // GET: api/encouragingnote/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<EncourgingNoteItem>> GetEncourgingNoteItem(long id)
        {
            var encourgingNoteItem = await _context.EncourgingNoteItems.FindAsync(id);
            
            //set NoteNumber to the note's id
            encourgingNoteItem.NoteNumber = encourgingNoteItem.Id;

            if (encourgingNoteItem == null)
            {
                return NotFound();
            }

            return encourgingNoteItem;
        }

        // POST: api/encouragingnote
        [HttpPost]
        public async Task<ActionResult<EncourgingNoteItem>> PostTodoItem(EncourgingNoteItem encourgingNoteItem)
        {
            _context.EncourgingNoteItems.Add(encourgingNoteItem);

            //set NoteNumber to the note's id
            encourgingNoteItem.NoteNumber = encourgingNoteItem.Id;

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncourgingNoteItem", new { id = encourgingNoteItem.Id }, encourgingNoteItem);
        }

        // PUT: api/encouragingnote/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, EncourgingNoteItem encourgingNoteItemodoItem)
        {
            if (id != encourgingNoteItemodoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(encourgingNoteItemodoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/encouragingnote/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EncourgingNoteItem>> DeleteTodoItem(long id)
        {
            var EncourgingNoteItem = await _context.EncourgingNoteItems.FindAsync(id);
            if (EncourgingNoteItem == null)
            {
                return NotFound();
            }

            _context.EncourgingNoteItems.Remove(EncourgingNoteItem);
            await _context.SaveChangesAsync();

            return EncourgingNoteItem;
        }
    }
}