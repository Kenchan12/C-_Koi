using KoiManagementSystem.Models;
using KoiManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace KoiManagementSystem.Controllers
{
    public class WaterParameterController : Controller
    {
        private readonly IWaterParameterService _waterParameterService;

        public WaterParameterController(IWaterParameterService waterParameterService)
        {
            _waterParameterService = waterParameterService;
        }

        public IActionResult Index()
        {
            var waterParameters = _waterParameterService.GetAllWaterParameters();
            return View(waterParameters);
        }

        public IActionResult Details(int id)
        {
            var waterParameter = _waterParameterService.GetWaterParameterById(id);
            if (waterParameter == null)
            {
                return NotFound();
            }
            return View(waterParameter);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WaterParameter waterParameter)
        {
            if (ModelState.IsValid)
            {
                _waterParameterService.AddWaterParameter(waterParameter);
                return RedirectToAction(nameof(Index));
            }
            return View(waterParameter);
        }

        public IActionResult Edit(int id)
        {
            var waterParameter = _waterParameterService.GetWaterParameterById(id);
            if (waterParameter == null)
            {
                return NotFound();
            }
            return View(waterParameter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, WaterParameter waterParameter)
        {
            if (id != waterParameter.ParameterId || !ModelState.IsValid)
            {
                return NotFound();
            }
            _waterParameterService.UpdateWaterParameter(waterParameter);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var waterParameter = _waterParameterService.GetWaterParameterById(id);
            if (waterParameter == null)
            {
                return NotFound();
            }
            return View(waterParameter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _waterParameterService.DeleteWaterParameter(id);
            return RedirectToAction(nameof(Index));
        }
    }
}