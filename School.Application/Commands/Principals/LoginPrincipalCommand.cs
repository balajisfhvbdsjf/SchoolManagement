using MediatR;
using School.Application.DTOs;

namespace School.Application.Commands.Principals
{
    public class LoginPrincipalCommand : IRequest<LoginResultDto?>
    {
        public LoginDto LoginDto { get; set; }

        public LoginPrincipalCommand(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }

}
