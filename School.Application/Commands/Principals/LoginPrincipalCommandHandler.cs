using MediatR;
using School.Application.DTOs;
using School.Application.Interfaces;
using School.Domain.Entities;

namespace School.Application.Commands.Principals
{
    public class LoginPrincipalCommandHandler : IRequestHandler<LoginPrincipalCommand, LoginResultDto?>
    {
        private readonly IPrincipalRepository _repo;
        private readonly IEncryptionService _encryption;
        private readonly IJwtService _jwt;

        public LoginPrincipalCommandHandler(IPrincipalRepository repo, IEncryptionService encryption, IJwtService jwt)
        {
            _repo = repo;
            _encryption = encryption;
            _jwt = jwt;
        }

        public async Task<LoginResultDto?> Handle(LoginPrincipalCommand request, CancellationToken cancellationToken)
        {
            var encrypted = _encryption.Encrypt(request.LoginDto.Password);
            var principal = await _repo.GetPrincipalByEmailAndPasswordAsync(request.LoginDto.Email, encrypted);

            if (principal == null) return null;

            return new LoginResultDto
            {
                Token = _jwt.GenerateToken(principal),
                FullName = principal.FullName,
                PhotoPath = principal.PhotoPath
            };
        }
    }

}
