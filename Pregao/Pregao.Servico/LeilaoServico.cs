﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pregao.Dominio;
using Pregao.RepositorioADO;

namespace Pregao.Servico
{
    public class LeilaoServico
    {
        private readonly LeilaoRepositorio repositorio;

        public LeilaoServico()
        {
            repositorio = new LeilaoRepositorio();
        }

        public void Salvar(Leilao leilao)
        {
            repositorio.Salvar(leilao);
        }

        public void Excluir(int id)
        {
            repositorio.Excluir(id);
        }

        public List<Leilao> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public List<Leilao> ListarTodosAberto()
        {
            return repositorio.ListarTodosAberto();
        }

        public Leilao ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }

        public void EncerrarLeilao()
        {
            repositorio.EncerrarLeilao();
        }
    }
}
