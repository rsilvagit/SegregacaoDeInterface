using StockShoe.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShoe.Interfaces
{
    public interface IStockWriter
    {
        void AddShoe(Shoe shoe);
        void UpdateShoe(Shoe shoe);
        void RemoveShoe(int shoeId);
    }
}
