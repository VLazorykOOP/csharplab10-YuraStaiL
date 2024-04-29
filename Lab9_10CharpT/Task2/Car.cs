namespace Lab9_10CharpT
{
    public class Car
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Speed { get; private set; }
        public int Gear { get; private set; }
        public bool EngineRunning { get; private set; }
        public bool DoorsOpen { get; private set; }

        // Подія для спрацювання гальм
        public event EventHandler BrakeApplied;

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            Speed = 0;
            Gear = 1;
            EngineRunning = false;
            DoorsOpen = false;
        }

        public void StartEngine()
        {
            if (!EngineRunning)
            {
                EngineRunning = true;
                Console.WriteLine("Двигун запущено.");
            }
            else
            {
                Console.WriteLine("Двигун вже запущено.");
            }
        }

        public void StopEngine()
        {
            if (EngineRunning)
            {
                EngineRunning = false;
                Speed = 0;
                Gear = 1;
                Console.WriteLine("Двигун зупинено.");
            }
            else
            {
                Console.WriteLine("Двигун вже зупинено.");
            }
        }

        public void ShiftGear(int gear)
        {
            if (EngineRunning && gear >= 1 && gear <= 5)
            {
                Gear = gear;
                Console.WriteLine($"Передача перемикнута на {gear}.");
            }
            else
            {
                Console.WriteLine("Неможливо перемкнути передачу.");
            }
        }

        public void ToggleDoors()
        {
            DoorsOpen = !DoorsOpen;
            if (DoorsOpen)
            {
                Console.WriteLine("Двері відкрито.");
            }
            else
            {
                Console.WriteLine("Двері закрито.");
            }
        }

        public void Accelerate(int speed)
        {
            if (EngineRunning && Gear > 0 && !DoorsOpen)
            {
                Speed += speed;
                Console.WriteLine($"Рух зі швидкістю {Speed} км/год.");
            }
            else
            {
                Console.WriteLine("Не можна рухатись. Перевірте, чи двигун запущено, передача включена, двері закриті.");
            }
        }

        // Метод для спрацювання гальм
        public void ApplyBrake()
        {
            if (Speed > 0)
            {
                Speed = 0;
                Console.WriteLine("Гальма спрацювали.");
                OnBrakeApplied(EventArgs.Empty); // Виклик події спрацювання гальм
            }
            else
            {
                Console.WriteLine("Автомобіль стоїть.");
            }
        }

        // Виклик події спрацювання гальм
        protected virtual void OnBrakeApplied(EventArgs e)
        {
            BrakeApplied?.Invoke(this, e);
        }
    }
}
