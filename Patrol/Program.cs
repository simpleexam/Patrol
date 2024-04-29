namespace Patrol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car>  cars = new List<Car>();

            cars.Add(new Car("зеленый"));
            cars.Add(new Car("красный"));
            cars.Add(new Car("синий"));
            cars.Add(new Car("черный"));

            Guard guard = new Guard();

            foreach (Car car in cars)
            {
                car.OverSpeedEvent += guard.CarArrest;
            }

            for(int i = 1; i< 15; i++)
            {
                cars[0].Acselleration(2*i);
                cars[1].Acselleration(2+i);
                cars[2].Acselleration(2/i);
                cars[3].Acselleration(5+i);
            }

        }
    }
}