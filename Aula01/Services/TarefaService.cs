using Aula01.Data;
using Aula01.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Services
{
    public class TarefaService
    {
        private readonly AppDbContext _context;

        // Método Construtor
        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> GetAllAsync(bool? concluida = null)
        {
            var query = _context.Tarefas.AsQueryable();

            if (concluida is not null)
            {
                query = query.Where(t => t.Concluida == concluida);
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(Guid id)
            => await _context.Tarefas.FindAsync(id);

            public async Task<Tarefa> CreatyAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
    }
}
