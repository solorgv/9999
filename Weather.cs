using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9999
{
    internal class Weather
    {
    
        private double temperature;
        private int humidity;
        private int pressure;

        
        private static int objectCount = 0;

        
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public int Humidity
        {
            get { return humidity; }
            set
            {
                if (value >= 0 && value <= 100)
                    humidity = value;
                else
                    throw new ArgumentException("Влажность должна быть от 0 до 100%");
            }
        }

        public int Pressure
        {
            get { return pressure; }
            set
            {
                if (value > 0)
                    pressure = value;
                else
                    throw new ArgumentException("Давление должно быть положительным");
            }
        }

    
        public Weather()
        {
            Temperature = 0;
            Humidity = 50;
            Pressure = 760;
            objectCount++;
        }

        public Weather(double temp, int hum, int press)
        {
            Temperature = temp;
            Humidity = hum;
            Pressure = press;
            objectCount++;
        }

        
        public static int GetObjectCount()
        {
            return objectCount;
        }

        
        public double CalculateDewPoint() // точка росы
        {
            const double a = 17.27;
            const double b = 237.7;

            double temp = (a * Temperature) / (b + Temperature) + Math.Log(Humidity / 100.0);
            return (b * temp) / (a - temp);
        }

       
        public static double CalculateDewPointStatic(Weather w)
        {
            return w.CalculateDewPoint();
        }

       
        public static Weather operator -(Weather w)
        {
            return new Weather(-w.Temperature, w.Humidity, w.Pressure);
        }

        public static bool operator !(Weather w)
        {
            return w.Humidity > 80;
        }

        // Явное преобразование в bool
        public static explicit operator bool(Weather w)
        {
            return w.Pressure > 760;
        }

        // Неявное преобразование в double (humindex)
        public static implicit operator double(Weather w)
        {
            // Упрощенная формула для heat index !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return w.Temperature + 0.05 * w.Humidity;
        }

       
        public static Weather operator -(Weather w, double d)
        {
            return new Weather(w.Temperature - d, w.Humidity, w.Pressure);
        }

        public static Weather operator *(Weather w, double percent)
        {
            double factor = 1 + (percent / 100.0);
            return new Weather(
                w.Temperature * factor,
                (int)(w.Humidity * factor),
                (int)(w.Pressure * factor)
            );
        }

       
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Weather))
                return false;

            Weather w = (Weather)obj;
            return Temperature == w.Temperature &&
                   Humidity == w.Humidity &&
                   Pressure == w.Pressure;
        }

        public override string ToString()
        {
            return $"Температура: {Temperature}°C, Влажность: {Humidity}%, Давление: {Pressure} мм рт.ст.";
        }
    }
}
