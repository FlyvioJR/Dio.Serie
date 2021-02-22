using DIO.Series.Entidades;
using DIO.Series.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Genero: {Genero + Environment.NewLine}";
            retorno += $"Titulo: {Titulo + Environment.NewLine}";
            retorno += $"Descricao: {Descricao + Environment.NewLine}";
            retorno += $"Ano do lançamento: {Ano + Environment.NewLine}";
            retorno += Excluido == true ? "Serie excluida" : "serie cadastrada";
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

        public void Excluir()
        {
            Excluido = true;
        }
        public bool VerificarStatus()
        {
            return Excluido;
        }
    }
}
