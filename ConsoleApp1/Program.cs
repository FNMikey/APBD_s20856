namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Monde!");

            int[] tab = { 1, 2, 3, 4, 5, 6};
            double average = calculateAverage(tab);
            Console.WriteLine("Średnia to: " + average);
        }


        public static double calculateAverage(int[] numbers)
        {
            double suma = 0;
            foreach (int num in numbers)
            {
                suma += num;
            }

            return suma / numbers.Length;

        }
    }
}