using DIO.Series.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Entidades
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Genero: {Genero + Environment.NewLine}";
            retorno += $"Titulo: {Titulo + Environment.NewLine}";
            retorno += $"Descricao: {Descricao + Environment.NewLine}";
            retorno += $"Ano do lançamento: {Ano + Environment.NewLine}";
            return retorno;
        }

        public string retonaTitulo()
        {
            return Titulo;
        }
        public int retonaId()
        {
            return Id;
        }
    }
}
