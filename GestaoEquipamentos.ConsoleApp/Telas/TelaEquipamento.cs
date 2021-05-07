using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaEquipamento : TelaBase
    {
        private ControladorEquipamento controladorEquipamento;

        public TelaEquipamento(ControladorEquipamento controlador)
        {
            controladorEquipamento = controlador;
        }

        public override void InserirNovoRegistro(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o preço do equipamento: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.Write("Digite o número de série do equipamento: ");
                string numeroSerie = Console.ReadLine();

                Console.Write("Digite a data de fabricação do equipamento: ");
                DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Digite o fabricante do equipamento: ");
                string fabricante = Console.ReadLine();

                resultadoValidacao = controladorEquipamento.RegistrarEquipamento(
                    id, nome, preco, numeroSerie, dataFabricacao, fabricante);

                if (resultadoValidacao != "EQUIPAMENTO_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registro gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();
            } while (resultadoValidacao != "EQUIPAMENTO_VALIDO");
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            ConfigurarTela("Equipamento registrados:");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Equipamento[] equipamentos = (Equipamento[])controladorEquipamento.SelecionarTodosRegistros();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Console.Write(configuracaColunasTabela, equipamentos[i].id, equipamentos[i].nome, equipamentos[i].fabricante);

                Console.WriteLine();
            }

            if (equipamentos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipmaneto cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            InserirNovoRegistro(idSelecionado);
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEquipamento.ExcluirEquipamento(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }
       
        
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
