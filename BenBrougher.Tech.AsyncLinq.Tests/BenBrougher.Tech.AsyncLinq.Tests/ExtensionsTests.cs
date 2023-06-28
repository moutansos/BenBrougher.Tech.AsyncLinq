namespace BenBrougher.Tech.AsyncLinq.Tests;

[TestClass]
public class ExtensionsTests
{

    [TestMethod]
    public async Task SelectAsyncTest()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        var expected = new[] { 2, 4, 6, 8, 10 };
        var actual = await source.SelectAsync(async x => x * 2);
        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [TestMethod]
    public async Task SelectManyAsyncTest()
    {
        var source = new[] { 1, 2, 3, 4, 5 };
        var expected = new[] { 1, 2, 3, 4, 5, 2, 4, 6, 8, 10 };
        var actual = await source.SelectManyAsync<int, int>(async x => new[] { x, x * 2 });
        CollectionAssert.AreEquivalent(expected, actual.ToArray());
    }
}