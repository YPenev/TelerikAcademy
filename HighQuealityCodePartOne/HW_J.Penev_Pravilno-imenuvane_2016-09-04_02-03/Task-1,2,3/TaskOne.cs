class Console
{
    const int MaxAllowedCount = 6;
    class Print
    {
        void PrintGivenBooleanTypeValue(bool booleanValue)
        {
            string booleanValueToString = booleanValue.ToString();
            Console.WriteLine(booleanValueToString);
        }
    }
    public static void PrintTrue()
    {
        Console.Print printer = new Console.Print();
        printer.PrintGivenBooleanTypeValue(true);
    }
}