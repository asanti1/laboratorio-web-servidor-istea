using AutoMapper;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;
using laboratorio_web_api_istea.DTO.Pedido;
using laboratorio_web_api_istea.Service.Interface;

namespace laboratorio_web_api_istea.Service;

public class ComandaService : IComandaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ComandaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

    public async Task<ComandaResponseDTO> ObtenerComandaPorId(int idComanda)
    {
        try
        {
            var comanda = await _unitOfWork.ComandaRepository.ObtenerComandaPorId(idComanda);
            ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO> (comanda);
            return comandaDTO;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<ComandaResponseDTO> Add(ComandaPostDTO comanda)
    {
        try
        {
            var comandaEntity = await _unitOfWork.ComandaRepository.AgregarComanda(comanda);

            // Se mapea la entidad Comanda a ComandaResponseDTO utilizando AutoMapper
            ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO>(comandaEntity);

            return comandaDTO;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ComandaResponseDTO> Update(int idComanda, ComandaPostDTO comanda)
    {
        try
        {
            // Obtenemos la entidad existente por su ID
            var comandaEntity = await _unitOfWork.ComandaRepository.ObtenerComandaPorId(idComanda);
            if (comandaEntity == null)
            {
                throw new KeyNotFoundException($"Comanda with ID {idComanda} not found.");
            }

            // Se actualiza la entidad en el repositorio
            await _unitOfWork.ComandaRepository.ActualizarComanda(comandaEntity);

            // Se mapea la entidad Comanda a ComandaResponseDTO utilizando AutoMapper
            ComandaResponseDTO comandaDTO = _mapper.Map<ComandaResponseDTO>(comandaEntity);

            return comandaDTO;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }



    public async Task<bool> Delete(int idComanda)
    {
        Comanda comanda = await _unitOfWork.ComandaRepository.GetId(idComanda);
        _unitOfWork.ComandaRepository.Delete(comanda);
        var result = await _unitOfWork.Save();
        return result > 0;
    }
}