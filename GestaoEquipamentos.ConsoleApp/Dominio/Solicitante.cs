using System;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Solicitante
    {
        public int id;
        public string nome;
        public string telefone;
        public string email;

        public Solicitante(int id)
        {
            this.id = id;
        }

        public Solicitante()
        {
            id = GeradorId.GerarIdSolicitante();
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo Nome é obrigatório \n";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(email))
                resultadoValidacao += "O campo E-mail é obrigatório \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "O campo Telefone é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "SOLICITANTE_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Solicitante s = (Solicitante)obj;

            if (s != null && s.id == this.id)
                return true;

            return false;
        }
    }
}
