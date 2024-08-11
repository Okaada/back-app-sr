using AutoMapper;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr_Application.Additional.Service.Implementation;

public class AdditionalService : IAdditionalService
{
    private readonly IAdditionalRepository _additionalRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public AdditionalService(IAdditionalRepository additionalRepository, IUnitOfWork uow, IMapper mapper)
    {
        _additionalRepository = additionalRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<string> CreateAdditional(string name, decimal value)
    {
        var additional = new AdditionalModel(name, value);

        _additionalRepository.Add(additional);
        _uow.Commit();

        return $"Adicional criado com sucesso. '{additional.Name}' , R$ '{additional.Value}'";
    }

    public async Task<IEnumerable<AdditionalViewModel>> GetAllAdditionals()
    {
        return _mapper.Map<IEnumerable<AdditionalViewModel>>(await _additionalRepository.GetAll());
    }
    
    public async Task<AdditionalViewModel> GetAdditionalById(int additionalId)
    {
        return _mapper.Map<AdditionalViewModel>(await _additionalRepository.GetById(additionalId));
    }

    
    public async Task<bool> DeleteAdditional(int additionalId)
    {
        var additional = await _additionalRepository.GetById(additionalId);
        if (additional == null)
            return false;
        
        _additionalRepository.Delete(additional);
        _uow.Commit();

        return true;
    }
    
    public async Task<bool> UpdateAdditional(int additionalId, string name, decimal value)
    {
        var additional = await _additionalRepository.GetById(additionalId);
        if (additional == null)
            return false;
        
        additional.Name = name;
        additional.Value = value;
        
        _additionalRepository.Update(additional);
        _uow.Commit();

        return true;
    }
}