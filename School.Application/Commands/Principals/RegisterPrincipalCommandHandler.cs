using MediatR;
using School.Application.Interfaces;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Commands.Principals
{
    public class RegisterPrincipalCommandHandler : IRequestHandler<RegisterPrincipalCommand, bool>
    {
        private readonly IPrincipalRepository _repo;
        private readonly IEncryptionService _encryptionService;
        private readonly IFileUploadService _fileUploadService;

        public RegisterPrincipalCommandHandler(IPrincipalRepository repo,
                                               IEncryptionService encryptionService,
                                               IFileUploadService fileUploadService)
        {
            _repo = repo;
            _encryptionService = encryptionService;
            _fileUploadService = fileUploadService;
        }

        public async Task<bool> Handle(RegisterPrincipalCommand request, CancellationToken cancellationToken)
        {
            // Check if a principal already exists
            var exists = await _repo.AnyPrincipalExistsAsync();
            if (exists) return false;

            var dto = request.Principal;

            var encryptedPassword = _encryptionService.Encrypt(dto.Password);
            var photoPath = await _fileUploadService.SaveFileAsync(dto.Photo, "uploads/principals");

            var principal = new Principal
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = encryptedPassword,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                PhotoPath = photoPath
            };

            return await _repo.AddPrincipalAsync(principal);
        }
    }

}
