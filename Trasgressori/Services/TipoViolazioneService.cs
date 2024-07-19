using Trasgressori.DAO;
using Trasgressori.Models;

namespace Trasgressori.Services
{
    public class TipoViolazioneService
    {
        private readonly TipoViolazioneDAO _tipoViolazioneDao;

        public TipoViolazioneService(IConfiguration configuration)
        {
            _tipoViolazioneDao = new TipoViolazioneDAO(configuration);
        }

        public IEnumerable<TipoViolazione> GetAllTipoViolazioni()
        {
            return _tipoViolazioneDao.GetAll();
        }

        public void AddTipoViolazione(TipoViolazione tipoViolazione)
        {
            _tipoViolazioneDao.Add(tipoViolazione);
        }
    }
}
