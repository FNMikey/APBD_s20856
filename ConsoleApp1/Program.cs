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

            int maxValue = findMax(tab);
            Console.WriteLine("Maksymalna wartość to: " + maxValue);
        }


        public static double calculateAverage(int[] numbers)
        {
            double sumaa = 0;
            foreach (int num in numbers)
            {
                sumaa += num;
            }

            return sumaa / numbers.Length;

        }

        public static int findMax(int[] numbers)
        {
      
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }




    }
}