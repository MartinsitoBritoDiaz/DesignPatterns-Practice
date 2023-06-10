using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    //Creator
    public abstract class SalesFactory
    {
        public abstract ISale GetSale();
    }

    //Concrete Creator
    public class StoreSaleFactory : SalesFactory
    {
        private decimal _extra;
        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }

        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
    }

    //Concrete Product
    public class StoreSale : ISale
    {
        private readonly decimal _extra;
        public StoreSale(decimal extra)
        {
            _extra = extra;
        }
        public void Sale(decimal amount)
        {
            Console.WriteLine($"Store sale has an amount of {amount + _extra}");
        }
    }

    //Product
    public interface ISale
    {
        public void Sale(decimal amount);
    }

    //Concrete Creator Internet
    public class InternetSaleFactory : SalesFactory
    {
        private decimal _discount;
        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }

        public override ISale GetSale()
        {
            return new InternetSale(_discount);
        }
    }

    //Concrete Product Internet
    public class InternetSale : ISale
    {
        private readonly decimal _discount;
        public InternetSale(decimal discount)
        {
            _discount = discount;
        }
        public void Sale(decimal amount)
        {
            Console.WriteLine($"Internet sale has an amount of {amount - _discount}");
        }
    }


}
