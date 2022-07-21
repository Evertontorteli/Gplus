using FluentScheduler;
using Gplus.Controler;
using Gplus.Model;

namespace Gplus.Tarefas
{
    internal class AgendadordeTarefas : Registry
    {
        public AgendadordeTarefas(object banco, object cliente,int tempoBackup)
        {
           
            //Executar a tarefa do controlador BancodeDdos;
            Schedule(() => new ContBancodeDados(banco, cliente)).
                NonReentrant().ToRunNow().AndEvery(tempoBackup).Minutes();

        }
    }
}
