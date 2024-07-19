using Trasgressori.DAO;
using Trasgressori.Models;

namespace Trasgressori.Services
{
    public class AnagraficaService
    {
        private readonly AnagraficaDAO _anagraficaDao;

        public AnagraficaService(IConfiguration configuration)
        {
            _anagraficaDao = new AnagraficaDAO(configuration);
        }

        public IEnumerable<Anagrafica> GetAllAnagrafiche()
        {
            return _anagraficaDao.GetAll();
        }

        public void AddAnagrafica(Anagrafica anagrafica)
        {
            _anagraficaDao.Add(anagrafica);
        }
    }
}
