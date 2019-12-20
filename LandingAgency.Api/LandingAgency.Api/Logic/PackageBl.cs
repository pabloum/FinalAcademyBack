using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class PackageBl
    {
        public IList<Product> GetProducts()
        {
            using (var context = new LandingAgencyModel())
            {
                return context.Product.ToList();
            }
        }

        public decimal GetTotalPackagePrice(Package package)
        {
            decimal totalPrice = 0;

            IList<Product> products = GetProducts();

            foreach (var product in products)
            {
                totalPrice += (decimal)product.Price;
            }

            return totalPrice;
        }
    }
}