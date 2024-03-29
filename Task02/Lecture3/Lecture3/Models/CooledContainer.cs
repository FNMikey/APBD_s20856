using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class CooledContainer : Container
    {
        public enum ProductType
        {
            Bananas,Chocolate, Fish, Meat, IceCream,FrozenPizza, Cheese, Sausages, Butter, Eggs
        };

        public ProductType StoredProductType{ get; set; }
        public double StoreProductTemperature { get; set; }

        private readonly Dictionary<ProductType, double> _productTypesAndTemperatures = new Dictionary<ProductType, double>() 
        {

            { ProductType.Bananas, 13.3 },
            { ProductType.Chocolate, 18 },
            { ProductType.Fish, 2 },
            { ProductType.Meat, -15 },
            { ProductType.IceCream, -18 },
            { ProductType.FrozenPizza, -30 },
            { ProductType.Cheese, 7.2 },
            { ProductType.Sausages, 5 },
            { ProductType.Butter, 20.5 },
            { ProductType.Eggs, 19 }

        };


        public CooledContainer(double ownWeight, int height, int depth, double maxLoadCapacity, ProductType productType)
            : base(ownWeight, height, depth, maxLoadCapacity, ContainerType.C)
        {
            StoredProductType = productType;
            StoreProductTemperature = _productTypesAndTemperatures[productType];
        }

        public override void UnloadContainer()
        {
            LoadMass = 0;
        }

       
    }

}
