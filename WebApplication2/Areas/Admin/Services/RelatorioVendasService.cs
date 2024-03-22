using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;
        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.DataPedido >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.DataPedido <= maxDate.Value);
            }
            return await resultado.OrderByDescending(x=> x.DataPedido).ToListAsync();
        }
    }
}
