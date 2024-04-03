using CrudOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;
        

        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }


        // for get all data...............................................Done
        [HttpGet]
       
        public async Task<ApiResponse<Brand>> GetBrands([FromQuery(Name = "q")] string? query)
        {
            ApiResponse<Brand> apiResponse = new ApiResponse<Brand>() {
                Data = new List<Brand>()
            };
            try
            {
                var brands = _dbContext.Brands.Where(d => d.IsActive == 1);

                if(query is not null)
                {
                    brands = brands.Where(brands => brands.Name.Contains(query));
                                   
                }
                apiResponse.Data = await brands.ToListAsync();
                apiResponse.Message = "Get record successfully";
                apiResponse.Success = true;
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.Id = "";
            } catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                apiResponse.Success = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResponse.Id = "";
            }
            return apiResponse;
        }

        // for get data by id............................................Done
        [HttpGet]
        [Route("{id}")]

        public async Task<ApiResponse<Brand>> GetBrand(int id)
        {
            ApiResponse<Brand> apiResponse = new ApiResponse<Brand>()
            {
                Data = new List<Brand>()
            };
            try
            {
                var brand = await _dbContext.Brands.FindAsync(id);
                apiResponse.Data.Add(brand);
                apiResponse.Message = "Get record by id successfully";
                apiResponse.Success = true;
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.Id = "";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                apiResponse.Success = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResponse.Id = "";
            }
            return apiResponse;
            
        }

        // for post data.....into database table..........................Done
        [HttpPost]

        public async Task<ApiResponse<Brand>> PostBrand(Brand brand)
        {
            ApiResponse<Brand> apiResponse = new ApiResponse<Brand>()
            {
                Data = new List<Brand>()
            };
            try
            {
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                apiResponse.Data.Add(brand);
                apiResponse.Message = "Record Added successfully";
                apiResponse.Success = true;
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.Id = "";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                apiResponse.Success = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResponse.Id = "";
            }
            return apiResponse;
        }
        // for put (update) the data in database table row............
        [HttpPut]
       
        public async Task<ApiResponse<Brand>> PutBrand(int id ,Brand brand)
        {

            ApiResponse<Brand> apiResponse = new ApiResponse<Brand>()
            {
                Data = new List<Brand>()
            };
            try
            {
                if (id != brand.ID)
                {
                    apiResponse.Data = null;
                    apiResponse.Success = false;
                    apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    apiResponse.Message = "Unsuccessfull";
                    apiResponse.Id = "";
                    return apiResponse;
                }
                _dbContext.Entry(brand).State = EntityState.Modified;
                var result = await _dbContext.SaveChangesAsync();
                apiResponse.Data.Add(brand);
                apiResponse.Message = "Record Updated successfully";
                apiResponse.Success = true;
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.Id = "";
                if (brand == null)
                {
                    apiResponse.Success = false;
                    apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    apiResponse.Message = "Unsuccessfull";
                    apiResponse.Id = "";
                }
                return apiResponse;
            }
            catch (DbUpdateConcurrencyException)
            {
                apiResponse.Message = "Unsuccessfull";
                apiResponse.Success = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                apiResponse.Id = "";
                throw;
            }
           
        }
        // for delete...............................................done
        [HttpDelete]
        [Route("{id}")]

        public async Task<ApiResponse<Brand>> DeleteBrand(int id)
        {
            ApiResponse<Brand> apiResponse = new ApiResponse<Brand>()
            {
                Data = new List<Brand>()
            };
            try
            {
                if (_dbContext.Brands == null)
                {
                    apiResponse.Success = false;
                    apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    apiResponse.Message = "Unsuccessfull";
                    apiResponse.Id = "";
                    return apiResponse;
                }
                var brand = await _dbContext.Brands.FindAsync(id);
                if (brand == null)
                {
                    apiResponse.Success = false;
                    apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    apiResponse.Message = "Unsuccessfull";
                    apiResponse.Id = "";
                    return apiResponse;
                }
                _dbContext.Brands.Remove(brand);
                var result = await _dbContext.SaveChangesAsync();
                apiResponse.Data.Add(brand);
                apiResponse.Message = "Record Deleted successfully";
                apiResponse.Success = true;
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.Id = "";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                apiResponse.Success = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResponse.Id = "";
            }
            return apiResponse;
        }

    }
}
