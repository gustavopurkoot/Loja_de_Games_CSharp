using System;
using System.Collections.Generic;

class Produto
{
    String nome;
    double preco;
    String Marca;
    int quantidade;

    public void Exibir()
    {
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Preço: " + preco);
        Console.WriteLine("Marca: " + Marca);
        Console.WriteLine("Quantidade: " + quantidade);
    }

    class Program
    {
        static void Main()
        {
            List<Produto> produtos = new List<Produto>();
            int opcao = 0;

            do
            {
                Console.WriteLine("1 - Cadastro de Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Buscar Produto");
                Console.WriteLine("4 - Excluir Produto");
                Console.WriteLine("5 - Encerrar");

                switch (opcao)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                }
            } while (opcao != 5);
        }

    }
}