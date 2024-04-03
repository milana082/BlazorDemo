using BlazorApp1.Models;
using CrudOperations.Models;


namespace BlazorApp1.Services
{
    public interface INewOpenApiServices
    {
        Task<List<Item>> GetItems();
        //Task<List<Item>> Search(string? Query);
    }
}
