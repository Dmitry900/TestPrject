
object loker = new();
Task[] tasks = new Task[5];

//запускаем потоки и блокируем главный поток
for (var i = 0; i < tasks.Length; i++)
{
    tasks[i] = new Task(() =>
    {
        Print(i);
    });
    tasks[i].Start();   // запускаем задачу
}
Task.WaitAll(tasks);
Console.WriteLine("Готово");
Console.ReadKey();

void Print(int threadNum)
{
    lock (loker)
    {
        var x = 1;
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{threadNum}: {x}");
            x++;
            Thread.Sleep(1000);
        }
    }
}
   