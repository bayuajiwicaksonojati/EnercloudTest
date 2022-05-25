using Utilities;
using Xunit;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(allIndexOf_passingTestData))]
    public void AllIndexOf_Passing(List<int> expectedResult, string text, string comparer)
    {
        Assert.Equal(expectedResult, text.AllIndexOf(comparer));
    }

    [Theory]
    [MemberData(nameof(allIndexOf_failingTestData))]
    public void AllIndexOf_Failing(List<int> expectedResult, string text, string comparer)
    {
        Assert.NotEqual(expectedResult, text.AllIndexOf(comparer));
    }

    [Theory]
    [InlineData("","")]
    [InlineData("Quick brown fox","")]
    [InlineData("","jumps over a lazy dog")]
    public void AllIndexOf_FailingEmpty(string test, string comparer)
    {
        Assert.Throws<ArgumentNullException>(() => test.AllIndexOf(comparer));
    }

    public static IEnumerable<object[]> allIndexOf_passingTestData()
    {
        yield return new object[]{new List<int>(){0,7}, "I wAnT IcE CrEaM", "i"};
        yield return new object[]{new List<int>(){11}, "I wAnT IcE CrEaM", "cream"};
        yield return new object[]{new List<int>(){9,13}, "I wAnT IcE CrEaM", "e"};
        yield return new object[]{new List<int>(){7}, "I wAnT IcE CrEaM", "ICE"};
        yield return new object[]{new List<int>(){}, "I wAnT IcE CrEaM", "potato"};
        yield return new object[]{new List<int>(){0,2,4,6,8}, "okokokokok", "ok"};
    }

    public static IEnumerable<object[]> allIndexOf_failingTestData()
    {
        yield return new object[]{new List<int>(){0}, "I wAnT IcE CrEaM", "i"};
        yield return new object[]{new List<int>(){10}, "I wAnT IcE CrEaM", "cream"};
        yield return new object[]{new List<int>(){9}, "I wAnT IcE CrEaM", "e"};
        yield return new object[]{new List<int>(){}, "I wAnT IcE CrEaM", "ICE"};
        yield return new object[]{new List<int>(){0}, "I wAnT IcE CrEaM", "potato"};
    }
}