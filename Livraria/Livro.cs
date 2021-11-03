using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria
{
    class Livro {
        int isbn;
        string titulo;
        string autor;
        string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }
        public object Isbn1 { get; internal set; }

        public Livro(int isbn, string titulo, string autor, string editora, List<Exemplar> exemplares) {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = exemplares;
        }
        public Livro(int isbn){ 
            this.isbn = isbn;
        }
        public void addExemplar(Exemplar exemplar){
            exemplar.Tombo = exemplares.Count + 1;
            exemplares.Add(exemplar);
        }
        public int qtdeExemplares(){
            return exemplares.Count;
        }
        public int qtdeDisponiveis(){
            int quantidadeDisponivel = 0;
            foreach(Exemplar exemplar in exemplares){
                if (exemplar.disponivel()){
                    quantidadeDisponivel++;
                }
            }
            return quantidadeDisponivel;
        }
        public int qtdeEmprestimos(){
            int quantidadeEmprestimos = 0;
            foreach(Exemplar exemplar in exemplares){
                quantidadeEmprestimos += exemplar.qtdeEmprestimos();
            }
            return quantidadeEmprestimos;
        }
        public double percDisponibilidade(){
            return (qtdeDisponiveis() / (double)qtdeExemplares()) * 100;
        }
    }
}
