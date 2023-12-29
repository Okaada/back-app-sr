using back_app_sr_Application.Tab.Business.Interface;
using back_app_sr_Application.Tab.ViewModel;
using MediatR;

namespace back_app_sr_Application.Tab.Command.InsertOrderCommand;

public class InsertOrderCommandHandler : IRequestHandler<InsertOrderCommand, Unit>
{
    private readonly ITabOrderService _tabOrderService;

    public InsertOrderCommandHandler(ITabOrderService tabOrderService)
    {
        _tabOrderService = tabOrderService;
    }

    public Task<Unit> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
    {
        foreach (var order in request.Order)
            _tabOrderService.AddOrder(request.TabId, order);

        return Task.FromResult(Unit.Value);
    }
}