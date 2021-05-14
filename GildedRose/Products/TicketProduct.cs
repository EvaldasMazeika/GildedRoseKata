namespace GildedRose.Products
{
    public class TicketProduct : IProduct
    {
        // Backstage passes:
        // quality drops to 0 after concert
        // quality +1 when there is more than 10 days left
        // quality +2 when 10 or less days
        // quality +3 when 5 days or less

        public int CalcuateQuality(int quality, int sellIn)
        {
            if (sellIn <= 0)
                return 0;

            var upgrade = sellIn > 10 ? 1 : sellIn > 5 ? 2 : 3;

            var updatedQuality = quality + upgrade;

            return updatedQuality > 50 ? 50 : updatedQuality;
        }
    }
}
