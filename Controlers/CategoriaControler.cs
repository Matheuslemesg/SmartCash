using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartCash.ApplicationDBContext;
using SmartCash.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SmartCash.ApiController
{
        
    [ApiController]
    [Route("[controller]")]
    public class Categorias(ApplicationDbContext context) : ControllerBase 
    {
        public readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<List<Categoria>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Categoria>> Get(string descricao)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Descricao == descricao);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria.Id != id)
            {
                return BadRequest();
            } else {
                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(categoria);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id, [FromBody] Categoria categoria)
        {
            var deleteCategoria = await _context.Categorias.FindAsync(id);
            if (categoria.Id == id)
            {
                return BadRequest();
            } else {
                _context.Categorias.Remove(deleteCategoria);
                await _context.SaveChangesAsync();

                return Ok("Categoria excluida com sucesso!");
            }
        }
    }

}
