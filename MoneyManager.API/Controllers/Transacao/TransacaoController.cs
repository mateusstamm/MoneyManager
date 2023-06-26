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
    public class TransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<TransacaoModel> transacoes = _context.Transacoes.Include(t => t.Categoria).ToList();
            return Ok(transacoes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TransacaoModel transacao = _context.Transacoes.Include(t => t.Categoria).FirstOrDefault(t => t.TransacaoID == id);

            if (transacao == null)
            {
                return NotFound();
            }

            return Ok(transacao);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransacaoModel transacao)
        {
            if (transacao.CategoriaID.HasValue)
            {
                transacao.Categoria = _context.Categorias.Find(transacao.CategoriaID);
            }

            _context.Transacoes.Add(transacao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = transacao.TransacaoID }, transacao);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TransacaoModel transacao)
        {
            if (id != transacao.TransacaoID)
            {
                return BadRequest();
            }

            if (transacao.CategoriaID.HasValue)
            {
                transacao.Categoria = _context.Categorias.Find(transacao.CategoriaID);
            }

            _context.Entry(transacao).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TransacaoModel transacao = _context.Transacoes.Find(id);

            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}