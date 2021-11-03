using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Livraria
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int Tombo { get => tombo; set => tombo = value; }
        public List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public bool emprestar(){
            if (disponivel()){
                emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }
        public bool devolver(){
            if (!disponivel()){
                emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }
        public bool disponivel(){
            if(emprestimos.Count != 0 && emprestimos.Last().DtDevolucao == DateTime.MinValue){
                return false;
            }
            return true;
        }
        public int qtdeEmprestimos(){
            return emprestimos.Count;
        }
    }
}
