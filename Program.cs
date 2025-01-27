namespace _9999
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                // Демонстрация работы с классом Weather
                Console.WriteLine("=== Демонстрация работы с классом Weather ===");
                Weather w1 = new Weather(25, 60, 755);
                Weather w2 = new Weather(18, 85, 762);

                Console.WriteLine($"Погода 1: {w1}");
                Console.WriteLine($"Точка росы: {w1.CalculateDewPoint():F2}°C");
                Console.WriteLine($"Точка росы (статический метод): {Weather.CalculateDewPointStatic(w1):F2}°C");

                // Демонстрация перегруженных операторов
                Console.WriteLine("\n=== Демонстрация перегруженных операторов ===");
                Weather w3 = -w1;  // Унарный минус
                Console.WriteLine($"Противоположная температура: {w3}");

                Console.WriteLine($"Влажность выше 80%: {!w2}");  // Унарное НЕ

                Console.WriteLine($"Давление выше нормы: {(bool)w2}");  // Явное приведение к bool

                double humindex = w1;  // Неявное приведение к double
                Console.WriteLine($"Ощущаемая температура: {humindex:F2}°C");

                Weather w4 = w1 - 5;  // Вычитание числа
                Console.WriteLine($"Температура -5 градусов: {w4}");

                Weather w5 = w1 * 10;  // Увеличение на проценты
                Console.WriteLine($"Увеличение на 10%: {w5}");

                // Демонстрация работы с массивом
                Console.WriteLine("\n=== Демонстрация работы с массивом ===");
                WeatherArray arr1 = new WeatherArray(3);
                Console.WriteLine("Исходный массив:");
                arr1.PrintArray();

                // Демонстрация копирования
                WeatherArray arr2 = new WeatherArray(arr1);
                Console.WriteLine("\nКопия массива:");
                arr2.PrintArray();

                // Демонстрация работы индексатора
                Console.WriteLine("\n=== Демонстрация работы индексатора ===");
                // 1. Получение существующего элемента
                Console.WriteLine($"Элемент с индексом 0: {arr1[0]}");

                // 2. Запись в существующий элемент
                arr1[0] = new Weather(20, 70, 750);
                Console.WriteLine($"Измененный элемент: {arr1[0]}");

                // 3. Попытка получения несуществующего элемента
                try
                {
                    Console.WriteLine(arr1[10]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                // 4. Попытка записи в несуществующий элемент
                try
                {
                    arr1[-1] = new Weather();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                // Нахождение амплитуды температур
                Console.WriteLine($"\nАмплитуда температур: {arr1.GetTemperatureAmplitude():F2}°C");

                // Вывод статистики
                Console.WriteLine("\n=== Статистика ===");
                Console.WriteLine($"Создано объектов Weather: {Weather.GetObjectCount()}");
                Console.WriteLine($"Создано массивов WeatherArray: {WeatherArray.GetArrayCount()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}