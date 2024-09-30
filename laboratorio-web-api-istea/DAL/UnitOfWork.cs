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

        public IMesaRepository MesaRepository { get; }

        private readonly RestauranteContext _context;

        public UnitOfWork(RestauranteContext context, IComandaRepository comandaRepository,
            IEmpleadoRepository empleadoRepository, IPedidoRepository pedidoRepository,
            ISectorRepository sectorRepository, IMesaRepository mesaRepository)
        {
            _context = context;
            ComandaRepository = comandaRepository;
            EmpleadoRepository = empleadoRepository;
            PedidoRepository = pedidoRepository;
            SectorRepository = sectorRepository;
            MesaRepository = mesaRepository;
        }

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