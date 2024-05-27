using Sample;
using Samples;
using System;

class Program
{
    static PhoneService phoneService;

    private static void Main()
    {
        phoneService = new PhoneService();

        Console.WriteLine("Добро пожаловать в программу управления телефоном");

        while (true)
        {
            Console.WriteLine("Введите номер команды");
            PrintCommand();
            string number = Console.ReadLine();

            switch (number)
            {
                case "1": AddPhoneInfo(); break;
                case "2": DeletePhoneInfo(); break;
                case "3": PrintPhoneList(); break;
                case "4": PrintSortedPhoneList(); break;
                case "5": PrintPhoneDetails(); break;
                case "6": Console.Clear(); break;
                default: Console.WriteLine("Invalid command"); break;
            }
        }
    }

    private static void PrintCommand()
    {
        Console.WriteLine("1 - Добавить информацию о телефоне");
        Console.WriteLine("2 - Удалить информацию о телефоне");
        Console.WriteLine("3 - Показать полный список телефонов");
        Console.WriteLine("4 - Показать список телефонов, отсортированный по цене");
        Console.WriteLine("5 - Показать информацию о телефоне");
        Console.WriteLine("6 - Очистить консоль");
    }

    private static void AddPhoneInfo()
    {
        Console.WriteLine("Добавить информацию о телефоне");

        Console.WriteLine("Введите модель телефона");
        string model = Console.ReadLine();

        Console.WriteLine("Введите цену");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Войдите в память телефона");
        int storage = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите RAM");
        int ram = int.Parse(Console.ReadLine());

        Console.WriteLine("Добавлена информация о телефоне");
        PhoneInfo info = new PhoneInfo(model, price, storage, ram);

        phoneService.Add(info);
        phoneService.Save();
    }

    private static void DeletePhoneInfo()
    {
        Console.WriteLine("Удалить информацию о телефоне");
        PrintPhoneList();
        Console.WriteLine("Введите ID телефона для удаления");

        try
        {
            int id = int.Parse(Console.ReadLine());

            if (phoneService.Delete(id))
            {
                Console.WriteLine("Информация о телефоне удалена");
            }
            else
            {
                Console.WriteLine("Информация о телефоне не удалена");
                PrintPhoneList();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintPhoneList()
    {
        Console.WriteLine("Список телефонов");

        if (phoneService.phoneInfo.Count == 0)
        {
            Console.WriteLine("Нет информации по телефону");
            return;
        }

        foreach (PhoneInfo phone in phoneService.phoneInfo)
        {
            Console.WriteLine(phone.GetInfo());
        }
    }

    private static void PrintSortedPhoneList()
    {
        try
        {
            Console.WriteLine("Список телефонов, отсортированных по цене");
            List<PhoneInfo> sortedList = phoneService.GetListSortedByPrice();

            foreach (PhoneInfo phone in sortedList)
            {
                Console.WriteLine(phone.GetInfo());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    private static void PrintPhoneDetails()
    {
        try
        {
            Console.WriteLine("Подробная информация о телефоне");
            phoneService.PrintPhoneModelDetails();
        }

        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
