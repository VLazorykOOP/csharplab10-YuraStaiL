namespace Lab9_10CharpT
{
    public class Lab10T2
    {
        public static void Run()
        {
            Car myCar = new Car("Toyota", "Corolla", 2020);

            myCar.BrakeApplied += (sender, e) =>
            {
                Console.WriteLine("Спрацювали гальма! Перевірте стан автомобіля.");
            };


            myCar.StartEngine();
            myCar.ShiftGear(1);

            // Рух автомобіля
            myCar.Accelerate(50);

            // Відкриття дверей
            myCar.ToggleDoors();

            // Спрацювання гальм
            myCar.ApplyBrake();

            // Зупинка двигуна
            myCar.StopEngine();
        }
    }
}
