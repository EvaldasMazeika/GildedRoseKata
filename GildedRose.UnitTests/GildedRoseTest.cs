using Xunit;
using System.Collections.Generic;

namespace GildedRose.UnitTests
{
    public class GildedRoseTest
    {
        // ordinary stuff:
        // each day -1 sellin and -1 quality
        // when sellin < 0 then quality drops by -2
        // quality can be 0 as minimum and 50 as maximum

        // Sulfuras:
        // quality is always 80
        // sellin is always the same

        // Aged Brie:
        // each day +1 when date is positive
        // each day +2 when date is negative
        // maximum quality is 50

        // Backstage passes:
        // quality drops to 0 after concert
        // quality +1 when there is more than 10 days left
        // quality +2 when 10 or less days
        // quality +3 when 5 days or less

        [Theory]
        [InlineData("Cola", 5, 7, 6)]
        [InlineData("Cola", 0, 2, 0)]
        [InlineData("Cola", -1, 0, 0)]
        [InlineData("Pepsi", 0, 10, 8)]
        [InlineData("Pepsi", -1, 8, 6)]
        [InlineData("Fanta", -5, 1, 0)] // edge case, only -1
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, 80)]
        [InlineData("Aged Brie", 2, 0, 1)]
        [InlineData("Aged Brie", 0, 2, 4)]
        [InlineData("Aged Brie", -10, 50, 50)]
        [InlineData("Aged Brie", -10, 49, 50)] // edge case, only +1
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 24, 25)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 25, 27)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 35, 38)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 47, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 49, 50)] // edge case, only +1
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 50, 0)] // edge case, goes to 0
       // [InlineData("Conjured Mana Cake", 0, 50, 0)] // implement
        public void UpdateQuality_Quality_RetursCorrectQuality(string name, int sellIn, int quality, int expectedQuality)
        {
            // Arrange
            var Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1)]
        [InlineData("Cola", 0, 2, -1)]
        [InlineData("Cola", -1, 0, -2)]
        [InlineData("Cola", 5, 7, 4)]
        public void UpdateQuality_SellIn_ReturnsCorrectSellIn(string name, int sellIn, int quality, int expectedSellIn)
        {
            // Arrange
            var Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_Name_RetursSameName()
        {
            // Arrange
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("foo", Items[0].Name);
        }
    }
}