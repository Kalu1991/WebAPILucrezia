using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettiController : ControllerBase
    {
        private BigliettoContext _db;

        public BigliettiController(BigliettoContext db)
        {
            _db = db;

            //if (db.Biglietti.Count() == 0)
            //{
            //    _db.Biglietti.Add(new BigliettoConcerto()
            //    {
            //        Artista = "Beyoncee",
            //        Disponibile = false,
            //        Prezzo = 200
            //    });
            //    _db.SaveChanges();
            //}
        }
        // GET: api/Biglietti
        [HttpGet]
        public IEnumerable<BigliettoConcerto> GetAll()
        {
            return _db.Biglietti.AsNoTracking().ToList();
        }

        // GET: api/Biglietti/5
        [HttpGet("{id}", Name = "GetBiglietto")]
        public IActionResult GetById(int id)
        {
            var biglietto = _db.Biglietti.FirstOrDefault(b => b.ID == id);
            if (biglietto == null)
                return NotFound();
            else
                return new ObjectResult(biglietto);
        }

        // POST: api/Biglietti
        [HttpPost]
        public IActionResult Create([FromBody] BigliettoConcerto biglietto)
        {
            if (biglietto == null)
                return BadRequest();

            _db.Biglietti.Add(biglietto);
            _db.SaveChanges();
            return CreatedAtRoute("GetBiglietto", new { id = biglietto.ID }, biglietto);
        }

        // PUT: api/Biglietti/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BigliettoConcerto biglietto)
        {
            if (biglietto == null || biglietto.ID != id)
                return BadRequest();

            var big = _db.Biglietti.FirstOrDefault(b => b.ID == id);
            if (big  == null)
                return NotFound();

            big.Artista = biglietto.Artista;
            big.Prezzo = biglietto.Prezzo;
            big.Disponibile = biglietto.Disponibile;
            _db.Biglietti.Update(big);
            _db.SaveChanges();
            return new NoContentResult();
            
        }

        // PUT: api/Biglietti/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] BigliettoConcerto biglietto)
        {
            if (biglietto == null || biglietto.ID != id)
                return BadRequest();

            var big = _db.Biglietti.FirstOrDefault(b => b.ID == id);
            if (big == null)
                return NotFound();

            big.Artista = biglietto.Artista;
            big.Prezzo = biglietto.Prezzo;
            big.Disponibile = biglietto.Disponibile;
            _db.Biglietti.Update(big);
            _db.SaveChanges();
            return new NoContentResult();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var big = _db.Biglietti.FirstOrDefault(b => b.ID == id);
            if (big == null)
                return NotFound();

            _db.Biglietti.Remove(big);
            _db.SaveChanges();
            return new NoContentResult();
        }
    }
}
