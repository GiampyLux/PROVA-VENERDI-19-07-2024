using Trasgressori.DAO;
using Trasgressori.Models;

namespace Trasgressori.Services
{
    public class VerbaleService
    {
        private readonly VerbaleDAO _verbaleDao;

        public VerbaleService(IConfiguration configuration)
        {
            _verbaleDao = new VerbaleDAO(configuration);
        }

        public IEnumerable<Verbale> GetAllVerbali()
        {
            return _verbaleDao.GetAll();
        }

        public void AddVerbale(Verbale verbale)
        {
            _verbaleDao.Add(verbale);
        }

    }
}
