using AutoMapper;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

public class ComandaService : IComandaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ComandaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Comanda> Get(int idComanda)
    {
        var comanda = await _unitOfWork.ComandaRepository.GetId(idComanda);

        if (comanda == null)
        {
            throw new KeyNotFoundException($"No se encontró una comanda con el ID {idComanda}");
        }

        return comanda;
    }

    public async Task<ComandaGetDTO> ObtenerComandaPorId(int idComanda)
    {
        try
        {
            var comanda = await _unitOfWork.ComandaRepository.ObtenerComandaPorId(idComanda);

            return comanda;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Comanda> Add(ComandaPostDTO comanda)
    {
        return await _unitOfWork.ComandaRepository.AgregarComanda(comanda);
    }

    public async Task<Comanda> Update(int idComanda, Comanda comanda)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int idComanda)
    {
        Comanda comanda = await _unitOfWork.ComandaRepository.GetId(idComanda);
        _unitOfWork.ComandaRepository.Delete(comanda);
        var result = await _unitOfWork.Save();
        return result > 0;
    }
}