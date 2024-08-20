using back_app_sr_Application.User.ViewModel;
using MediatR;
using Newtonsoft.Json;

namespace back_app_sr_Application.User.Query.GetUserById;

public class GetUserByIdQuery : IRequest<UserResponseViewModel>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}