using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Livraria
{
    class Emprestimo
    {
        private DateTime dtEmprestimo = DateTime.MinValue;
        private DateTime dtDevolucao = DateTime.MinValue;

        public Emprestimo(DateTime dtEmprestimo){
            this.dtEmprestimo = dtEmprestimo;
        }

        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }
        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }
    }
}
