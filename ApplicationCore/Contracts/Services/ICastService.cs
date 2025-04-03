using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface ICastService
{
    public Task<Cast?> GetCastDetailsAsync(int id);
}