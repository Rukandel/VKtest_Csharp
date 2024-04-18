using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Список запущенных процессов:");
        Process[] processes = Process.GetProcesses();

        foreach (Process process in processes)
        {
            Console.WriteLine($"ID: {process.Id} | Имя: {process.ProcessName}");
        }

        Console.WriteLine("\nВведите ID процесса, который хотите завершить:");
        int processId = int.Parse(Console.ReadLine());

        try
        {
            Process processToKill = Process.GetProcessById(processId);
            processToKill.Kill();
            Console.WriteLine($"Процесс с ID {processId} успешно завершен.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Процесс с указанным ID не найден.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Невозможно завершить процесс.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}