using StockShoe.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShoe.Interfaces
{
    public interface IStockReader
    {
        List<Shoe> GetAllShoes();
        Shoe GetShoeById(int shoeId);
    }
}
