int x = 0;  // общий ресурс
 

List<Thread> threads = new();
//запускаем потоки и блокируем главный поток
for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
    myThread.Join();


}
Console.WriteLine("Готово");
Console.ReadKey();

void Print()
{

    x = 1;
    for (int i = 1; i < 6; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(1000);
    }
    
}
   