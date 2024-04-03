using CrudOperations.Models;

namespace BlazorApp1.Services
{
    public interface IBrandServices
    {
        Task<List<Brand>> GetBrands(string? query);
        Task<List<Brand>> PostBrand(Brand brand);
        //Task<ApiResponse<Brand>> PutBrand(int id, Brand brand);
        Task PutBrand(int id, Brand brand);
        Task<Brand> GetBrand(int id);
        Task<bool> DeleteBrand(int id);

    }
}
