using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ViewMachineModel : PageModel
    {
        private readonly ILogger<ViewMachineModel> _logger;

        public ViewMachineModel(ILogger<ViewMachineModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
