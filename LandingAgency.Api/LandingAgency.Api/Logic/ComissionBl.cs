using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class ComissionBl
    {
        public decimal GetComission(Reservation reservation)
        {
            decimal comission = 0;
            Client client = reservation.Client;
            Package package = reservation.Package;

            PackageBl packageBl = new PackageBl();
            ProductBl productBl = new ProductBl();

            string clientType = client.ClientType.ClientTypeName;
            
            IList<Product> products = packageBl.GetProducts();

            if (clientType == ClientType.CLIENT_COORPORATE)
            {
                foreach (var product in products)
                {
                    string productType = productBl.GetProductTypeFromId(product.ProductTypeId);

                    if (productType == ProductType.PRODUCT_HOTEL)
                    {
                        comission += (decimal)product.Price * reservation.DurationStay;
                    }
                    else if (productType == ProductType.PRODUCT_CAR)
                    {
                        comission += reservation.DurationStay*(decimal)product.Price;
                    }
                    else if (productType == ProductType.PRODUCT_PLANETICKET)
                    {
                        comission += 2 * (decimal)product.Price;
                    }
                }

                comission *= reservation.AmountTravelers * 0.1m;
            }
            else if (clientType == ClientType.CLIENT_INDIVIDUAL)
            {
                foreach (var product in products)
                {
                    string productType = productBl.GetProductTypeFromId(product.ProductTypeId);

                    if (productType == ProductType.PRODUCT_HOTEL)
                    {
                        if (reservation.DurationStay < 6)
                        {
                            comission += 0.5m * (decimal)product.Price;
                        }
                        else
                        {
                            comission += (decimal)product.Price;
                        }
                    }
                    else if (productType == ProductType.PRODUCT_CAR)
                    {
                        comission += ((decimal)(100*product.Category) + 0.01m * (decimal)product.Price);
                    }
                    else if (productType == ProductType.PRODUCT_PLANETICKET) 
                    {
                        comission *= 1.1m;
                    }
                }

                comission *= reservation.AmountTravelers;
            }

            return comission;
        }
    }
}