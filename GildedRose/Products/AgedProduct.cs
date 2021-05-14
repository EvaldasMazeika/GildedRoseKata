namespace GildedRose.Products
{
    public class AgedProduct : IProduct
    {
        // Aged Brie:
        // each day +1 when date is positive
        // each day +2 when date is negative
        // maximum quality is 50

        public int CalcuateQuality(int quality, int sellIn)
        {
            if (quality == 50)
                return quality;

            var upgrade = sellIn <= 0 ? 2 : 1;

            var updatedQuality = quality + upgrade;

            return updatedQuality > 50 ? 50 : updatedQuality;
        }
    }
}
