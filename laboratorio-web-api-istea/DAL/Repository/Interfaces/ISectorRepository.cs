using laboratorio_web_api_istea.DAL.Models;


namespace laboratorio_web_api_istea.DAL.Repository.Interfaces
{
    public interface ISectorRepository : IRepository<Sectore>
    {
        Task<Sectore> GetSectorByDescription(string description);

    }
}
