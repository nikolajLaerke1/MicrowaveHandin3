using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerTubeTest
    {
        private PowerTube uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            TubePower p = TubePower.W700;
            uut = new PowerTube(output , p);
        }

        [TestCase(TubePower.W500,1)]
        [TestCase(TubePower.W500,50)]
        [TestCase(TubePower.W500, 100)]
        [TestCase(TubePower.W500,499)]
        [TestCase(TubePower.W500, 500)]
        [TestCase(TubePower.W700,1)]
        [TestCase(TubePower.W700,50)]
        [TestCase(TubePower.W700, 100)]
        [TestCase(TubePower.W700,699)]
        [TestCase(TubePower.W700, 700)]
        [TestCase(TubePower.W800,1)]
        [TestCase(TubePower.W800,50)]
        [TestCase(TubePower.W800, 100)]
        [TestCase(TubePower.W800,799)]
        [TestCase(TubePower.W800, 800)]
        [TestCase(TubePower.W1000,1)]
        [TestCase(TubePower.W1000,50)]
        [TestCase(TubePower.W1000, 100)]
        [TestCase(TubePower.W1000,999)]
        [TestCase(TubePower.W1000, 1000)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput(TubePower p, int power)
        {
            uut.TubePower = p;
            uut.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(TubePower.W500,-5)]
        [TestCase(TubePower.W500,-1)]
        [TestCase(TubePower.W500,0)]
        [TestCase(TubePower.W500,501)]
        [TestCase(TubePower.W500,550)]
        [TestCase(TubePower.W700,-5)]
        [TestCase(TubePower.W700,-1)]
        [TestCase(TubePower.W700,0)]
        [TestCase(TubePower.W700,701)]
        [TestCase(TubePower.W700,750)]
        [TestCase(TubePower.W800,-5)]
        [TestCase(TubePower.W800,-1)]
        [TestCase(TubePower.W800,0)]
        [TestCase(TubePower.W800,801)]
        [TestCase(TubePower.W800,850)]
        [TestCase(TubePower.W1000,-5)]
        [TestCase(TubePower.W1000,-1)]
        [TestCase(TubePower.W1000,0)]
        [TestCase(TubePower.W1000,1001)]
        [TestCase(TubePower.W1000,1050)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException(TubePower p, int power)
        {
            uut.TubePower = p;
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.TurnOn(power));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            uut.TurnOn(50);
            uut.TurnOff();
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        [Test]
        public void TurnOff_WasOff_NoOutput()
        {
            uut.TurnOff();
            output.DidNotReceive().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void TurnOn_WasOn_ThrowsException()
        {
            uut.TurnOn(50);
            Assert.Throws<System.ApplicationException>(() => uut.TurnOn(60));
        }
    }
}