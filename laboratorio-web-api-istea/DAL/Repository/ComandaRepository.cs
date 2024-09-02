using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        public ComandaRepository(RestauranteContext context) : base(context)
        {

        }
    }
}
