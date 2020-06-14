using System;
using FSharpCode;

namespace CSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(4, "Supacars", Tuple.Create(3.5, 3.5));
            System.Console.WriteLine(car.Brand);

            var motorBike = FSharpCode.Vehicle.NewMotorbike("Yamaha", 4.5) as  FSharpCode.Vehicle.Motorbike;
            System.Console.WriteLine(motorBike.Name);

            var somewheeledCar =  FSharpCode.Functions.CreateCar(4, "Supacars", 1.5, 3.5);  
            var fourWheeledCar =  FSharpCode.Functions.CreateFourWheeledCar                              
                       .Invoke("Supacars")
                       .Invoke(1.5)
                       .Invoke(3.5);
        }
    }
}
