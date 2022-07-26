using Gplus.Dao;
using Gplus.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gplus.Controler
{

    public class ContBancodeDados
    {

        BancoModel objBanco;

        public ContBancodeDados(Object banco,Object cliente)
        {
            objBanco = (BancoModel)banco;


          Task.WaitAny(realizarBackupbancodeDados());
          
        }


        public async Task  realizarBackupbancodeDados()
        {

            Arquivo objArquivo = new Arquivo();


            //Identificar existencia dos arquivos na raiz do aplicativo
            objArquivo.IdentificarFullouDifBackup(objBanco);



            //Criar Diretorio para salvar o arquivo;
            objBanco.CaminhoSalvarBackup = objArquivo.CriarDiretorioPadraoBackup(objBanco.NomeBanco);


            //conexao com SQL
            ConexaoSql conexaosql = new ConexaoSql(objBanco.InstanciaBanco, objBanco.LoginBanco, objBanco.NomeBanco, objBanco.SenhaBanco);

            ////Fazer o backup, esperar terminar essa função usando await
            await objBanco.FazerBackupBancodeDados(conexaosql, Application.StartupPath, objBanco.TipoBackup);

            if (objBanco.MensagemRetorno != "")
            {
                Console.WriteLine(objBanco.MensagemRetorno);
            }
            else
            {
                Console.WriteLine("Backup Realizado com sucesso do banco  " + objBanco.NomeBanco);
                //Compactar o arquivo de backup
                await objArquivo.CompactarArquivoBackup(objBanco.CaminhoSalvarBackup, objBanco.NomeBanco, objBanco.TipoBackup);

                if (objArquivo.MensagemRetornoArquivo != "")

                {
                    Console.WriteLine(objArquivo.MensagemRetornoArquivo);
                }
                else
                {
                    Console.WriteLine("Arquivo compactado, processo concluido banco " + objBanco.NomeBanco);
                }
            }

            //Verificar se tem o arquivo full ou diff, se tiver deletar para sobrar espaço em HD se não tier não faz nada.

            objArquivo.VerificarArquivoBakouDifeDeletar(objBanco.NomeBanco, objBanco.CaminhoSalvarBackup, objBanco.TipoBackup);


        }
    }
}
