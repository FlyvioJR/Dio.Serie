using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Entidades
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> lstSeries = new List<Serie>();
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
