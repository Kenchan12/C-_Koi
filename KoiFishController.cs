using KoiManagementSystem.Models;
using KoiManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoiManagementSystem.Controllers
{
    public class KoiFishController : Controller
    {
        private readonly IKoiFishService _koiFishService;

        public KoiFishController(IKoiFishService koiFishService)
        {
            _koiFishService = koiFishService;
        }

        public IActionResult Index()
        {
            var koiFishes = _koiFishService.GetAllKoiFishes();
            return View(koiFishes);
        }

        public IActionResult Details(int id)
        {
            var koiFish = _koiFishService.GetKoiFishById(id);
            if (koiFish == null)
            {
                return NotFound();
            }
            return View(koiFish);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KoiFish koiFish)
        {
            if (ModelState.IsValid)
            {
                _koiFishService.AddKoiFish(koiFish);
                return RedirectToAction(nameof(Index));
            }
            return View(koiFish);
        }

        public IActionResult Edit(int id)
        {
            var koiFish = _koiFishService.GetKoiFishById(id);
            if (koiFish == null)
            {
                return NotFound();
            }
            return View(koiFish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KoiFish koiFish)
        {
            if (id != koiFish.KoiId || !ModelState.IsValid)
            {
                return NotFound();
            }
            _koiFishService.UpdateKoiFish(koiFish);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var koiFish = _koiFishService.GetKoiFishById(id);
            if (koiFish == null)
            {
                return NotFound();
            }
            return View(koiFish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _koiFishService.DeleteKoiFish(id);
            return RedirectToAction(nameof(Index));
        }
    }
}