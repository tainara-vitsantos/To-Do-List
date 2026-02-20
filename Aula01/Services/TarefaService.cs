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

        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> UpdateAsync(Guid id, Action<Tarefa> updateAction)
        {
            var tarefa = await GetByIdAsync(id);
            if (tarefa is null) return false;

            updateAction(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var tarefa = await GetByIdAsync(id);
            if (tarefa is null) return false;

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
