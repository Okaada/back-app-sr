using back_app_sr_Application.Item.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.Item.Command.UpdateItem;

public class UpdateItemCommand : IRequest<ItemResponseViewModel>
{
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}