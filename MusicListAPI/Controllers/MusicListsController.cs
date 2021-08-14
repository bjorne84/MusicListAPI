using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicListAPI.Data;
using MusicListAPI.Models;

namespace MusicListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicListsController : ControllerBase
    {
        private readonly MusicListContext _context;

        public MusicListsController(MusicListContext context)
        {
            _context = context;
        }

        // GET: api/MusicLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicList>>> GetMusicLists()
        {
            return await _context.MusicLists.ToListAsync();
        }

        // GET: api/MusicLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicList>> GetMusicList(int id)
        {
            var musicList = await _context.MusicLists.FindAsync(id);

            if (musicList == null)
            {
                return NotFound();
            }

            return musicList;
        }

        // PUT: api/MusicLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicList(int id, MusicList musicList)
        {
            if (id != musicList.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MusicLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicList>> PostMusicList(MusicList musicList)
        {
            _context.MusicLists.Add(musicList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicList", new { id = musicList.Id }, musicList);
        }

        // DELETE: api/MusicLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicList(int id)
        {
            var musicList = await _context.MusicLists.FindAsync(id);
            if (musicList == null)
            {
                return NotFound();
            }

            _context.MusicLists.Remove(musicList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicListExists(int id)
        {
            return _context.MusicLists.Any(e => e.Id == id);
        }
    }
}
