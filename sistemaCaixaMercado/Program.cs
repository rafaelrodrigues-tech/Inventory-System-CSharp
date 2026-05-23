using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using sistemaCaixaMercado.Entities;
using sistemaCaixaMercado.Entities.Exceptions;
namespace sistemaCaixaMercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock list = new Stock();
            bool menu = true;
            while (menu)
            {
                try
                {
                    Console.WriteLine("""
                    1 - Adicionar Produto
                    2 - Remover
                    3 - Resumo 
                    0 - Sair
                    """);

                    Console.Write("Insira a opção: ");
                    int op = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    switch (op)
                    {
                        case 1:
                            Console.Write("Id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome do produto: ");
                            string name = Console.ReadLine();
                            Console.Write("Digite o preço:R$ ");
                            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Quantidade: ");
                            int quantity = int.Parse(Console.ReadLine());
                            list.AddProduct(new Product(id, name, price, quantity));
                            Console.WriteLine("Produto adicionado!");
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.Write("Tem Certeza que deseja remover?(s/n): ");
                            char cancelar = char.Parse(Console.ReadLine());
                            if (cancelar == 's')
                            {
                                Console.Write("Insira o ID do Item q deseja remover: ");
                                int removeID = int.Parse(Console.ReadLine());
                                list.RemoveProduct(removeID);
                            }
                            else
                            {
                                Console.WriteLine("Operação Cancelada!");
                            }
                            Console.WriteLine();
                            break;
                        case 3:
                            if (list.stock.Count > 0)
                            {
                                Console.WriteLine("===== RESUMO =====");
                                foreach (Product p in list.stock)
                                {
                                    Console.WriteLine(p);

                                }
                                Console.WriteLine();
                                var qtdd = list.stock.Sum(x => x.Quantity);
                                Console.WriteLine("Quantidade de produtos: " + qtdd);
                                var valueTotal = list.stock.Select(x => x.Price * x.Quantity).Sum();
                                Console.WriteLine("Valor total:R$ " + valueTotal.ToString("F2", CultureInfo.InvariantCulture));
                                var nameExpensive = list.stock.MaxBy(x => x.Price);
                                Console.WriteLine("Produto mais caro: " + nameExpensive.Name);
                                var nameCheap = list.stock.MinBy(x => x.Price);
                                Console.WriteLine("Produto mais barato: " + nameCheap.Name);
                                var valueAvg = list.stock.Select(x => x.Price).Average();
                                Console.WriteLine("Média dos preços: " + valueAvg.ToString("F2", CultureInfo.InvariantCulture));
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Sua lista está vazia!");
                            }
                            break;
                        case 0:
                            Console.WriteLine("Encerrando o Sistema...");
                            Thread.Sleep(2000);
                            menu = false;

                            break;

                        default:
                            Console.WriteLine("Opção Inválida!");
                            Console.WriteLine();
                            break;
                    }

                }
                catch (ArgumentException m)
                {
                    Console.WriteLine("Error:" + m.Message);
                }
            }
        }
    }
}