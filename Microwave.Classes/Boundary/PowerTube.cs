using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public enum TubePower
    {
        W500 = 500,
        W700 = 700,
        W800 = 800,
        W1000 = 1000
    }
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;
        private TubePower tubePower;

        private bool IsOn = false;

        public PowerTube(IOutput output, TubePower power)
        {
            myOutput = output;
            tubePower = power;
        }

        public void TurnOn(int power)
        {
            if (power < 1 || (int)tubePower < power)
            {
                throw new ArgumentOutOfRangeException("power", power, "Must be between 1 and {tubePower} (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}