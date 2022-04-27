using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();
            Button decreaseTimerButton = new();
            Button increaseTimerButton = new();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            // TubePower power = TubePower.W700;
            // PowerTube powerTube = new PowerTube(output, power);
            PowerTube powerTube = new PowerTube(output);
            Light light = new Light(output);

            // Beeper beeper = new Beeper(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            // CookController cooker = new CookController(timer, display, powerTube);
            CookController cooker = new CookController(timer, display, powerTube);

            // UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, beeper, cooker);
            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, decreaseTimerButton,
                increaseTimerButton, door, display, light, cooker);
            

            // Finish the double association
            // cooker.UI = ui;

            // Simulate a simple sequence
            
                powerButton.Press();
                

                timeButton.Press();

                startCancelButton.Press();

                // The simple sequence should now run
                
                // Simulate increasing the timer
                increaseTimerButton.Press();

                // Simulate reducing the timer
                // decreaseTimerButton.Press();
                System.Console.WriteLine("Press 'enter' to stop");

                Console.ReadLine();

                // Wait for input
        }

        
    }
}
