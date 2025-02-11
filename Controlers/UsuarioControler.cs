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
    public class SmartCash(ApplicationDbContext context) : ControllerBase 
    {
        public readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<List<Usuario>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChangesAsync();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario.Id != id)
            {
                return BadRequest();
            } else {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id, [FromBody] Usuario usuario)
        {
            var deleteUsuario = await _context.Usuarios.FindAsync(id);
            if (usuario.Id == id)
            {
                return BadRequest();
            } else {
                _context.Usuarios.Remove(deleteUsuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
        }
    }

}
