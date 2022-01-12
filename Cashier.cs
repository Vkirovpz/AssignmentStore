using AssigmentStore.Products.Contracts;
using System;
using System.Text;
using AssigmentStore.Products;
using System.Collections.Generic;

namespace AssigmentStore
{
    public class Cashier
    {
        public string PrintReceipt(Cart cart, DateTime timeOfPurchase)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Date: {timeOfPurchase}");
            sb.AppendLine();
            sb.AppendLine("---Products---");

            var totalSum = 0.0;
            var totalDiscount = 0.0;
            var weekendDays = new List<string> { "Saturday", "Sunday" };

            foreach (var product in cart.products)
            {
                sb.AppendLine();
                var priceWithoutDiscount = Math.Round((product.Quantity * product.Price), 2);
                totalSum += priceWithoutDiscount;

                var isProductPerishable = product is IPerishable;

                if(isProductPerishable)
                {
                    sb.AppendLine($"{product.Name} {product.Brand}");
                    sb.AppendLine($"{product.Quantity} x ${product.Price} = ${priceWithoutDiscount}");
                    var perishableProduct = product as IPerishable;
                    var expired = perishableProduct.ExpirationDate - timeOfPurchase;

                    if( expired.TotalDays >= 1 && expired.TotalDays <= 5)
                    {
                        var discountInPercents = 10;
                        var currentDiscount = Math.Round((priceWithoutDiscount * 0.1), 2);
                        totalDiscount += currentDiscount;
                        sb.AppendLine($"#discount {discountInPercents}% -${currentDiscount}");

                    }
                    else if(expired.TotalDays < 1)
                    {
                        var discountInPercents = 50;
                        var currentDiscount = Math.Round((priceWithoutDiscount * 0.5), 2);
                        totalDiscount += currentDiscount;
                        sb.AppendLine($"#discount {discountInPercents}% -${currentDiscount}");
                    }
                    continue;
                }

                var isProductClothes = product is Clothes;
                if (isProductClothes)
                {
                    var clotheProduct = product as Clothes;

                    sb.AppendLine($"{clotheProduct.Name} {clotheProduct.Brand} {clotheProduct.Size} {clotheProduct.Color}");
                    sb.AppendLine($"{clotheProduct.Quantity} x ${clotheProduct.Price} = ${priceWithoutDiscount}");

                    var dayOfWeek = timeOfPurchase.DayOfWeek.ToString();

                    if (!weekendDays.Contains(dayOfWeek))
                    {
                        var discountInPercents = 10;
                        var currentDiscount  = Math.Round((priceWithoutDiscount * 0.1), 2);
                        totalDiscount += currentDiscount;
                        sb.AppendLine($"#discount {discountInPercents}% -${currentDiscount}");
                    }
                    continue;
                }

                var isProductAppliance = product is Appliances;
                if (isProductAppliance)
                {
                    var applianceProduct = product as Appliances;
                    sb.AppendLine($"{applianceProduct.Name} {applianceProduct.Brand} {applianceProduct.Model}");
                    sb.AppendLine($"{product.Quantity} x ${product.Price} = ${priceWithoutDiscount}");

                    var dayOfWeek = timeOfPurchase.DayOfWeek.ToString();
                   
                    if (weekendDays.Contains(dayOfWeek) && priceWithoutDiscount > 999)
                    {
                        var discountInPercents = 5;
                        var currentDiscount  = Math.Round((priceWithoutDiscount * 0.05), 2);
                        totalDiscount += currentDiscount;
                        sb.AppendLine($"#discount {discountInPercents}% -${currentDiscount}");
                    }
                    continue;
                }
            };
            var sumToPay = totalSum - totalDiscount;
            sb.AppendLine("-----------------------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine($"SUBTOTAL: ${totalSum}");
            sb.AppendLine($"DISCOUNT: -${totalDiscount}");
            sb.AppendLine();
            sb.AppendLine($"TOTAL: ${sumToPay}");


            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
