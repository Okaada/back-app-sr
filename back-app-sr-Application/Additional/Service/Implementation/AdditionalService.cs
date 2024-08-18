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

    public async Task<IEnumerable<GetAdditionalViewModel>> GetAllAdditionals()
    {
        return _mapper.Map<IEnumerable<GetAdditionalViewModel>>(await _additionalRepository.GetAll());
    }
    
    public async Task<GetAdditionalViewModel> GetAdditionalById(int id)
    {
        var additional = await _additionalRepository.GetById(id);
        return _mapper.Map<GetAdditionalViewModel>(additional);
    }


    public async Task<DeleteAdditionalViewModel> DeleteAdditional(int id)
    {
        var additional = await _additionalRepository.GetById(id);
        if (additional == null)
            throw new Exception("Adicional não encontrado");

        var deleteAdditionalViewModel = _mapper.Map<DeleteAdditionalViewModel>(additional); 
        
        _additionalRepository.Delete(additional);
        _uow.Commit();

        return deleteAdditionalViewModel;
    }
    
    public async Task<UpdateAdditionalViewModel> UpdateAdditional(int id, string name, decimal value)
    {
        var additional = await _additionalRepository.GetById(id);
        if (additional == null)
            throw new Exception("Adicional não encontrado");
        
        additional.Name = name;
        additional.Value = value;
        
        _additionalRepository.Update(additional);
        _uow.Commit();

        return _mapper.Map<UpdateAdditionalViewModel>(additional);
    }
}