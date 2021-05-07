using System;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorEquipamento : ControladorBase
    {
        public ControladorEquipamento(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarEquipamento(int id, string nome, double preco,
            string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Equipamento equipamento;
            int posicao = 0;

            if (id == 0)
            {
                equipamento = new Equipamento();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Equipamento(id));
                equipamento = (Equipamento)registros[posicao];                
            }                

            equipamento.nome = nome;
            equipamento.preco = preco;
            equipamento.numeroSerie = numeroSerie;
            equipamento.dataFabricacao = dataFabricacao;
            equipamento.fabricante = fabricante;

            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = equipamento;

            return resultadoValidacao;
        }

        public bool ExcluirEquipamento(int idSelecionado)
        {
            return ExcluirRegistro(new Equipamento(idSelecionado));
        }

        public Equipamento SelecionarEquipamentoPorId(int id)
        {
            return (Equipamento)SelecionarRegistro(new Equipamento(id));
        }

        public override Object[] SelecionarTodosRegistros()
        {
            Equipamento[] equipamentosAux = new Equipamento[QtdRegistrosCadastrados()];

            int i = 0;

            foreach(Equipamento registro in registros)
            {
                if (registro != null)
                    equipamentosAux[i++] = registro;
            }
            return equipamentosAux;
        }        
    }
}