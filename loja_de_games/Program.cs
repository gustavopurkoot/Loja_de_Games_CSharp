using System;
using System.Collections.Generic;

class Produto
{
    public String nome;
    public double preco;
    public String Marca;
    public int quantidade;

    public Produto(String nome, double preco, String marca, int quantidade)
    {
        this.nome = nome;
        this.preco = preco;
        this.Marca = marca;
        this.quantidade = quantidade;
    }

    public double valorTotalEstoque()
    {
        return preco * quantidade;
    }

    public void Exibir()
    {
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Preço: " + preco);
        Console.WriteLine("Marca: " + Marca);
        Console.WriteLine("Quantidade: " + quantidade);
        Console.WriteLine("Valor total do estoque: " + valorTotalEstoque());
    }

}
    class Program
    {

        static void Main()
        {
            List<Produto> produtos = new List<Produto>();
            int opcao = 0;
            String nomeBuscar;

            do
            {
                Console.WriteLine("1 - Cadastro de Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Buscar Produto");
                Console.WriteLine("4 - Excluir Produto");
                Console.WriteLine("5 - Atualizar Produto");
                Console.WriteLine("6 - Encerrar");

                Console.WriteLine("Digite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do produto:");
                        String nome = Console.ReadLine()
                        ;
                        Console.WriteLine("Digite o preço do produto:");
                        double preco = double.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a marca do produto:");
                        String marca = Console.ReadLine();

                        Console.WriteLine("Digite a quantidade do produto:");
                        int quantidade = int.Parse(Console.ReadLine());

                        if (preco <= 0)
                        {
                            Console.WriteLine("Preço deve ser maior que 0!");
                            break;
                        }
                        if (quantidade < 0)
                        {
                            Console.WriteLine("A quantia do produto não pode ser menor que 0!");
                            break;
                        }

                        produtos.Add(new Produto(nome, preco, marca, quantidade));

                        break;
                    case 2:
                        Console.WriteLine("Digite 1 para listar todos os produtos ou 2 para listar por marca:");
                        int opcaoListar = int.Parse(Console.ReadLine());

                        if (opcaoListar == 1)
                        {
                            foreach (Produto produto in produtos)
                            {
                                Console.WriteLine("-------------");
                                produto.Exibir();
                            }
                        }
                        else if (opcaoListar == 2)
                        {
                            Console.WriteLine("Digite a marca para filtrar:");
                            string marcaBusca = Console.ReadLine().ToLower();

                            bool encontrou = false;

                            foreach (Produto produto in produtos)
                            {
                                if (produto.Marca.ToLower() == marcaBusca)
                                {
                                    Console.WriteLine("-------------");
                                    produto.Exibir();
                                    encontrou = true;
                                }
                            }

                            if (!encontrou)
                            {
                                Console.WriteLine("Nenhum produto encontrado com essa marca.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o nome do produto para buscar:");
                        nomeBuscar = Console.ReadLine();
                        bool encontrado = false;
                        foreach (Produto produto in produtos)
                        {
                            if (produto.nome.ToLower() == nomeBuscar.ToLower())
                            {
                                Console.WriteLine("Produto encontrado:");
                                produto.Exibir();

                                encontrado = true;
                                break;
                            }

                        }
                        if (!encontrado)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            break;
                        }

                        break;
                    case 4:
                        Console.WriteLine("Digite o nome do produto: ");
                        nomeBuscar = Console.ReadLine();

                        Produto remover = null;

                        foreach (Produto produto in produtos)
                        {
                            if (produto.nome.ToLower() == nomeBuscar.ToLower())
                            {
                                remover = produto;
                                break;
                            }
                        }

                        if (remover != null)
                        {
                            produtos.Remove(remover);
                            Console.WriteLine("Produto removido!");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Digite o nome do produto que deseja atualizar: ");
                        nomeBuscar = Console.ReadLine();

                        bool atualizado = false;

                        foreach (Produto produto in produtos)
                        {
                            if (produto.nome.ToLower() == nomeBuscar.ToLower())
                            {
                                Console.WriteLine("Produto encontrado! Digite os novos dados:");

                                Console.WriteLine("Novo nome:");
                                produto.nome = Console.ReadLine();

                                Console.WriteLine("Novo preço:");
                                double novoPreco = double.Parse(Console.ReadLine());
                                if (novoPreco <= 0)
                                {
                                    Console.WriteLine("Preço inválido!");
                                    break;
                                }
                                produto.preco = novoPreco;

                                Console.WriteLine("Nova marca:");
                                produto.Marca = Console.ReadLine();

                                Console.WriteLine("Nova quantidade:");
                                produto.quantidade = int.Parse(Console.ReadLine());

                                Console.WriteLine("Produto atualizado com sucesso!");
                                atualizado = true;
                                break;
                            }
                        }

                        if (!atualizado)
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }
                        break;

                    default:

                        Console.WriteLine("Opção Inválida!");
                        break;

                }


            } while (opcao != 6);
        }

    }