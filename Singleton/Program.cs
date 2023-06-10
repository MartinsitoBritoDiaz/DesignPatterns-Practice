// See https://aka.ms/new-console-template for more information

// SINGLETON
//using Singleton.Models;

//var example = Log.Instance;
//example.Save("This is a test");
//example.Save("Hello world");


// Factory
using DesignPatterns.Factory;

SalesFactory storeSaleDactory = new StoreSaleFactory(20);
SalesFactory internetSaleDactory = new InternetSaleFactory(20);

ISale storeSale = storeSaleDactory.GetSale();
storeSale.Sale(1000);

ISale internetSale = internetSaleDactory.GetSale();
internetSale.Sale(1000);