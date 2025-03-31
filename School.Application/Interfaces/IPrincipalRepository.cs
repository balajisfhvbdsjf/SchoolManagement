namespace School.Application.Interfaces
{
    using School.Domain.Entities;

    public interface IPrincipalRepository
    {
        Task<bool> AnyPrincipalExistsAsync();
        Task<bool> AddPrincipalAsync(Principal principal);
        Task<Principal?> GetPrincipalByEmailAndPasswordAsync(string email, string encryptedPassword);

    }
}
