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
                return context.Package.ToList(); ;
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
                var package = context.Package.First(c => c.PackageId == id);
                package.Products = GetProducts(package.PackageId);
                return package;
            }
        }

        public IList<Product> GetProducts(int packageId)
        {
            using (var context = new LandingAgencyModel())
            {
                return context.PackageProduct.Where(p => p.PackageId == packageId).Select(p => p.Product).ToList();
            }
        }

        public decimal GetTotalPackagePrice(Package package)
        {
            decimal totalPrice = 0;

            IList<Product> products = GetProducts(package.PackageId);

            foreach (var product in products)
            {
                totalPrice += (decimal)product.Price;
            }

            return totalPrice;
        }
    }
}