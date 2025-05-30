using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        // GET: api/Produtos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Produtos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produtos = _db.Produtos.FirstOrDefault(c => c.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        // POST: api/Produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Produto inválida.");
            }

            _db.Produtos.Add(produtos);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { produtos });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtos)
        {
            if (!ModelState.IsValid || id != produtos.Id)
            {
                return BadRequest("Produtos com problemas");
            }

            _db.Produtos.Update(produtos);
            _db.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produtos = _db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _db.Produtos.Remove(produtos);
            _db.SaveChanges();
            return NoContent();
        }
    }
}