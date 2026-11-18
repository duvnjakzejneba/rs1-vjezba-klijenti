using KlijentiVjezba.Data;
using KlijentiVjezba.DTOs;
using KlijentiVjezba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KlijentiVjezba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlijentController(AppDbContext db) : ControllerBase
    {
        private static KlijentResponse Mapiraj(Klijent k)
        {
            return new KlijentResponse()
            {
                Id = k.Id,
                Naziv = k.Naziv,
                DatumKreiranja = k.DatumKreiranja,
                Email = k.Email,
                Grad = k.Grad
            };
        }

        [HttpGet]
        public async Task<List<KlijentResponse>> GetAll(CancellationToken ct)
        {
            List<Klijent> klijenti = await db.Klijenti.ToListAsync(ct);
            return klijenti.Select(Mapiraj).ToList(); 
        }

        [HttpGet("{id:int}")]
        public async Task<KlijentResponse> GetById(int id, CancellationToken ct)
        {
            Klijent klijent = await db.Klijenti.FirstOrDefaultAsync(c => c.Id == id, ct);
            return Mapiraj(klijent);
        }
         
        [HttpPost]
        public async Task<ActionResult<KlijentResponse>> AddNew(KlijentDodajRequest k, CancellationToken ct)
        {
            Klijent klijent = new Klijent
            {
                DatumKreiranja = DateOnly.FromDateTime(DateTime.Now), 
                Email = k.Email,
                Naziv = k.Naziv,
                Grad = k.Grad
            };

            db.Klijenti.Add(klijent);
            await db.SaveChangesAsync(ct);

            return Ok(Mapiraj(klijent)); 
        }
    }
}