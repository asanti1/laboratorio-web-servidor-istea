using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IComandaRepository ComandaRepository { get; }

        public IEmpleadoRepository EmpleadoRepository { get; }

        public IPedidoRepository PedidoRepository { get; }

        public ISectorRepository SectorRepository { get; }

        private readonly RestauranteContext _context;
        private RestauranteContext restauranteContext;
        private object value;
        public UnitOfWork(RestauranteContext context, IComandaRepository comandaRepository, IEmpleadoRepository empleadoRepository, IPedidoRepository pedidoRepository, ISectorRepository sectorRepository)
        {
            _context = context;
            ComandaRepository = comandaRepository;
            EmpleadoRepository = empleadoRepository;
            PedidoRepository = pedidoRepository;
            SectorRepository = sectorRepository;
        }

        /*
        public UnitOfWork(RestauranteContext RestauranteContext, IComandaRepository comandaRepository, IEmpleadoRepository empleadoRepository, IPedidoRepository pedidoRepository, ISectorRepository sectorRepository, object value)
        {
            this.restauranteContext = restauranteContext;
            ComandaRepository = comandaRepository;
            EmpleadoRepository = empleadoRepository;
            PedidoRepository = pedidoRepository;
            SectorRepository = sectorRepository;
            this.value = value;
        }
        */

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
