using System;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorChamado : ControladorBase
    {
        private ControladorEquipamento equipamento;
        private ControladorSolicitante solicitante;

        public ControladorChamado(int capacidadeRegistros, ControladorEquipamento controlador, 
            ControladorSolicitante controladorSolicitante) : base(capacidadeRegistros)
        {
            solicitante = controladorSolicitante;
            equipamento = controlador;
            registros = new Chamado[capacidadeRegistros];
        }

        public void RegistrarChamado(int id, int idSolicitanteChamado, int idEquipamentoChamado, string titulo, string descricao, DateTime dataAbertura)
        {
            Chamado chamado;
            int posicao = 0;            

            if (id == 0) 
            {
                chamado = new Chamado();
                posicao = ObterPosicaoVazia();
            }                
            else
            {
                posicao = ObterPosicaoOcupada(new Chamado(id));
                chamado = (Chamado)registros[posicao];                
            }

            chamado.solicitante = solicitante.SelecionarSolicitantePorId(idSolicitanteChamado);
            chamado.equipamento = equipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;

            registros[posicao] = chamado;
        }

        public bool ExcluirChamado(int idSelecionado)
        {
            return ExcluirRegistro(new Chamado(idSelecionado));
        }

        public Chamado SelecionarEquipamentoPorId(int id)
        {
            return (Chamado)SelecionarRegistro(new Chamado(id));
        }

        public override Object[] SelecionarTodosRegistros()
        {
            Chamado[] chamadosAux = new Chamado[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (Chamado registro in registros)
            {
                if (registro != null)
                    chamadosAux[i++] = registro;
            }
           
            return chamadosAux;
        }
    }
}
