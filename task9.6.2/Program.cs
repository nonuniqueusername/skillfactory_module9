internal class Program
{
    private static void Main(string[] args)
    {
        NameSorter sorter = new NameSorter();
        sorter.SortingCompleted += Sorter_SortingCompleted;
        List<string> _lastNames = new List<string>
        {
            "Иванов",
            "Смирнов",
            "Кузнецов",
            "Попов",
            "Соколов",
            "Лебедев",
            "Козлов",
            "Новиков",
            "Морозов",
            "Петров"
        };
        Console.WriteLine("Выберите тип сортировки:");
        Console.WriteLine("1. А-Я");
        Console.WriteLine("2. Я-А");

        try
        {
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                sorter.Sort(_lastNames, SortType.Ascending);
            }
            else if (choice == 2)
            {
                sorter.Sort(_lastNames, SortType.Descending);
            }
            else
            {
                throw new InvalidChoiceException("Неверный выбор. Пожалуйста, введите 1 или 2.");
            }
        }
        catch (InvalidChoiceException ex) 
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    private static void Sorter_SortingCompleted(List<string> _sortedLastNames)
    {
        Console.WriteLine("Отсортированный список фамилий:");
        foreach (var s in _sortedLastNames)
        {
            Console.WriteLine($"{s}");
        }
    }
}

public enum SortType
{
    Ascending,
    Descending
}

public delegate void SortComplete(List<string> _lastNames);
public class NameSorter
{
    public event SortComplete SortingCompleted;

    public void Sort(List<string> _lastNames, SortType _sortType)
    {
        if (_sortType == SortType.Ascending)
        {
            _lastNames.Sort();
        }
        else
        {
            _lastNames.Sort();
            _lastNames.Reverse();
        }
        OnSortingCompleted(_lastNames);
    }
    protected virtual void OnSortingCompleted(List<string> _sortedLastNames)
    {
        SortingCompleted?.Invoke(_sortedLastNames);
    }
}

public class InvalidChoiceException : Exception 
{
    public InvalidChoiceException(string message) : base(message) { }
}