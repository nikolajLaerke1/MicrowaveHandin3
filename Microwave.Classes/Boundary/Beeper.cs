using System;
using System.Threading;
using System.Timers;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
	public class Beeper : IBeeper
	{
		private readonly IOutput beeperOutput;
		private const int BeepInterval = 500;
		
		public Beeper(IOutput output)
		{
			beeperOutput = output;
		}

		public void Start()
		{
			Beep(3);
		}

		private void Beep(int times)
		{
			for (var i = 0; i < times; i++)
			{
				beeperOutput.OutputLine("* B E E P *");
				Thread.Sleep(BeepInterval);
			}
		}
	}
}
