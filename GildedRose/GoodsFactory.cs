using GildedRose.Products;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public static class GoodsFactory
    {
        public static Dictionary<string, Func<IProduct>> factories = new Dictionary<string, Func<IProduct>>
        {
            { "Sulfuras, Hand of Ragnaros", () => new LegendaryProduct() },
            { "Aged Brie", () => new AgedProduct() },
            { "Backstage passes to a TAFKAL80ETC concert", () => new TicketProduct() },
            { "Conjured Mana Cake", () => new ConjuredProduct() }
        };

        public static IProduct Get(string type)
        {
            if (factories.TryGetValue(type, out Func<IProduct> product))
            {
                return product();
            }

            // returning default product
            return new OrdinaryProduct();
        }
    }
}
