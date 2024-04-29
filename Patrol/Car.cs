using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrol
{
    public  class Car
    {
        public string GosNomer { get; set; }
        public int Speed { get; set; } = 0;
        public static int LimitSpeed = 80; //допустимая скорость 

        public void Acselleration(int addedSpeed)
        {
            Console.WriteLine($"\t{GosNomer} {Speed}");
            Speed+=addedSpeed;
            if(Speed > LimitSpeed)
                OnOverSpeedEvent(); //вызов метода генерации события
        }
        public void StopCar()
        {
            Speed = 0;
            Console.WriteLine("автомобиль остановлен");
        }

        public Car(string gn)=>
            GosNomer = gn;

        public event EventHandler? OverSpeedEvent; //событие превышения скорости
        private void OnOverSpeedEvent() //метод генерации события
        {
            int overSpeed = this.Speed - LimitSpeed; //вычисление превышения
            //сборка информации о параметрах события (сообщение и превышение)
            SpeedEventArgs e = new SpeedEventArgs($"автомобиль {this.GosNomer} превысил скорость на {overSpeed}",
                overSpeed);

            //if(OverSpeedEvent != null)
            //{
            //    OverSpeedEvent(this, e);
            //}

            OverSpeedEvent?.Invoke(this, e);
        }

    }
    /// <summary>
    /// аргумент события содержащий сообщение о событии
    /// и скорости объекта.
    /// </summary>
    public class SpeedEventArgs : EventArgs
    {
        public int OverSpeed { get; set; }
        public string Message { get; set; }
        public SpeedEventArgs(string mes, int overSpeed)
        {
            Message = mes;
            OverSpeed = overSpeed;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
