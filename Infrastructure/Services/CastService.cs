using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Repositories;

namespace Infrastructure.Services;

public class CastService: ICastService
{
    private readonly ICastRepository castRepository;

    public CastService(ICastRepository castRepository)
    {
        this.castRepository = castRepository;
    }
    public async Task<Cast?> GetCastDetailsAsync(int id)
    {
        return await castRepository.GetByIdAsync(id);
    }
}