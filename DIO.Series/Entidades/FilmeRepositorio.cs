using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Entidades
{
    class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> lstFilmes = new List<Filme>()
        {
            new Filme(0, Enums.Genero.Acao, "Thorn", "Herois", 2015),
            new Filme(1, Enums.Genero.Comedia, "Alto da compadecida", "Sertão nordestino", 2005),
            new Filme(2, Enums.Genero.Drama, "Uncle Jack", "Preconceitos", 2020),
        };

        public void Atualizar(int id, Filme entidade)
        {
            lstFilmes[id] = entidade;
        }
        public void Excluir(int id)
        {
            lstFilmes[id].Excluir();
        }

        public void Inserir(Filme entidade)
        {
            lstFilmes.Add(entidade);
        }

        public List<Filme> Listar()
        {
            return lstFilmes;
        }

        public int ProximoId()
        {
            return lstFilmes.Count;
        }

        public Filme RetornarPorId(int id)
        {
            return lstFilmes[id];
        }

    }
}
