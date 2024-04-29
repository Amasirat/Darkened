using Entities;

namespace EntitiesTest;

[TestClass]
public class StatTest
{
    [TestMethod]
    public void TestChangeMaxUp()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            int previousAmount = stat.Max;
            stat.Max += i;
            bool result = previousAmount < stat.Max;
            Assert.IsTrue(result, $"Expected {i} to increase Max value of stat");
        }
    }

    [TestMethod]
    public void TestChangeMaxDown()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            int previousAmount = stat.Max;
            stat.Max -= i;
            bool result = previousAmount < stat.Max;
            Assert.IsFalse(result, $"Expected {i} to decrease Max value of stat");
        }
    }
    [TestMethod]
    public void TestMaxValueChangeBeOne()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            stat.Max -= i;
            bool result = stat.Max == 1;
            Assert.IsTrue(result, $"Expected {i} to make max value 1");
        }
    }
    [TestMethod]
    public void TestChangeValueUp()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            int previousAmount = stat.Max;
            stat.Value += i;
            bool result = previousAmount < stat.Max;
            Assert.IsFalse(result, $"Expected {i} to increase Max value of stat");
        } 
    }

    [TestMethod]
    public void TestChangeValueDown()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            int previousAmount = stat.Max;
            stat.Value -= i;
            bool result = previousAmount < stat.Max;
            Assert.IsFalse(result, $"Expected {i} to decrease value of stat");
        }
    }

    [TestMethod]
    public void TestValueChangeBeZero()
    {
        int[] amounts = {2, 3, 8, 9, 10, 47};

        Stat stat = new Stat(Stat.StatType.HP, 1);

        foreach(var i in amounts)
        {
            stat.Value -= i;
            bool result = stat.Value == 0;
            Assert.IsTrue(result, $"Expected {i} to make value zero");
        }
    }
}
