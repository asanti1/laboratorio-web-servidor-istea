﻿using AutoMapper;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DTO.Mesa;
using laboratorio_web_api_istea.Mappers;
using laboratorio_web_api_istea.Service.Interface;
namespace laboratorio_web_api_istea.Service;
public class MesaService : IMesaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MesaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<MesaResponseDTO>> GetMesas()
    {
        var mesas = await _unitOfWork.MesaRepository.GetMesas();
        return _mapper.Map<List<MesaResponseDTO>>(mesas);
    }

    public async Task CerrarMesa(string nombreMesa)
    {
        await _unitOfWork.MesaRepository.CerrarMesa(nombreMesa);
    }

    public async Task CambiarEstado(string nombreMesa, int idEstado)
    {
        await _unitOfWork.MesaRepository.CambiarEstado(nombreMesa, idEstado);
    }
}