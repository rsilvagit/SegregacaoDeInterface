using StockShoe.Class;
using StockShoe.Interfaces;
using StockShoe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShoe
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockManager = new ConsoleStockManager();
            //IStockReader stockReader = new ConsoleStockManager();
            //IStockReporter stockReporter = new ConsoleStockManager();
            //IStockWriter stockWriter = new ConsoleStockManager();



            while (true)
            {
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1. Adicione o Calçado");
                Console.WriteLine("2. Procure o Calçado pelo ID");
                Console.WriteLine("3. Remova o Calçado do Estoque");
                Console.WriteLine("4. Relatório de estoque");
                Console.WriteLine("5. Sair");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        int id;
                        string name;
                        int quantity;
                        decimal price;


                        bool isValidId = false;
                        do
                        {
                            Console.Write("Digite o ID: ");
                            string idInput = Console.ReadLine();
                            if (int.TryParse(idInput, out id))
                            {
                                isValidId = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Digite um valor numérico válido para o ID.");
                            }
                        } while (!isValidId);


                        Console.Write("Digite o nome: ");
                        name = Console.ReadLine();


                        bool isValidQuantity = false;
                        do
                        {
                            Console.Write("Digite a quantidade: ");
                            string quantityInput = Console.ReadLine();
                            if (int.TryParse(quantityInput, out quantity))
                            {
                                isValidQuantity = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Digite um valor numérico válido para a quantidade.");
                            }
                        } while (!isValidQuantity);
                        bool isValidPrice = false;
                        do
                        {
                            Console.Write("Digite o preço: ");
                            string priceInput = Console.ReadLine();
                            if (decimal.TryParse(priceInput, out price))
                            {
                                isValidPrice = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Digite um valor numérico válido para o preço.");
                            }
                        } while (!isValidPrice);

                        Shoe newShoe = new Shoe { Id = id, Name = name, Quantity = quantity, Price = price };
                        stockManager.AddShoe(newShoe);
                        Console.WriteLine("Calçado adicionado ao estoque com sucesso!");
                        break;
                    case "2":
                        int idToFind;
                        bool isValidIdToFind = false;
                        do
                        {
                            Console.Write("Digite o ID do calçado que está procurando: ");
                            string idInput = Console.ReadLine();
                            if (int.TryParse(idInput, out idToFind))
                            {
                                isValidIdToFind = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Digite um valor numérico válido para o ID.");
                            }
                        } while (!isValidIdToFind);

                        Shoe foundShoe = stockManager.GetShoeById(idToFind);

                        if (foundShoe != null)
                        {
                            Console.WriteLine($"Calçado encontrado: ID: {foundShoe.Id}, Nome: {foundShoe.Name}, Quantidade: {foundShoe.Quantity}, Preço: {foundShoe.Price:C}");
                        }
                        else
                        {
                            Console.WriteLine("Calçado não encontrado no estoque.");
                        }
                        break;
                    case "3":
                        int idToRemove;

                        bool isValidIdToRemove = false;
                        do
                        {
                            Console.Write("Digite o ID do calçado que deseja remover do estoque: ");
                            string idInput = Console.ReadLine();
                            if (int.TryParse(idInput, out idToRemove))
                            {
                                isValidIdToRemove = true;
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Digite um valor numérico válido para o ID.");
                            }
                        } while (!isValidIdToRemove);

                        try
                        {
                            stockManager.RemoveShoe(idToRemove);
                            Console.WriteLine("Calçado removido com sucesso!");
                        }
                        catch
                        {
                            Console.WriteLine($"Ocorreu um erro ao tentar remover o calçado com ID: {idToRemove}");
                        }
                        break;

                    case "4":
                        stockManager.GenerateStockReport();
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Por favor tente novamente.");
                        break;
                }
            }

        }
    }
}
