using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class ComissionBl
    {
        public decimal GetCommisionForIndividual(int amountTravelers, int tripDuration, IList<Product> products)
        {
            decimal commision = 0;

            foreach (var product in products)
            {
                if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_HOTEL)
                {
                    if (tripDuration < 6)
                    {
                        commision += 0.5m * (decimal)product.Price;
                    }
                    else
                    {
                        commision += (decimal)product.Price;
                    }
                }
                else if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_CAR)
                {
                    commision += ((decimal)(100 * product.Category) + 0.01m * (decimal)product.Price);
                }
                else if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_PLANETICKET)
                {
                    commision = 0.1m * (decimal)product.Price;
                }
            }

            commision *= amountTravelers;

            return commision;
        }

        public decimal GetCommisionForCorporate(int amountTravelers, int tripDuration, IList<Product> products)
        {
            decimal commision = 0;

            foreach (var product in products)
            {
                if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_HOTEL)
                {
                    commision += (decimal)product.Price * tripDuration;
                }
                else if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_CAR)
                {
                    commision +=  (decimal)product.Price * tripDuration;
                }
                else if (product.ProductTypeId == (int?)ProductType.Type.PRODUCT_PLANETICKET)
                {
                    commision += 2 * (decimal)product.Price;
                }
            }

            commision *= amountTravelers * 0.1m;

            return commision;
        }

        public decimal GetComission(Reservation reservation)
        {
            PackageBl packageBl = new PackageBl();

            decimal commision = 0;
            Package package = reservation.Package;

            int? clientTypeId = reservation.ClientTypeId;
            int amountTravelers = reservation.AmountTravelers;
            int tripDuration = reservation.DurationStay;

            foreach (var packageId in reservation.TravelPackageIds)
            {
                IList<Product> products = packageBl.GetProducts(packageId);

                if (clientTypeId == 2) // Coorporate
                {
                    commision += GetCommisionForCorporate(amountTravelers, tripDuration, products);
                }
                else if (clientTypeId == 1) // Individual
                {
                    commision += GetCommisionForIndividual(amountTravelers, tripDuration, products);
                }
            }

            return commision;
        }
    }
}