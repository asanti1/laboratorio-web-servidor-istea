using laboratorio_web_api_istea.DAL.Models;


namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface ISectorRepository : IRepository<Sectore>
    {
        Task<List<OperacionesPorSector>> GetOperacionesPorSector(string description);
        Task<Sectore> GetSectorByDescription(string description);
        Task<List<OperacionesPorSectorYEmpleado>> GetOperacionesPorSectorPorEmpleado();

        //Sobrecarga del metodo GetOperacionesPorSectorPorEmpleado.
        Task<List<OperacionesPorSectorPorEmpleado>> GetOperacionesPorSectorPorEmpleado(string descriptionSector);

    }
}
