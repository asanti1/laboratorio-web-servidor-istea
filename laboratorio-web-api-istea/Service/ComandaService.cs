using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace laboratorio_web_api_istea.Service;

public class ComandaService : IComandaService
{
    private readonly IUnitOfWork _unitOfWork;
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

    public async Task<Comanda> Add(Comanda comanda)
    {
        await _unitOfWork.ComandaRepository.Add(comanda);
        var result = await _unitOfWork.Save();

        if (result == 0)
            return null;

        Comanda comandaCreada = await _unitOfWork.ComandaRepository.GetId(comanda.IdComanda);
        return comandaCreada;
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