using System;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitante : ControladorBase
    {
        public ControladorSolicitante(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarSolicitante(int id, string nome, string email, string telefone)
        {
            Solicitante solicitante;
            int posicao = 0;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Solicitante(id));
                solicitante = (Solicitante)registros[posicao];                
            }

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.telefone = telefone;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistro(new Solicitante(id));
        }

        public override Object[] SelecionarTodosRegistros()
        {
            Solicitante[] solicitantesAux = new Solicitante[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (Solicitante registro in registros)
            {
                if (registro != null)
                    solicitantesAux[i++] = registro;
            }
            return solicitantesAux;
        }
    }
}