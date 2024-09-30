using laboratorio_web_api_istea.DAL.Repository.Interfaces;

namespace laboratorio_web_api_istea.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IComandaRepository ComandaRepository { get; }
        IEmpleadoRepository EmpleadoRepository { get; }

        IPedidoRepository PedidoRepository { get; }

        ISectorRepository SectorRepository { get; }

        IMesaRepository MesaRepository { get; }

        Task<int> Save();
    }
}