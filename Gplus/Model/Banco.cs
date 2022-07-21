using Gplus.Dao;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Gplus.Model
{
    public class Banco
    {
        String instanciaBanco;
        String loginBanco;
        String senhaBanco;
        String cnpjBanco;
        DateTime dataPrimeiroBackup;
        String nomeBanco;
        int horaBackup;
        String mensagemRetorno = "";
        String caminhoSalvarBackup;
        String tipoBackup;
        public Banco()
        {


        }

        public string InstanciaBanco { get => instanciaBanco; set => instanciaBanco = value; }
        public string LoginBanco { get => loginBanco; set => loginBanco = value; }
        public string SenhaBanco { get => senhaBanco; set => senhaBanco = value; }
        public string CnpjBanco { get => cnpjBanco; set => cnpjBanco = value; }
        public int HoraBackup { get => horaBackup; set => horaBackup = value; }
        public string NomeBanco { get => nomeBanco; set => nomeBanco = value; }
        public string CaminhoSalvarBackup { get => caminhoSalvarBackup; set => caminhoSalvarBackup = value; }
        public string TipoBackup { get => tipoBackup; set => tipoBackup = value; }
        public string MensagemRetorno { get => mensagemRetorno; set => mensagemRetorno = value; }
        public DateTime DataPrimeiroBackup { get => dataPrimeiroBackup; set => dataPrimeiroBackup = value; }









        public async Task FazerBackupBancodeDados(object ConexaoBanco,string CaminhoPadraoBackup,String TipoBackup)
        {
            ConexaoSql conexaoSql = (ConexaoSql)ConexaoBanco;
            //preparar comando;
            SqlCommand cmd = new SqlCommand();

            if(TipoBackup == "_FULL")
            {
                cmd.CommandText = "BACKUP DATABASE[" + NomeBanco + "] TO DISK = '" + CaminhoPadraoBackup + "\\" + NomeBanco + "_FULL.BAK'" +
                " WITH NOINIT, NOUNLOAD, NOSKIP,STATS= 10, NOFORMAT"; ;

            }
            else
            {
                cmd.CommandText = "BACKUP DATABASE[" + NomeBanco + "] TO DISK = '" + CaminhoPadraoBackup + "\\" + NomeBanco + "_DIF.BAK'" +
               "WITH NOINIT, NOUNLOAD,DIFFERENTIAL, NOSKIP,STATS= 10, NOFORMAT";
            }

            try
            {
                cmd.Connection = conexaoSql.conectarBancoSQL();
                cmd.CommandTimeout = 999;

                //cmd.ExecuteNonQueryAsync();
               
                conexaoSql.desconectarBancoSQL();
             
            }
            catch (SqlException ex)
            {
                MensagemRetorno = ex.Message;
               
            }
        }



    }

}
