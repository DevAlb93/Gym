using Database.EF;
using Database.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("/category/{id}")]
        public Category GetCategory(int id)
        {
            var category = _applicationDbContext.Categories.Where(x=>x.Id==id)
                .FirstOrDefault();
            return category;
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

        //Per te perfshire makinat dhe kategorite
        [HttpGet("/Machines")]
        public List<Machine> GetMachine()
        {
            var machines = _applicationDbContext.Machines
                .Include(x=>x.Category).ToList();
            return machines;
        }

        //Per te perfshire makinat dhe kategorite
        [HttpPost("/Machines")]
        public void CreateMachine(Machine machine)
        {
            //Krijimi i nje Kategorie te re 
            var category = GetCategory(machine.Category.Id);
            machine.Category= category;

            _applicationDbContext.Machines.Add(machine);
            //Ruajtja e te dhenave ne Database
            _applicationDbContext.SaveChanges();
        }
    }
}
