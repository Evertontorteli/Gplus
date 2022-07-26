using Ionic.Zip;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gplus.Model
{
    internal class Arquivo
    {

        String mensagemRetornoArquivo = "";

        public string MensagemRetornoArquivo { get => mensagemRetornoArquivo; set => mensagemRetornoArquivo = value; }

        public Arquivo()
        {

        }

        public void SalvarArquivoCaminhoAlternativo()
        {
            FolderBrowserDialog saveCaminho = new FolderBrowserDialog();
            //informar o nome do filtro e a extenção que queremos salvar
            //saveFile.Filter = "Arquivo Texto |*.RAR";
            //mostrar a caixa de dialogo
            saveCaminho.ShowDialog();
            //this.caminhoAlternativoBackup = saveCaminho.SelectedPath;
        }

        public String CriarDiretorioPadraoBackup(string NomeBanco)
        {
            CultureInfo culturaLinguagem = new CultureInfo("Pt-br");
            string diaSemana = culturaLinguagem.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            String CaminhoPadraoBackup = Application.StartupPath + "\\" + NomeBanco + "\\"+diaSemana;

            if (!Directory.Exists(CaminhoPadraoBackup))
            {
                Directory.CreateDirectory(CaminhoPadraoBackup);

            }

            return CaminhoPadraoBackup;
        }


        public void VerificarArquivoBakouDifeDeletar(String NomeBanco, String CaminhoBackup, String TipoBackup)
        {

            if (File.Exists(NomeBanco + "_FULL.BAK"))
            {
                File.Delete(NomeBanco + "_FULL.BAK");
            }

            if (File.Exists(NomeBanco + "_DIF.BAK"))
            {
                File.Delete(NomeBanco + "_DIF.BAK");
            }
        }


        public void IdentificarFullouDifBackup(object banco)
        {
            BancoModel objBanco = (BancoModel)banco;

            var dataHoje = DateTime.Today;

            if (!File.Exists(objBanco.NomeBanco + "_FULL.BAK"))
            {
                if (!File.Exists(objBanco.CaminhoSalvarBackup + "\\" + objBanco.NomeBanco + "_FULL.zip"))
                {
                    objBanco.DataPrimeiroBackup = dataHoje;
                    objBanco.TipoBackup = "_FULL";
                    Console.WriteLine("Não tem Full em nenhum lugar, terei que fazer do zero Banco" + objBanco.NomeBanco);
                }
                else
                {
                    var dataCriacaoArquivo = File.GetCreationTime(objBanco.NomeBanco + "_FULL.zip");
                    if (dataCriacaoArquivo < dataHoje)
                    {
                        objBanco.DataPrimeiroBackup = dataHoje;
                        objBanco.TipoBackup = "_FULL";
                        Console.WriteLine("Terei que fazer, por que o arquivo que existe é de data menor " + objBanco.NomeBanco);
                    }
                    else
                    {
                        objBanco.TipoBackup = "_DIF";
                        Console.WriteLine("Já existe um Full de Hoje, irei fazer um DIF" + objBanco.NomeBanco);
                    }
                }
            }
            else
            {
                objBanco.TipoBackup = "_DIF";
                Console.WriteLine("Já existe um Full de Hoje, irei fazer um DIF" + objBanco.NomeBanco);
            }
        }

        public async Task CompactarArquivoBackup(String CaminhoBackup, String NomeBanco, String TipoBackup)
        {
            try
            {
                //instanciar a classe de funções
                ZipFile compactador = new ZipFile();

                //compactar o arquivo com o melhor propriedade do compactador
                compactador.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                compactador.UseZip64WhenSaving = Zip64Option.AsNecessary;

                compactador.Password = "adrvsc";
                compactador.Comment = "Esse DIFERENCIAL É REFERENTE AO FULL DO DIA 13/03/2022";

                //vai pegar o banco no diretorio padrao da aplicacao;
                compactador.AddFile(NomeBanco + TipoBackup + ".BAK");

                compactador.Save(CaminhoBackup + "\\" + NomeBanco + TipoBackup + ".zip");

                //finalizar o processo da Lib zip
                compactador.Dispose();
            }
            catch (Exception ex)
            {
                MensagemRetornoArquivo = ex.Message;

            }

        }


    }

}




