﻿using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorBase
    {
        protected object[] registros = null;

        public ControladorBase(int capacidadeRegistros)
        {
            registros = new object[capacidadeRegistros];
        }

        protected bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }

        protected object SelecionarRegistro(object obj)
        {
            foreach (var item in registros)
            {
                if (item.Equals(obj))
                    return item;
            }
            return null;
        }

        public virtual Object[] SelecionarTodosRegistros()
        {
            return null;
        }

        protected int QtdRegistrosCadastrados()
        {
            int totalRegistros = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    totalRegistros++;
                }
            }
            return totalRegistros;
        }

        protected int ObterPosicaoVazia()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        protected int ObterPosicaoOcupada(object objSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (objSelecionado.Equals(registros[i]))
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }
    }
}
