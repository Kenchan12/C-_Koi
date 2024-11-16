using KoiManagementSystem.Models;
using KoiManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoiManagementSystem.Controllers
{
    public class PondController : Controller
    {
        private readonly IPondService _pondService;

        public PondController(IPondService pondService)
        {
            _pondService = pondService;
        }

        public IActionResult Index()
        {
            var ponds = _pondService.GetAllPonds();
            return View(ponds);
        }

        public IActionResult Details(int id)
        {
            var pond = _pondService.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }
            return View(pond);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pond pond)
        {
            if (ModelState.IsValid)
            {
                _pondService.AddPond(pond);
                return RedirectToAction(nameof(Index));
            }
            return View(pond);
        }

        public IActionResult Edit(int id)
        {
            var pond = _pondService.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }
            return View(pond);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pond pond)
        {
            if (id != pond.PondId || !ModelState.IsValid)
            {
                return NotFound();
            }
            _pondService.UpdatePond(pond);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var pond = _pondService.GetPondById(id);
            if (pond == null)
            {
                return NotFound();
            }
            return View(pond);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _pondService.DeletePond(id);
            return RedirectToAction(nameof(Index));
        }
    }
}