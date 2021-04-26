using System;

namespace _500_cards
{  
    
    class Program
    {       
        static void Get_cards(int[] player_array, int[] white_array)
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                player_array[i] = white_array[rand.Next(501)];
            }
        }
        static void Remove_Card(ref int[] player_array, int index)
        {
            int[] newArray = new int[player_array.Length - 1];

            for (int i = 0; i < index; i++)
                newArray[i] = player_array[i];

            for (int i = index + 1; i < player_array.Length; i++)
                newArray[i - 1] = player_array[i];

            newArray = player_array;
          
        }
        static void Add_Card(ref int[] player_array, int value, int index)
        {
            int[] newArray = new int[player_array.Length + 1];

            newArray[index] = value;

            for (int i = 0; i < index; i++)
                newArray[i] = player_array[i];

            for (int i = index; i < player_array.Length; i++)
                newArray[i + 1] = player_array[i];

            newArray = player_array;

        }

        static void Main(string[] args)
        {
            var rand = new Random();

            int[] red_mas = new int[100];
            for (int i = 0; i < 100; i++)
            {
                red_mas[i] = rand.Next(101);
            }

            int[] player_mas = new int[10];
            int[] white_mas = new int[500];
            for(int i = 0; i < 500; i++)
            {
                white_mas[i] = rand.Next(501);
            }
            Get_cards(player_mas, white_mas);

            
            



            bool game = true;
            while (game == true)
            {
                int score = 0;

                int number= rand.Next(101);
                Console.WriteLine($"Red Card --> {red_mas[number]}");
                Console.WriteLine();
                Remove_Card(ref red_mas, number);


                Console.WriteLine("Your cards:");
                for (int i = 0;i < player_mas.Length; i++)
                {
                    Console.Write(player_mas[i] + "\t");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Choose your card -->");
                int card = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < player_mas.Length; i++)
                {
                    if (card == player_mas[i])
                    {
                        Remove_Card(ref player_mas, i);
                    }


                    Console.WriteLine("Haha funny guy, +1 to your score!");
                    score++;
                    Console.WriteLine($"Score: {score}");
                    Console.WriteLine();

                    int number1 = rand.Next(501);
                    Add_Card(ref player_mas, number1, i);
                    break;
                }

            }
            
        }
    }
}
