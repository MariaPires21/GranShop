using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GranShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        // GET: api/Categorias
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Categorias.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categoria = _db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // POST: api/Categorias
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Categoria inválida.");
            }

            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { categoria });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid || id != categoria.Id)
            {
                return BadRequest("Categoria com problemas");
            }

            _db.Categorias.Update(categoria);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
            return NoContent();
        }
    }
}