using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class SectorRepository : Repository<Sectore>, ISectorRepository
    {
        public SectorRepository(RestauranteContext context) : base(context)
        {

        }
    }
}
