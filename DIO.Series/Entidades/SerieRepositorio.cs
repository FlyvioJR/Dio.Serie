using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Entidades
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> lstSeries = new List<Serie>()
        {
            new Serie(0, Enums.Genero.Acao, "24 horas", "investigação", 2000),
            new Serie(1, Enums.Genero.Comedia, "big bang theory", "nerds", 2001),
            new Serie(2, Enums.Genero.Documentario, "cosmos", "universo", 2005),
        };
        public void Atualizar(int id, Serie entidade)
        {
            lstSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            lstSeries[id].Excluir();
        }

        public void Inserir(Serie entidade)
        {
            lstSeries.Add(entidade);
        }

        public List<Serie> Listar()
        {
            return lstSeries;
        }

        public int ProximoId()
        {
            return lstSeries.Count;
        }

        public Serie RetornarPorId(int id)
        {
            return lstSeries[id];
        }
    }
}
