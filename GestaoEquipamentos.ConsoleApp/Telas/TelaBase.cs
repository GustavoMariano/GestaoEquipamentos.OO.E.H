using System;
using GestaoEquipamentos.ConsoleApp.Controladores;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaBase
    {
        const int CAPACIDADE_DEGISTROS = 100;

        static ControladorEquipamento controladorEquipamento = new ControladorEquipamento(CAPACIDADE_DEGISTROS);
        static ControladorSolicitante controladorSolicitante = new ControladorSolicitante(CAPACIDADE_DEGISTROS);
        static ControladorChamado controladorChamado = new ControladorChamado(CAPACIDADE_DEGISTROS, controladorEquipamento, controladorSolicitante);        
        static TelaSolicitante telaSolicitante = new TelaSolicitante(controladorSolicitante);
        static TelaEquipamento telaEquipamento = new TelaEquipamento(controladorEquipamento);
        static TelaChamado telaChamado = new TelaChamado(telaSolicitante, telaEquipamento, controladorChamado);

        public virtual object ObterTela()
        {
            string opcao = "";
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite 3 para o Controle de Solicitantes");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    TelaEquipamento tela = telaEquipamento;
                    return tela;
                }
                else if (opcao == "2")
                {
                    TelaChamado tela = telaChamado;
                    return tela;
                }
                else if (opcao == "3")
                {
                    TelaSolicitante tela = telaSolicitante;
                    return tela;
                }
                else if (opcao.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                {
                    Environment.Exit(0);
                }
            } while (OpcaoInvalida(opcao));

            return null;
        }        

        public string ObterOpcao()
        {
            Console.Clear();

            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registro");
            Console.WriteLine("Digite 3 para editar um registro");
            Console.WriteLine("Digite 4 para excluir um registro");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoRegistro(int id)
        {
        }

        public virtual void VisualizarRegistros()
        {
        }

        public virtual void EditarRegistro()
        {
        }

        public virtual void ExcluirRegistro()
        {
        }

        protected void ConfigurarTela(string subititulo)
        {
            Console.WriteLine(subititulo);
        }

        private static bool OpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2";
        }
    }
}
