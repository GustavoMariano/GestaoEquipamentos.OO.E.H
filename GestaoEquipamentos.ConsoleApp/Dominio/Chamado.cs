using System;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    public class Chamado
    {
        public int id;
        public string titulo;
        public string descricao;
        public DateTime dataAbertura;
        public Equipamento equipamento;
        public Solicitante solicitante;

        public Chamado(int id)
        {
            this.id = id;
        }

        public Chamado()
        {
            id = GeradorId.GerarIdChamado();
        }        

        public string DiasEmAberto 
        { 
            get 
            {
                TimeSpan diasEmAberto = DateTime.Now - dataAbertura;

                return diasEmAberto.ToString("dd");
            } 
        }

        public override bool Equals(object obj)
        {
            Chamado chamadoId = (Chamado)obj;

            if (chamadoId != null && chamadoId.id == this.id)
                return true;

            return false;
        }
    }
}
