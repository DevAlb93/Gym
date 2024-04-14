using Database.EF;
using Database.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("[controller]")]
    public class GymController : ControllerBase
    {
        ApplicationDbContext _applicationDbContext;
        public GymController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        [HttpGet("/categories")]
        public List<Category> GetCategories()
        {
            var categories = _applicationDbContext.Categories.ToList();
            return categories;
        }

        [HttpPost("/categories")]
        public void CreateCategory(string name )
        {
            var category = new Category() { 
                Description = "Test",
                Name = name
            };
            //Krijimi i nje Kategorie te re 
            _applicationDbContext.Categories.Add(category);
            //Ruajtja e te dhenave ne Database
            _applicationDbContext.SaveChanges();
        }

        [HttpDelete("/categories")]
        public void DeleteCategory(int id )
        {
            //Para se te bejme fshirjen kontrollojme nese kemi kete kategori
            //Nese e kemi e fshijme 
            var category = _applicationDbContext.Categories.FirstOrDefault(x=>x.Id== id);
            
            //Ne e kemi ne Database dhe do te vazhdojme me fshirjen e Saj 
            if (category != null) 
            {
                _applicationDbContext.Categories.Remove(category);
                _applicationDbContext.SaveChanges();
            }
        }

        [HttpGet("/Machines")]
        public List<Machine> GetMachine()
        {
            var machines = _applicationDbContext.Machines.ToList();
            return machines;
        }
    }
}
