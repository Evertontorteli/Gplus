using Gplus.Dao;
using Gplus.Model;

namespace Gplus.Controler
{
    internal class ConfiguracaoBancoBackupController
    {
        public BancoModel ObterConfiguracaoBackup1() 
        {
            return new ConfiguracaoBancoBackupDAO().ObterConfiguracaoBackup1();
        }
    }
}
