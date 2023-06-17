internal class Program
{
    private static void Main(string[] args)
    {
        List<Exception> exceptions = new List<Exception>()
        {
            new CustomException("Mda.."),
            new ArgumentException("Invalid argument"),
            new FileNotFoundException("File not found"),
            new InvalidOperationException("Invalid operation"),
            new KeyNotFoundException("Key not found"),
        };

        foreach (Exception exception in exceptions)
        {
            try
            {
                throw exception;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
public class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
}