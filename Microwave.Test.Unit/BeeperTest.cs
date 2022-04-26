using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit;

[TestFixture]
public class BeeperTest
{
	private IOutput output;
	private Beeper uut;

	[SetUp]
	public void Setup()
	{
		output = Substitute.For<IOutput>();
		uut = new Beeper(output);
	}

	[Test]
	public void Start_BeepOutputThreeTimes()
	{
		uut.Start();
		output.Received(3).OutputLine("* B E E P *");
	}
}
