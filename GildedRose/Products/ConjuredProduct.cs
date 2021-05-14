namespace GildedRose.Products
{
    public class ConjuredProduct : IProduct
    {
        // Conjured stuff:
        // Twice as fast as ordinary stuff, which means:
        // Each day -2 quality and
        // when sellin < 0 then quality drops by -4
        // quality can be 0 as minimum and 50 as maximum

        public int CalcuateQuality(int quality, int sellIn)
        {
            if (quality == 0)
                return quality;

            var degradation = sellIn <= 0 ? 4 : 2;

            var updatedQuality = quality - degradation;

            return updatedQuality < 0 ? 0 : updatedQuality;
        }
    }
}
