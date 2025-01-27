using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9999
{
    internal class WeatherArray
    {
        private Weather[] array;
        private static int arrayCount = 0;

        // Конструктор без параметров
        public WeatherArray()
        {
            array = new Weather[0];
            arrayCount++;
        }

        // Конструктор с параметрами для случайной генерации
        public WeatherArray(int size)
        {
            if (size < 0)
                throw new ArgumentException("Размер массива должен быть положительным");

            array = new Weather[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = new Weather(
                    rnd.NextDouble() * 50 - 20,  // температура от -20 до +30
                    rnd.Next(0, 101),            // влажность от 0 до 100
                    rnd.Next(730, 790)           // давление от 730 до 790
                );
            }
            arrayCount++;
        }

        // Конструктор копирования (глубокое копирование)
        public WeatherArray(WeatherArray other)
        {
            array = new Weather[other.array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Weather(
                    other.array[i].Temperature,
                    other.array[i].Humidity,
                    other.array[i].Pressure
                );
            }
            arrayCount++;
        }

        // Индексатор с проверкой выхода за границы           !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Weather this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                return array[index];
            }
            set
            {
                if (index < 0 || index >= array.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                array[index] = value;
            }
        }

      
        public int Length
        {
            get { return array.Length; }
        }

        
        public void PrintArray()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"[{i}]: {array[i]}");
            }
        }
        public static int GetArrayCount()
        {
            return arrayCount;
        }

        // Метод для нахождения амплитуды температур
        public double GetTemperatureAmplitude()
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Массив пуст");

            double minTemp = array[0].Temperature;
            double maxTemp = array[0].Temperature;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Temperature < minTemp)
                    minTemp = array[i].Temperature;
                if (array[i].Temperature > maxTemp)
                    maxTemp = array[i].Temperature;
            }

            return maxTemp - minTemp;
        }
    }
}
