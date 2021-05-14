using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Products
{
    public class LegendaryProduct : IProduct
    {
        // Sulfuras:
        // quality is always 80
        // sellin is always the same

        public int CalcuateQuality(int quality, int sellIn) => quality;

        public int CalculateSellIn(int sellIn) => sellIn;
    }
}
