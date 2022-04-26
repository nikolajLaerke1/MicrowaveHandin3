using System;
using System.Threading;
using System.Timers;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
	public class Beeper : IBeeper
	{
		private readonly IOutput beeperOutput;
		
		public Beeper(IOutput output)
		{
			beeperOutput = output;
		}

		public void Start()
		{
			for (var i = 0; i < 3; i++)
			{
				beeperOutput.OutputLine("* B E E P *");
				Thread.Sleep(500);
			}
		}
	}
}
