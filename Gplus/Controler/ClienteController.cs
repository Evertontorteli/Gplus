using Gplus.Dao;
using Gplus.Model;

namespace Gplus.Controler
{
    internal class ClienteController
    {
        public Cliente ObterClienteBanco1() 
        {
            return new ClienteDAO().ObterClienteBanco1();
        }
    }
}
