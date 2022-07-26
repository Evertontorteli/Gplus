using System;

namespace Gplus.Model
{
    public class Cliente
    {
        
        String emailUpload;
        String senhaUpload;
        String servicoUpload;
        String cnpj;
        String nomeFantasia;

        public Cliente()
        {

        }

        public string EmailUpload { get => emailUpload; set => emailUpload = value; }
        public string SenhaUpload { get => senhaUpload; set => senhaUpload = value; }
        public string ServicoUpload { get => servicoUpload; set => servicoUpload = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string NomeFantasia { get => nomeFantasia; set => nomeFantasia = value; }
    }
}
