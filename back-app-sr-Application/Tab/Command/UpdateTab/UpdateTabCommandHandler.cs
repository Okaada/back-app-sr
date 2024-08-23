using back_app_sr_Application.Tab.Command.CreateTab;
using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.Tab.ViewModel;
using FluentValidation;
using MediatR;

namespace back_app_sr_Application.Tab.Command.UpdateTab;

public class UpdateabCommandHandler : IRequestHandler<UpdateTabCommand, UpdateTabViewModel>
{
    private readonly ITabService _tabService;
    public UpdateabCommandHandler(ITabService service)
    {
        _tabService = service;
    }

    public async Task<UpdateTabViewModel> Handle(UpdateTabCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTabValidator();
        var validation = await validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
            throw new ValidationException("Error", validation.Errors);
        }
        
        var result = await _tabService.UpdateTab(request.Id, request.Name, 
            request.Status, request.TableNumber);
        
        return result;
    }
}