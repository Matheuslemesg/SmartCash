using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartCash.ApplicationDBContext;
using SmartCash.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SmartCash.DTOs;

namespace SmartCash.ApiController
{
        
    [ApiController]
    [Route("[controller]")]
    public class Transacoes(ApplicationDbContext context) : ControllerBase 
    {
        public readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<List<Transacao>> Get()
        {
            return await _context.Transacoes.ToListAsync();
        }

        [HttpGet("{tipo}")]
        public async Task<ActionResult<Transacao>> Get(int tipo)
        {
            var transacao = await _context.Transacoes.FirstOrDefaultAsync(transacao => transacao.Tipo == tipo);
            return Ok(transacao);
        }

        [HttpPost]
        public async Task<ActionResult<Transacao>> Post([FromBody] TransacaoDTO transacaoDto)
        {
            var transacao = new Transacao(transacaoDto.Tipo, transacaoDto.Descricao, transacaoDto.Valor);
            _context.Transacoes.Add(transacao);
            _context.SaveChangesAsync();

            return Ok(transacaoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Transacao>> Put(int id, [FromBody] Transacao transacao)
        {
            if (transacao.Id != id)
            {
                return BadRequest();
            } else {
                _context.Entry(transacao).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(transacao);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Transacao>> DeleteTransacao(int id, [FromBody] Transacao transacao)
        {
            var deleteTransacao = await _context.Transacoes.FindAsync(id);
            if (transacao.Id == id)
            {
                return BadRequest();
            } else {
                _context.Transacoes.Remove(deleteTransacao);
                await _context.SaveChangesAsync();

                return Ok("Transaçao excluida com sucesso!");
            }
        }
    }

}
