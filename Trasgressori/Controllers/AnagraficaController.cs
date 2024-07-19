using Microsoft.AspNetCore.Mvc;
using Trasgressori.Models;
using Trasgressori.Services;

namespace Trasgressori.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(IConfiguration configuration)
        {
            _anagraficaService = new AnagraficaService(configuration);
        }

        public ActionResult Index()
        {
            var anagrafiche = _anagraficaService.GetAllAnagrafiche();
            return View(anagrafiche);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaService.AddAnagrafica(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }
    }
}
