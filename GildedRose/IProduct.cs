namespace GildedRose
{
    public interface IProduct
    {
        // c# 8.0 feature of default interface implementation
        int CalculateSellIn(int sellIn) => sellIn - 1;

        int CalcuateQuality(int quality, int sellIn);
    }
}
