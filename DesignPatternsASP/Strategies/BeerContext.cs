using DesignPatterns.Repository.UnitOfWork;
using DesignPatternsASP.Models.ViewModels;

namespace DesignPatternsASP.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _strategy { get; set; }

        public IBeerStrategy Strategy
        {
            set { _strategy = value; }
        }
        public BeerContext(IBeerStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork) 
        { 
            _strategy.Add(beerVM, unitOfWork);
        }
    }
}
