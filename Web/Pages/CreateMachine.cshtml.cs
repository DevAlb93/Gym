using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class CreateMachineModel : PageModel
    {
        private readonly ILogger<CreateMachineModel> _logger;

        public CreateMachineModel(ILogger<CreateMachineModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
