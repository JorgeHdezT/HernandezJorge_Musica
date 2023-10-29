using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HernandezJorge_Musica.Data;
using HernandezJorge_Musica.Models;

namespace HernandezJorge_Musica.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ChinookContext _context;

        public ArtistsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: Artists
        // GET: Artists
        public async Task<IActionResult> Index()
        {
            var artists = await _context.Artists
             .OrderByDescending(a => a.Name)
             .Take(15)
             .ToListAsync();

            return View(artists);
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                // Calcula el próximo ID basado en el número de registros existentes en la tabla "Artist"
                var maxId = _context.Artists.Max(a => (int?)a.ArtistId) ?? 0;
                var nextId = maxId + 1;

                // Asigna el nuevo ID al artista
                artist.ArtistId = nextId;

                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,Name")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'ChinookContext.Artists'  is null.");
            }
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                var albumDel = _context.Albums.Where(a => a.ArtistId == id); //Guardo los albums con el id del artista
                _context.Albums.RemoveRange(albumDel); //Ahora borro todos los albums con ese ID de la lista.
                _context.Artists.Remove(artist); // Y ahora borro el artista, que ya no tiene ningun album asociado y no da error.
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return (_context.Artists?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }

        // GET: Artists/DiscosArtista
        public async Task<IActionResult> DiscosArtista(int? id)
        {

            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound(); //
            }

            // Obtén la lista de discos del artista
            var albums = await _context.Albums
                .Where(a => a.ArtistId == artist.ArtistId)
                .ToListAsync();

            return View(albums);
        }



        //Get: Crear Comentario

        public async Task<IActionResult> CrearComentarioAsync(int id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View();
        }
        //Post: Create Feedback

        //[HttpPost, ActionName("CrearComentario")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CrearComentario([Bind("Name")] Artist artist)
        //{
        //    //if (ModelState.IsValid)
        //    //{


        //    //// Recoge el comentario seleccionado
        //    //// Le asigna la puntuacion y recoge las estrellas.

        //    //    _context.Add(artist);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}

        //    return View(Details);
        //}

    }
}