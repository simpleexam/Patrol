using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrol
{
    internal class Guard
    {
        public void CarArrest(Object? sourceCar, EventArgs e)
        {
            if (e is SpeedEventArgs)
            {
                var speedEventArgs = (SpeedEventArgs)e;
                Console.WriteLine(speedEventArgs.Message);

                if (sourceCar is Car)
                {
                    var car = (Car)sourceCar;
                    car.StopCar();
                }
            }
        }
    }
}
