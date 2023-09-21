using StockShoe.Class;
using StockShoe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShoe.Services
{
    public class ConsoleStockManager : IStockReader, IStockWriter, IStockReporter
    {
        private List<Shoe> stock = new List<Shoe>();

        public void GenerateStockReport()
        {
            Console.WriteLine("Relatório de Estoque:");
            foreach (var shoe in stock)
            {
                Console.WriteLine($"ID: {shoe.Id} | Nome: {shoe.Name} | Quantidade: {shoe.Quantity}| Preço: {shoe.Price:C}");
            }
        }

        public void AddShoe(Shoe shoe)
        {
            if (shoe != null)
            {
                stock.Add(shoe);
            }
            else
            {
                throw new ArgumentNullException(nameof(shoe), "O argumento 'shoe' não pode ser nulo.");
            }
        }

        public List<Shoe> GetAllShoes()
        {
            return stock;
        }

        public Shoe GetShoeById(int shoeId)
        {
            Shoe shoe = stock.Find(s => s.Id == shoeId);

            if (shoe == null)
            {
                throw new ArgumentException("O calçado com o ID especificado não foi encontrado.");
            }

            return shoe;
        }

        public void RemoveShoe(int shoeId)
        {
            var existingShoe = GetShoeById(shoeId);
            if (existingShoe != null)
            {
                stock.Remove(existingShoe);
            }
            else
            {
                throw new ArgumentException("O calçado com o ID especificado não foi encontrado, Deleção não realizada");
            }
        }

        public void UpdateShoe(Shoe updateShoe)
        {
            var existingShoe = GetShoeById(updateShoe.Id);
            if (existingShoe != null)
            {
                existingShoe.Name = updateShoe.Name;
                existingShoe.Quantity = updateShoe.Quantity;
                existingShoe.Price = updateShoe.Price;
            }
            else
            {
                throw new ArgumentException("O calçado com o ID especificado não foi encontrado, Update não realizado");
            }
        }
    }
}

