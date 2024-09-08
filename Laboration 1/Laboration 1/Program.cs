public class Program
{
    //Sträng input 
    public static string testInput = "29535123p48723487597645723645";

    static void Main(string[] args)
    {
        CalculateSum(testInput);
    }
    public static void CalculateSum(string testInput)
    {
        long totalSum = 0;
        // Loppar ifrån starten utav strängen
        for (int start = 0; start < testInput.Length - 1; start++)
        {
            // Loppar ifrån slutet av strängen
            for (int end = testInput.Length - 1; end > start; end--)
            {
                // Kontrollerar så det är samma värde
                if (testInput[start] == testInput[end])
                {
                    string targetNumbers = testInput.Substring(start, end - start + 1);

                    bool isDigit = targetNumbers.All(char.IsDigit);
                    bool noRepeat = !testInput.Substring(start + 1, targetNumbers.Length - 2).Contains(targetNumbers.First());
                    if (isDigit && noRepeat)
                    {
                        totalSum += long.Parse(targetNumbers);
                        Paint(testInput, start, end);
                    }
                }
            }
        }
        Console.WriteLine("------------");
        Console.WriteLine("Totalen är: " + totalSum);
    }

    public static void Paint(string testInput, int start, int end)
    {
        string targetNumbers = testInput.Substring(start, end - start + 1);
        string beforeTarget = testInput.Substring(0, start);
        string afterTarget = testInput.Substring(start + targetNumbers.Length);

        Console.Write(beforeTarget);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(targetNumbers);
        Console.ResetColor();
        Console.WriteLine(afterTarget);
    }
}
