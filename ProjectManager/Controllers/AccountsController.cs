using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Context;
using ProjectManager.DTO;
using ProjectManager.Utilities;
using ProjectManager.Utilities.DataMapper;

namespace ProjectManager.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ProjectContext _context;

        public AccountsController(ProjectContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = model.ToModel();

            user.Password = Encrypt.EncryptPassword(user.Password);
            user = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }


        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }
    }
}
