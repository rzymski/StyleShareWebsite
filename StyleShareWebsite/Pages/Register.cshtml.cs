using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StyleShareWebsite.DataAccess.Interfaces;
using StyleShareWebsite.Models;

namespace StyleShareWebsite.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public User user { get; set; }

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                user.Admin = false;
                user.Blocked = false;

                _userService.AddAsync(user);
                return RedirectToPage("./Login");
            }
            return Page();

        }

        public void OnGet()
        {
        }
    }
}
