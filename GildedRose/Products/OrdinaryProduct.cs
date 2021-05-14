namespace GildedRose.Products
{
    public class OrdinaryProduct : IProduct
    {
        // ordinary stuff:
        // each day -1 sellin and -1 quality
        // when sellin < 0 then quality drops by -2
        // quality can be 0 as minimum and 50 as maximum

        public int CalcuateQuality(int quality, int sellIn)
        {
            if (quality == 0)
                return quality;

            var degradation = sellIn <= 0 ? 2 : 1;

            var updatedQuality = quality - degradation;

            return updatedQuality < 0 ? 0 : updatedQuality;
        }
    }
}
