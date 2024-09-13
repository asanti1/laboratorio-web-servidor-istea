using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.DAL.Repository
{
    public class SectorRepository : Repository<Sectore>, ISectorRepository
    {
        public SectorRepository(RestauranteContext context) : base(context)
        {
        }

        async Task<Sectore> ISectorRepository.GetSectorByDescription(string description)
        {
            try
            {
                var newSector = await _context.Sectores
                    .FirstOrDefaultAsync(s => s.Descripcion == description);

                return newSector;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}