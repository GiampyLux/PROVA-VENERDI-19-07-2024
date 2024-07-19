using Microsoft.AspNetCore.Mvc;
using Trasgressori.Services;

namespace Trasgressori.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _tipoViolazioneService;

        public TipoViolazioneController(IConfiguration configuration)
        {
            _tipoViolazioneService = new TipoViolazioneService(configuration);
        }

        public IActionResult Index()
        {
            var violazioni = _tipoViolazioneService.GetAllTipoViolazioni();
            return View(violazioni);
        }
    }
}
