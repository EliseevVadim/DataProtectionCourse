#pragma warning disable CS8604 // Possible null reference argument.

using lab4;

try
{
    Console.WriteLine("Введите коэффициенты сравнения, такие что a*x=b (mod n):");
    Console.WriteLine("Введите коэффициент a:");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите коэффициент b:");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите коэффициент n:");
    int n = int.Parse(Console.ReadLine());
    LinearComparisonSolver solver = new LinearComparisonSolver(a, b, n);
    Console.WriteLine(solver.SolveComparison());
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
catch (FormatException)
{
    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
}
catch (Exception)
{
    Console.WriteLine("При работе приложения произошла ошибка.");
}

