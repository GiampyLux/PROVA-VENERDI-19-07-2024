using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trasgressori.Models;
using Trasgressori.Services;

namespace Trasgressori.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;
        private readonly TipoViolazioneService _tipoViolazioneService;

        public VerbaleController(IConfiguration configuration)
        {
            _verbaleService = new VerbaleService(configuration);
            _anagraficaService = new AnagraficaService(configuration);
            _tipoViolazioneService = new TipoViolazioneService(configuration);
        }

        public IActionResult Index()
        {
            var verbali = _verbaleService.GetAllVerbali();
            if (verbali == null)
            {
                verbali = new List<Verbale>(); // Restituisci una lista vuota invece di null
            }
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewBag.Idanagrafica = new SelectList(_anagraficaService.GetAllAnagrafiche(), "Idanagrafica", "Cognome");
            ViewBag.Idviolazione = new SelectList(_tipoViolazioneService.GetAllTipoViolazioni(), "Idviolazione", "Descrizione");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                _verbaleService.AddVerbale(verbale);
                return RedirectToAction("Index");
            }
            ViewBag.Idanagrafica = new SelectList(_anagraficaService.GetAllAnagrafiche(), "IdAnagrafica", "Cognome", verbale.IdAnagrafica);
            ViewBag.Idviolazione = new SelectList(_tipoViolazioneService.GetAllTipoViolazioni(), "IdViolazione", "Descrizione", verbale.IdViolazione);
            return View(verbale);
        }
    }
}
