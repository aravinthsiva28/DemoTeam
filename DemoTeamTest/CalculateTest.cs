using DemoTeam.Controllers;
using NUnit.Framework;

namespace DemoTeamTest
{
    [TestFixture]
    public class CalculateTest
    {
        [TestCase(10,2,5)]
        [TestCase(1,0,0)]
        public void CalculateValidation(int a,int b,decimal res)
        {
            var test = new ValuesController();

            decimal val = test.Calculate(a, b);

            Assert.AreEqual(res, val);
        }
    }
}