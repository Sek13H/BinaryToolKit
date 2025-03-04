// Сделано Reimolaev

using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в BinaryToolKit!");
            Console.WriteLine("Сделано: Reimolaev");
            Console.WriteLine("1. Конвертировать двоичный код в числа Dec, Oct, Hex");
            Console.WriteLine("2. Конвертировать числа Dec, Oct, Hex в двоичный код");
            Console.WriteLine("3. Шифрование текста в двоичный код");
            Console.WriteLine("4. Логические операции (AND, OR, XOR, NOT, NAND, NOR и т.д.");
            Console.WriteLine("5. Угадай число в двоичном формате");
            Console.WriteLine("6. Калькулятор двоичных чисел");
            Console.WriteLine("7. Двоичный код в текст");
            Console.WriteLine("8. Калькулятор переворота битов");
            Console.WriteLine("9. Генерация CRC");
            Console.WriteLine("10. Работа с числами в IEEE 754");
            Console.WriteLine("11. Анализ битов числа");
            Console.WriteLine("20. Выход");
            Console.WriteLine("21. GitHub");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ConvertFromBinary(); break;
                case "2": ConvertToBinary(); break;
                case "3": EncodeText(); break;
                case "4": LogicalOperations(); break;
                case "5": GuessBinaryNumber(); break;
                case "6": BinaryCalculator(); break;
                case "7": DecodeBinary(); break;
                case "8": ReverseBits(); break;
                case "9": CRC(); break;
                case "10": IEEE754(); break;
                case "11": BitAnalysis(); break;
                case "20": return;
                case "21":
                {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "https://github.com/Sek13H",
                            UseShellExecute = true
                        });
                        break;


                    }
                default: Console.WriteLine("Неверный выбор!"); break;

            }

        }
    }
    
    static void ConvertFromBinary()
    {
        Console.Clear();
        Console.WriteLine("Введите двоичное число: ");
        string binaryInput = Console.ReadLine();
        string[] binaryNumbers = binaryInput.Split(' ');

        foreach (string binary in binaryNumbers)
        {
            try
            {
                int decimalValue = Convert.ToInt32(binaryInput, 2);
                string octalValue = Convert.ToString(decimalValue, 8);
                string hexValue = Convert.ToString(decimalValue, 16).ToUpper();

                Console.WriteLine($"В десятичной системе (DEC): {decimalValue}");
                Console.WriteLine($"В восьмеричной системе (OCT): {octalValue}");
                Console.WriteLine($"В шестнадцатеричной системе (HEX): {hexValue}");
                Console.ReadLine();



            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода!");
            }
        }
       
    }

    static void ConvertToBinary()
    {
        Console.Clear();
        Console.WriteLine("Выберите систему счисления для перевода в двоичную:");
        Console.WriteLine("1. Десятичная (DEC)");
        Console.WriteLine("2. Восьмеричная (OCT)");
        Console.WriteLine("3. Шестнадцатеричная (HEX)");
        Console.Write("Ваш выбор: ");
        string systemChoice = Console.ReadLine();

        Console.Write("Введите число: ");
        string input = Console.ReadLine();

        try
        {

            switch (systemChoice)
            {
                case "1": ConvertDecimalToBinary(input); break;
                case "2": ConvertOctalToBinary(input); break;
                case "3": ConvertHexToBinary(input); break;
                default: Console.WriteLine("Неверный выбор!"); break;

            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка ввода!");
            Console.ReadLine();
        }
    }

    static void ConvertDecimalToBinary(string input)
    {
        int decimalValue = int.Parse(input);
        string binaryValue = Convert.ToString(decimalValue, 2);
        Console.WriteLine($"В двоичной системе: {binaryValue}");
        Console.ReadLine();
    }

    static void ConvertOctalToBinary(string input)
    {
        int decimalValue = Convert.ToInt32(input, 8);
        string binaryValue = Convert.ToString(decimalValue, 2);
        Console.WriteLine($"В двоичной системе: {binaryValue}");
        Console.ReadLine();
    }

    static void ConvertHexToBinary(string input)
    {
        int decimalValue = Convert.ToInt32(input, 16);
        string binaryValue = Convert.ToString(decimalValue, 2);
        Console.WriteLine($"В двоичной системе: {binaryValue}");
        Console.ReadLine();
    }

    static void EncodeText()
    {
        Console.Clear();
        Console.Write("Введите текст:");
        string input = Console.ReadLine();
        StringBuilder binaryOutput = new StringBuilder();

        foreach (char c in input)
        {
            binaryOutput.Append((Convert.ToString(c, 2).PadLeft(8, '0') + " "));
        }

        Console.WriteLine("Текст в двоичном коде: " + binaryOutput);
        Console.ReadLine();
    }

    static void LogicalOperations()
    {
        Console.Clear();
        Console.Write("Введите первое двоичное число: ");
        string bin1 = Console.ReadLine();
        Console.Write("Введите второе двоичное число: ");
        string bin2 = Console.ReadLine();

        if (bin1.Length != bin2.Length)
        {
            Console.WriteLine("Длины двоичных чисел не совпадают!");
            return;
        }

        int num1 = Convert.ToInt32(bin1, 2);
        int num2 = Convert.ToInt32(bin2, 2);

        Console.WriteLine($"AND: {Convert.ToString(num1 & num2, 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"OR: {Convert.ToString(num1 | num2, 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"XOR: {Convert.ToString(num1 ^ num2, 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"NOT1: {Convert.ToString(~num1, 2).Substring(32 - bin1.Length)}");
        Console.WriteLine($"NOT2: {Convert.ToString(~num2, 2).Substring(32 - bin1.Length)}");
        Console.WriteLine($"NAND: {Convert.ToString(~(num1 & num2), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"NOR: {Convert.ToString(~(num1 | num2), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"XNOR: {Convert.ToString(~(num1 ^ num2), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"Сдвиг влево: {Convert.ToString(num1 << 1, 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"Сдвиг вправо: {Convert.ToString(num1 >> 1, 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"ROL (Rotate Left): {Convert.ToString((num1 << 1) | (num1 >> (bin1.Length - 1)), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"ROR (Rotate Right): {Convert.ToString((num1 >> 1) | (num1 << (bin1.Length - 1)), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"Паритет (чётность битов): {Convert.ToString(bin1.Count(c => c == '1') % 2, 2)}");
        Console.WriteLine($"Маскирование (установка 3-го бита в 1): {Convert.ToString(num1 | (1 << 2), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"XOR-SHIFT (правый сдвиг XOR): {Convert.ToString(num1 ^ (num1 >> 1), 2).PadLeft(bin1.Length, '0')}");
        Console.WriteLine($"Инверсия битов: {Convert.ToString(~num1, 2).Substring(32 - bin1.Length)}");
        Console.WriteLine($"Реверс битов: {new string(bin1.Reverse().ToArray())}");
        Console.WriteLine($"Популяция битов (количество 1): {bin1.Count(c => c == '1')}");
        Console.WriteLine($"Майорность (если больше 1, то 1, иначе 0): {(bin1.Count(c => c == '1') > bin1.Length / 2 ? "1" : "0")}");
        Console.ReadLine();
    }

    static void GuessBinaryNumber()
    {
        Console.Clear();
        Random rand = new Random();
        int secretNumber = rand.Next(0, 16);
        string secretBinary = Convert.ToString(secretNumber, 2).PadLeft(4, '0');
        Console.WriteLine("Компьютер загадал число от 0 до 15. Угадай его в двоичном формате!");

        while (true)
        {
            Console.Write("Введите число в двоичном формате: ");
            string guess = Console.ReadLine();

            if (guess == secretBinary)
            {
                Console.WriteLine($"Поздравляю! Вы угадали! Число было: {secretNumber}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Неверно! Попробуйте еще раз.");
                break;
            }
        }
    }

    static void BinaryCalculator()
    {
        Console.Clear();
        Console.WriteLine("Калькулятор двоичных чисел");
        Console.Write("Введите несколько двоичных чисел через пробел: ");
        string input = Console.ReadLine();
        string[] binaryNumbers = input.Split(' ');

        if (binaryNumbers.Any(bin => !Regex.IsMatch(bin, "^[01]+$")))
        {
            Console.WriteLine("Ошибка ввода. Все числа должны быть в двоичной системе (состоящие только из 0 и 1).");
            Console.ReadLine();
            return;
        }

        try
        {
            int[] numbers = binaryNumbers.Select(bin => Convert.ToInt32(bin, 2)).ToArray();

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.Write("Ваш выбор: ");
            string operation = Console.ReadLine();

            if (!new[] { "1", "2", "3", "4" }.Contains(operation))
            {
                Console.WriteLine("Неверный выбор операции!");
                Console.ReadLine();
                return;
            }

            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                switch (operation)
                {
                    case "1":
                        result += numbers[i];
                        break;
                    case "2":
                        result -= numbers[i];
                        break;
                    case "3":
                        result *= numbers[i];
                        break;
                    case "4":
                        if (numbers[i] != 0)
                            result /= numbers[i];
                        else
                        {
                            Console.WriteLine("Деление на 0 невозможно!");
                            Console.ReadLine();
                            return;
                        }
                        break;
                    

                }
            }

            Console.WriteLine($"Результат: {Convert.ToString(result, 2)}");
            Console.ReadLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка ввода: {ex.Message}");
            Console.ReadLine();
        }

    }

    static void DecodeBinary()
    {
        Console.Clear();
        Console.Write("Введите двоичный код (разделёный пробелами): ");
        string binaryInput = Console.ReadLine();
        string[] binaryArray = binaryInput.Split(' ');
        StringBuilder textOutput = new StringBuilder();
        foreach (string binary in binaryArray)
        {

            if (!string.IsNullOrWhiteSpace(binary))
            {
                textOutput.Append((char)Convert.ToInt32(binary, 2));
            }
                
        }
        Console.WriteLine("Текст: " + textOutput);
        Console.ReadLine();
    }

    static void ReverseBits()
    {
        Console.Clear();
        Console.Write("Введите двоичное число: ");
        uint num = Convert.ToUInt32(Console.ReadLine());
        int bitLength = 32;

        uint reversedNum = 0;
        uint originalNum = num;

        for (int i = 0; i < bitLength; i++)
        {
            reversedNum <<= 1;
            reversedNum |= (num & 1);
            num >>= 1;
        }

        Console.WriteLine($"Число {originalNum} после переворота битов: {reversedNum}");
        Console.WriteLine($"В двоичной форме: {Convert.ToString(reversedNum, 2).PadLeft(bitLength, '0')}");
        Console.ReadLine();
    }

    static void CRC()
    {
        Console.Clear();
        Console.Write("Введите строку для расчёта CRC32:");

        string input = Console.ReadLine();

        uint[] crc32Table = new uint[256];
        const uint polynomial = 0xedb88320;

        for (uint i = 0; i < 256; i++)
        {
            uint crc = i;
            for (uint j = 8; j > 0; j--)
            {
                if ((crc & 1) == 1)
                    crc = (crc >> 1) ^ polynomial;
                else
                    crc >>= 1;
            }
            crc32Table[i] = crc;
        }

        uint crc32Value = 0xffffffff;
        byte[] bytes = Encoding.UTF8.GetBytes(input);

        foreach (byte b in bytes)
        {
            byte tableIndex = (byte)(((crc32Value) & 0xff) ^ b);
            crc32Value = (crc32Value >> 8) ^ crc32Table[tableIndex];
        }

        crc32Value = ~crc32Value;

        Console.WriteLine($"CRC32: {crc32Value:X8}");
        Console.ReadLine();
    }

    static void IEEE754()
    {
        Console.Clear();
              
        Console.Write("Введите число (например, 3 14): ");
        string input = Console.ReadLine();

        
        if (double.TryParse(input, out double inputNumber))
        {
            
            byte[] byteArray = BitConverter.GetBytes(inputNumber);
            string ieee754Representation = "";

            foreach (byte b in byteArray)
            {
                ieee754Representation += Convert.ToString(b, 2).PadLeft(8, '0'); 
            }

            Console.WriteLine($"Число в IEEE 754 формате: {ieee754Representation}");

            
            byte[] byteArrayBack = new byte[8]; 
            for (int i = 0; i < 8; i++)
            {
                string byteString = ieee754Representation.Substring(i * 8, 8);
                byteArrayBack[i] = Convert.ToByte(byteString, 2); 
            }

            double originalNumber = BitConverter.ToDouble(byteArrayBack, 0);
            Console.WriteLine($"Число после преобразования обратно: {originalNumber}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
            Console.ReadLine();
        }
    }

    static void BitAnalysis()
    {
        Console.Clear();
        Console.Write("Введите число: ");

        if (int.TryParse(Console.ReadLine(), out int number))
        {
            string binary = Convert.ToString(number, 2).PadLeft(32, '0');
            int onesCount = binary.Count(c => c == '1');
            int zerosCount = binary.Count(c => c == '0');

            Console.WriteLine($"Двоичное представление: {binary}");
            Console.WriteLine($"Количество 1: {onesCount}");
            Console.WriteLine($"Количество 0: {zerosCount}");
            Console.WriteLine($"Число: {(number % 2 == 0 ? "четное" : "нечетное")}");

            Console.Write("Введите позицию бита (0-31): ");
            if (int.TryParse(Console.ReadLine(), out int position) && position >= 0 && position < 32)
            {
                int bitValue = (number >> position) & 1; 
                Console.WriteLine($"Бит на позиции {position}: {bitValue}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Неверная позиция бита!");
                Console.ReadLine();
            }

        }
        else
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
        }
    }


}
