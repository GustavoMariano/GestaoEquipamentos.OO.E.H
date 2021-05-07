using System;
using GestaoEquipamentos.ConsoleApp.Telas;

namespace GestaoEquipamentos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaBase telaBase = new TelaBase();

            Console.Clear();
            
            while (true)
            {
                TelaBase telaSelecionada = (TelaBase)telaBase.ObterTela();

                if (telaSelecionada == null)
                    break;

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;

                Console.Clear();

                switch (opcao)
                {
                    case "1": telaSelecionada.InserirNovoRegistro(0); break;
                    case "2": telaSelecionada.VisualizarRegistros(); break;
                    case "3": telaSelecionada.EditarRegistro(); break;
                    case "4": telaSelecionada.ExcluirRegistro(); break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }        
    }
}
