using back_app_sr_Application.User.ViewModel;
using MediatR;

namespace back_app_sr_Application.User.Command.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
