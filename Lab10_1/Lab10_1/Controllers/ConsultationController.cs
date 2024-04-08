using Lab101.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab101.Controllers
{
    public class ConsultationController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ConsultationRegistration model)
        {
            if (ModelState.IsValid)
            {
                // Здесь код для обработки данных формы, например, сохранение в БД.
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
