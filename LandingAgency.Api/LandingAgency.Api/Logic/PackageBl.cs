using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class PackageBl
    {
        public IList<Package> GetAll()
        {
            using (var context = new LandingAgencyModel())
            {
                return context.Package.ToList();
            }
        }

        public IList<Package> GetPackageByDescription(string description)
        {
            using (var context = new LandingAgencyModel())
            {
                var packages = context.Package.ToList();

                if (description != null)
                {
                    packages.RemoveAll(item => !item.PackageName.Contains(description));
                }

                return packages;
            }
        }

        public Package GetPackageById(int id)
        {
            using (var context = new LandingAgencyModel())
            {
                return context.Package.First(c => c.PackageId == id);
            }

        }

        public IList<Product> GetProducts()
        {

            // TO DO :::...
            using (var context = new LandingAgencyModel())
            {
                return context.Product.ToList();
            }
        }

        public decimal GetTotalPackagePrice(Package package)
        {
            // TO DO :::..
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