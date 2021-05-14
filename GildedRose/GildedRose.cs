using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> items;

        public IEnumerable<Item> Items 
        { 
            get { return items; } 
        }

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                // Since there is possibility that new items with unique logic will be added in the future
                // to avoid if else hell and SOLID violation - smart idea to extend products. 

                // this is more like a service which doesnt hold any state jsut does calculation for specific type of products. 
                var product = GoodsFactory.Get(item.Name);

                item.Quality = product.CalcuateQuality(item.Quality, item.SellIn);
                item.SellIn = product.CalculateSellIn(item.SellIn);
            }
        }
    }
}
