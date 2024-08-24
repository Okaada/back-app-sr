using AutoMapper;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Additional.ViewModel;
using back_app_sr.Domain.Models.Items;
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

    public async Task<CreateAdditionalViewModel> CreateAdditional(string name, decimal value)
    {
        var newAdditional = new AdditionalModel(name, value);
        await _additionalRepository.Add(newAdditional);
        
        _uow.Commit();

        return _mapper.Map<CreateAdditionalViewModel>(newAdditional);
    }

    public async Task<IEnumerable<AdditionalResponseViewModel>> GetAllAdditionals()
    {
        return _mapper.Map<IEnumerable<AdditionalResponseViewModel>>(await _additionalRepository.GetAll());
    }
    
    public async Task<AdditionalResponseViewModel> GetAdditionalById(int additionalId)
    {
        var additional = await _additionalRepository.GetById(additionalId);

        if (additional == null)
            return new AdditionalResponseViewModel();
            
        return _mapper.Map<AdditionalResponseViewModel>(additional);
    }


    public async Task<DeleteAdditionalViewModel> DeleteAdditional(int additionalId)
    {
        var additional = await _additionalRepository.GetById(additionalId);
        if (additional == null)
            throw new KeyNotFoundException($"Nenhum adicional encontrado com ID {additionalId}");

        var deleteAdditionalViewModel = _mapper.Map<DeleteAdditionalViewModel>(additional); 
        
        _additionalRepository.Delete(additional);
        _uow.Commit();

        return deleteAdditionalViewModel;
    }
    
    public async Task<AdditionalResponseViewModel> UpdateAdditional(int additionalId, string name, decimal value)
    {
        var additional = await _additionalRepository.GetById(additionalId);
        if (additional == null)
            throw new KeyNotFoundException($"Nenhum adicional encontrado com ID {additionalId}");

        additional.UpdateAdditional(name, value);
        
        _additionalRepository.Update(additional);
        _uow.Commit();

        return _mapper.Map<AdditionalResponseViewModel>(additional);
    }
}