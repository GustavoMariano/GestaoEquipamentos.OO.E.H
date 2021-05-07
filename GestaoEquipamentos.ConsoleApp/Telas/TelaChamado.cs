using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaChamado : TelaBase
    {
        private TelaEquipamento telaEquipamento;
        private TelaSolicitante telaSolicitante;
        private ControladorChamado controladorChamado;

        public TelaChamado(TelaSolicitante telaSolicitante, TelaEquipamento telaEquipamento, ControladorChamado controladorChamado)
        {
            this.telaSolicitante = telaSolicitante;
            this.telaEquipamento = telaEquipamento;
            this.controladorChamado = (ControladorChamado)controladorChamado;
        }

        public override void InserirNovoRegistro(int idChamadoSelecionado)
        {
            Console.Clear();

            telaSolicitante.VisualizarRegistros();

            Console.Write("Digite o Id do solicitante da manutenção: ");
            int idSolicitanteChamado = Convert.ToInt32(Console.ReadLine());

            telaEquipamento.VisualizarRegistros();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            controladorChamado.RegistrarChamado(idChamadoSelecionado, idSolicitanteChamado, idEquipamentoChamado, titulo, descricao, dataAbertura);
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Chamado[] chamados = (Chamado[])controladorChamado.SelecionarTodosRegistros();

            foreach (Chamado chamado in chamados)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-25} | {3,-25} | {4,-30}",
                    chamado.id, chamado.equipamento.nome, chamado.titulo, chamado.DiasEmAberto, chamado.solicitante.nome);
            }

            if (chamados.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            InserirNovoRegistro(idSelecionado);
        }

        public override void ExcluirRegistro()
        {
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorChamado.ExcluirChamado(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }        

        public string ObterOpcaoControleChamados()
        {
            Console.WriteLine("Digite 1 para inserir novo chamadp");
            Console.WriteLine("Digite 2 para visualizar chamados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        #region Métodos Privados
        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-25} | {3,-25} | {4,-30}", "Id", "Equipamento", "Título", "Dias em Aberto", "Solicitante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
