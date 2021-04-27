using System;

namespace _500_cards
{

    class Program
    {


        static void Remove_Card(ref int[] player_array, int index)
        {
            int[] newArray = new int[player_array.Length - 1];

            for (int i = 0; i < index; i++)
                newArray[i] = player_array[i];

            for (int i = index + 1; i < player_array.Length; i++)
                newArray[i - 1] = player_array[i];

            player_array = newArray;

        }
        static void Add_Card(ref int[] player_array, int value, int index)
        {
            int[] newArray = new int[player_array.Length + 1];

            newArray[index] = value;

            for (int i = 0; i < index; i++)
                newArray[i] = player_array[i];

            for (int i = index; i < player_array.Length; i++)
                newArray[i + 1] = player_array[i];

            player_array = newArray;

        }
        static void Get_cards(ref int[] player_array, ref int[] white_array)
        {

            var rand = new Random();
            int random = 501;
            for (int i = 0; i < 10; i++)
            {
                
                int q = rand.Next(random--);
                player_array[i] = white_array[q];
                Remove_Card(ref white_array, q);

            }

        }

        static void Main(string[] args)
        {
            var rand = new Random();

            // Creating red cards
            int[] red_mas = new int[100];
            for (int i = 0; i < 100; i++)
            {
                red_mas[i] = rand.Next(101);
            }

            int[] player_mas = new int[10];
            int[] white_mas = new int[500];

            // Creating white cards
            for (int i = 0; i < 500; i++)
            {
                white_mas[i] = rand.Next(501);
            }

            // Creating player cards
            Get_cards(ref player_mas, ref white_mas);





            int score = 0;
            bool game = true;
            while (game == true)
            {

                // Showing red card and how much remain
                int number = 101;
                int random1 = rand.Next(number);
                Console.WriteLine($"Red Card --> {red_mas[rand.Next(random1)]}");
                Console.WriteLine();
                Remove_Card(ref red_mas, random1);
                Console.WriteLine($"Red cards remain: {red_mas.Length}");
                Console.WriteLine($"White cards remain: {white_mas.Length}");
                number--;
                Console.WriteLine();



                Console.WriteLine("Your cards:");
                for (int i = 0; i < player_mas.Length; i++)
                {
                    Console.Write(player_mas[i] + "\t");
                }
                Console.WriteLine();


                Console.Write("Choose your card -->");
                int card = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < player_mas.Length; i++)
                {
                    if (card == player_mas[i])
                    {
                        Remove_Card(ref player_mas, i);
                        int index = rand.Next(white_mas.Length);
                        Add_Card(ref player_mas, white_mas[index], 0);
                        Remove_Card(ref white_mas, index);
                        break;
                    }

                }



                
                score++;
                Console.WriteLine($"Score: {score}");
                Console.WriteLine();
                Console.WriteLine();




            }

        }
    }
}
