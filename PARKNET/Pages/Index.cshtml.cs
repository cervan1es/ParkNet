using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARKNET.Services;

namespace PARKNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CustomerService _customerService;

        public IndexModel(ILogger<IndexModel> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            var userEmail = User.Identity.Name;
            if (userEmail is null) return Page();
            else
            {
                var customer = _customerService.GetCustomerbyEmail(userEmail);
                if (customer is null) return LocalRedirect(Url.Content("~/CustomerInfo"));
            }

            return Page();
        }
    }
}
