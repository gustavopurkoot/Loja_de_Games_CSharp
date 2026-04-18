using System;
using System.Collections.Generic;

class Produto
{
    public string nome;
    public double preco;
    public ConsoleGame console;
    public int quantidade;

    public Produto(string nome, double preco, ConsoleGame console, int quantidade)
    {
        this.nome = nome;
        this.preco = preco;
        this.console = console;
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
        Console.WriteLine("Console: " + console.Nome);
        Console.WriteLine("Quantidade: " + quantidade);
        Console.WriteLine("Valor total do estoque: " + valorTotalEstoque());
    }
}

class ConsoleGame
{
    public string Nome;

    public ConsoleGame(string nome)
    {
        Nome = nome;
    }
}

class Program
{
    static void Main()
    {
        List<Produto> produtos = new List<Produto>();
        int opcao = 0;
        string nomeBuscar;

        do
        {
            Console.WriteLine("\n1 - Cadastro de Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Buscar Produto");
            Console.WriteLine("4 - Excluir Produto");
            Console.WriteLine("5 - Atualizar Produto");
            Console.WriteLine("6 - Mostrar valor total geral do estoque");
            Console.WriteLine("7 - Encerrar");

            Console.Write("Digite a opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o nome do produto: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o preço do produto: ");
                    double preco = double.Parse(Console.ReadLine());

                    Console.Write("Digite o console (PlayStation, Xbox, Nintendo, etc): ");
                    string nomeConsole = Console.ReadLine();
                    ConsoleGame console = new ConsoleGame(nomeConsole);

                    Console.Write("Digite a quantidade do produto: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    if (preco <= 0)
                    {
                        Console.WriteLine("Preço deve ser maior que 0!");
                        break;
                    }
                    if (quantidade < 0)
                    {
                        Console.WriteLine("Quantidade inválida!");
                        break;
                    }

                    produtos.Add(new Produto(nome, preco, console, quantidade));
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;

                case 2:
                    if (produtos.Count == 0)
                    {
                        Console.WriteLine("Nenhum produto cadastrado!");
                        break;
                    }

                    Console.WriteLine("Digite 1 para listar todos os produtos ou 2 para listar por console:");
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
                        Console.Write("Digite o console para filtrar: ");
                        string consoleBusca = Console.ReadLine().ToLower();

                        bool encontrou = false;

                        foreach (Produto produto in produtos)
                        {
                            if (produto.console.Nome.ToLower() == consoleBusca)
                            {
                                Console.WriteLine("-------------");
                                produto.Exibir();
                                encontrou = true;
                            }
                        }

                        if (!encontrou)
                        {
                            Console.WriteLine("Nenhum produto encontrado para esse console.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                    break;

                case 3:
                    Console.Write("Digite o nome do produto para buscar: ");
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
                    }
                    break;

                case 4:
                    Console.Write("Digite o nome do produto para remover: ");
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
                    Console.Write("Digite o nome do produto que deseja atualizar: ");
                    nomeBuscar = Console.ReadLine();

                    bool atualizado = false;

                    foreach (Produto produto in produtos)
                    {
                        if (produto.nome.ToLower() == nomeBuscar.ToLower())
                        {
                            Console.WriteLine("Produto encontrado! Digite os novos dados:");

                            Console.Write("Novo nome: ");
                            produto.nome = Console.ReadLine();

                            Console.Write("Novo preço: ");
                            double novoPreco = double.Parse(Console.ReadLine());
                            if (novoPreco <= 0)
                            {
                                Console.WriteLine("Preço inválido!");
                                break;
                            }
                            produto.preco = novoPreco;

                            Console.Write("Novo console: ");
                            string novoConsole = Console.ReadLine();
                            produto.console = new ConsoleGame(novoConsole);

                            Console.Write("Nova quantidade: ");
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

                case 6:
                    double totalGeral = 0;

                    foreach (Produto produto in produtos)
                    {
                        totalGeral += produto.valorTotalEstoque();
                    }

                    Console.WriteLine("Valor total geral do estoque: " + totalGeral);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (opcao != 7);

        Console.WriteLine("Encerrando...");
    }
}