using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Livraria
{
    class Livros
    {
        private List<Livro> acervo = new List<Livro>();
        
        public void Adicionar(Livro livro){
            acervo.Add(livro);
        }

        public Livro Pesquisar(Livro livro){
            foreach(Livro livroAdicionado in acervo){
                if(livroAdicionado.Isbn == livro.Isbn){
                    return livroAdicionado;
                }
            }
            return null;
        }
    }
}
