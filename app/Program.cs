class Program
{
    static string GenerateRandomString(Random random, int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] randomChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            randomChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomChars);
    }

    static string[] FillArray(int size, bool randomData = true)
    {
        string[] array = new string[size];

        if (randomData) {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int stringLength = random.Next(1, 11); // Генерируем случайную длину строки от 1 до 10 символов
                array[i] = GenerateRandomString(random, stringLength);
            }
        } else {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите элемент массива {i+1}: ");
                array[i] = Console.ReadLine() ?? "";
                Console.WriteLine("");
            }
        }

        return array;
    }

    static bool CheckCondition(string str)
    {
        return str.Length <= 3;
    }

    static void Main(string[] args)
    {
        int size = 10;
        string[] array = FillArray(size);

        // Быстрый вариант
        string[] resultOptimal = array.Where(s => CheckCondition(s)).ToArray();

        // Медленный, но изученными методами
        int sizeResult = 0;
        for (int i = 0; i < size; i++)
        {
            sizeResult += CheckCondition(array[i]) ? 1 : 0;
        }

        string[] resultSimple = new string[sizeResult];
        int index = 0;

        for (int i = 0; i < size; i++)
        {
            if (CheckCondition(array[i])) {
                resultSimple[index] = array[i];
                index++;
            }
        }

        // Вывод
        Console.WriteLine($"Массив начальный: [{string.Join(", ", array)}]");
        Console.WriteLine($"Массив результирующий: [{string.Join(", ", resultOptimal)}]");
        Console.WriteLine($"Массив результирующий: [{string.Join(", ", resultSimple)}]");
    }
}