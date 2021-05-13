using Xunit;
using System.Collections.Generic;

namespace GildedRose.UnitTests
{
    public class GildedRoseTest
    {
        // each day lower sellin, can be minus 
        // each day lower quality by 1 , cant get lower than 0, when sellin is <0 then quality by 2
        // Agied Brie quality +1 every day buy when date is passed +2
        // quality max is 50
        // sulfuras, nothing changes?, always quality 80
        // Backstage passes like Brie? but has interesting logic to it
        // 

        [Fact]
        public void foo()
        {
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}