using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaSolicitante : TelaBase
    {
        private ControladorSolicitante controladorSolicitante;

        public TelaSolicitante(ControladorSolicitante controlador)
        {
            controladorSolicitante = controlador;
        }

        public override void InserirNovoRegistro(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                Console.Write("Digite o nome do solicitante: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do solicitante: ");
                string email = Console.ReadLine();

                Console.Write("Digite o número de telefone do solicitante: ");
                string telefone = Console.ReadLine();                

                resultadoValidacao = controladorSolicitante.RegistrarSolicitante(
                    id, nome, email, telefone);

                if (resultadoValidacao != "SOLICITANTE_VALIDO")
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
            } while (resultadoValidacao != "SOLICITANTE_VALIDO");
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            ConfigurarTela("Solicitante registrados:");

            string configuracaColunasTabela = "{0,-10} | {1,-40} | {2,-45} | {3,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Solicitante[] solicitentes = (Solicitante[])controladorSolicitante.SelecionarTodosRegistros();

            for (int i = 0; i < solicitentes.Length; i++)
            {
                Console.Write(configuracaColunasTabela, solicitentes[i].id, solicitentes[i].nome, solicitentes[i].email, solicitentes[i].telefone);

                Console.WriteLine();
            }

            if (solicitentes.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum solicitente cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do solicitante que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            InserirNovoRegistro(idSelecionado);
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o ID do solicitante que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorSolicitante.ExcluirSolicitante(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Email", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}