using MoneyManager.API.Models;
using MoneyManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CategoriaModel> categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CategoriaModel categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaModel categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = categoria.CategoriaID }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoriaModel categoria)
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CategoriaModel categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
