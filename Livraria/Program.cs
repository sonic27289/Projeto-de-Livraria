using System;
using System.Collections.Generic;

namespace Livraria
{
    class Program
    {
        static Livros acervo = new Livros();
        static void Main(string[] args)
        {
            if(args is null){
                throw new ArgumentNullException(nameof(args));
            }

            bool sair = false;
            int opcao;

            while(!sair){

                Console.WriteLine(" 0. Sair \n 1. Adicionar Livro \n 2. Pesquisar Livro (sintético) \n 3. Pesquisar Livro (analítico) \n 4. Adicionar Exemplar \n 5. Registrar empréstimo \n 6. Registrar devolução \n ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao){
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        adicionarLivro();
                        break;
                    case 2:
                        pesquisaLivroSintetica();
                        break;
                    case 3:
                        pesquisaLivroAnalitica();
                        break;
                    case 4:
                        adicionarExemplar();
                        break;
                    case 5:
                        registrarEmprestimo();
                        break;
                    case 6:
                        registrarDevolucao();
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida !");
                        break;
                }
            }            
        }
        private static void adicionarLivro(){

            Console.Write("Digite o ISBN do Livro: ");
            int isbn1 = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título do Livro: ");
            string titulo1 = Console.ReadLine();
            Console.Write("Digite o Autor do Livro: ");
            string autor1 = Console.ReadLine();
            Console.Write("Digite a Editora do Livro: ");
            string editora1 = Console.ReadLine();
            List<Exemplar> exemplaresNovo = new List<Exemplar>();
            acervo.Adicionar(new Livro(isbn1, titulo1, autor1, editora1, exemplaresNovo));
        }
        private static Livro pesquisaLivro(){

            Console.WriteLine("Digite o ISBN do Livro: ");
            int isbn2 = int.Parse(Console.ReadLine());
            Livro livroPesquisado = acervo.Pesquisar(new Livro(isbn2));
            if(livroPesquisado == null){
                Console.WriteLine("O Livro pesquisado não está registrado no nosso sistema !");
                return null;
            }
            else{
                return livroPesquisado;
            }
            
        }
        private static Livro pesquisaLivroSintetica(){

            Livro livroPesquisado = pesquisaLivro();
            Console.WriteLine("Livro: {0} por {1}, Editora: {2}", livroPesquisado.Titulo, livroPesquisado.Autor, livroPesquisado.Editora);
            Console.WriteLine("Total de Exemplares: {0}", livroPesquisado.qtdeExemplares());
            Console.WriteLine("Total de Exemplares disponíveis: {0}", livroPesquisado.qtdeDisponiveis());
            Console.WriteLine("Totais de Empréstimos: {0}", livroPesquisado.qtdeEmprestimos());
            if(livroPesquisado.percDisponibilidade() == 0){
                Console.WriteLine("Percentual de disponibilidade: 0%");
            }
            else{
                Console.WriteLine("Percentual de disponibilidade: {0}%", livroPesquisado.percDisponibilidade());
            }
            return livroPesquisado;
        }
        private static void pesquisaLivroAnalitica(){

            Livro livroPesquisado = pesquisaLivroSintetica();
            Console.WriteLine("Emprestimos: \n --------------------------------- \n");
            foreach(Exemplar exemplar in livroPesquisado.Exemplares){
                Console.WriteLine("Exemplar número: {0}", exemplar.Tombo);
                foreach(Emprestimo emprestimo in exemplar.Emprestimos){
                    Console.WriteLine("Emprestimo em: {0}", emprestimo.DtEmprestimo);
                    if(emprestimo.DtDevolucao == DateTime.MinValue){
                        Console.WriteLine("Em ação de Empréstimo");
                    }
                    else{
                        Console.WriteLine("Devolvido em: {0}", emprestimo.DtDevolucao);
                    }
                }
            }
        }
        private static void adicionarExemplar(){

            Livro livroAdicionadoExemplar = pesquisaLivro();
            livroAdicionadoExemplar.addExemplar(new Exemplar());
            Console.WriteLine("Exemplar adicionado no Livro: {0}", livroAdicionadoExemplar.Titulo);
        }
        private static void registrarEmprestimo(){

            Livro livroAdicionadoEmprestar = pesquisaLivro();
            for(int i = 0; i < livroAdicionadoEmprestar.qtdeExemplares(); i++){
                if (livroAdicionadoEmprestar.Exemplares[i].emprestar()){
                    Console.WriteLine("Exemplar {0} / {1} Emprestado !", i + 1, livroAdicionadoEmprestar.qtdeExemplares());
                    break;
                }
            }
        }
        private static void registrarDevolucao(){

            Livro livroAdicionadoDevolver = pesquisaLivro();
            for(int i = 0; i < livroAdicionadoDevolver.qtdeExemplares(); i++){
                if (livroAdicionadoDevolver.Exemplares[i].devolver()){
                    Console.WriteLine("Exemplar devolvido ! \n Exemplares disponíveis: {0}", livroAdicionadoDevolver.qtdeExemplares());
                    break;
                }
            }
        }
    }
}
