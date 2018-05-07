using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmTest
{
    class Genetic
    {
        static void Main(string[] args)
        {
            //Issue: doesn't store the highest score from every round, only the high score from the last round
            //generate a string of 50 characters composed of a's, b's, c's and d's
            Random rand = new Random();
            string sourceCode = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string generation1 = Printer(sourceCode, rand.Next());
            generation1 = Comparer(generation1, sourceCode);
            string generation2 = Printer(generation1, rand.Next());
            generation2 = Comparer(generation2, generation1);
            string generation3 = Printer(generation2, rand.Next());
            generation3 = Comparer(generation3, generation2);
            string gen4 = Printer(generation3, rand.Next());
            gen4 = Comparer(gen4, generation3);
            string gen5 = Printer(gen4, rand.Next());
            gen5 = Comparer(gen5, gen4);
            Console.Read();
        }
        public static int Scorer(string dna)
        {
            int acount = dna.Count(x => x == 'a');
            int bcount = dna.Count(x => x == 'b');
            int ccount = dna.Count(x => x == 'c');
            int dcount = dna.Count(x => x == 'd');
            int score = (acount * 1) + (bcount * 2) + (ccount * 3) + (dcount * 4);
            return score;
        }
        public static string Mutator(string winner)
        {
            string mutated = winner;
            char[] characters = new char[] { 'a', 'b', 'c', 'd' };
            Random rand = new Random();
            for (int i = 0; i < mutated.Length; i++)
            {
                int random = rand.Next(0, 3);
                if (mutated[i] == characters[random])
                {
                    mutated.Replace(mutated[i], characters[random]);
                }
            }
            return mutated;
        }
        public static string Generator(int randy)
        {
            string dna = "";
            char[] characters = new char[] { 'a', 'b', 'c', 'd' };
            Random rand = new Random(randy);
            for (int i = 0; i < 51; i++)
            {
                int random = rand.Next(0, 3);
                dna = dna + characters[random];
            }
            return dna;
        }
        public static string Printer(string sourceCode, int rando)
        {
            string dna = "";
            char[] characters = new char[] { 'a', 'b', 'c', 'd' };
            string[] sequences = new string[6];
            int[] score = new int[6];
            int generations = 3;
            int highScore = 0;
            int stringNumber = -1;
            Random rand = new Random();
            for (int j = 0; j < 6; j++)
            {
                sequences[j] = Generator(rand.Next(rando));
                dna = "";
                score[j] = Scorer(sequences[j]);
                Console.Write(sequences[j] + " Score:" + score[j] + "\n ");
                if (score[j] > highScore)
                {
                    highScore = score[j];
                    stringNumber = j;
                }
                for (int n = 0; n < sequences.Length; n++)
                {
                    sequences[n] = Mutator(sequences[stringNumber]);
                }
            }
            Console.Write("High Score is:" + highScore + " ");
            Console.WriteLine("String Number:" + (stringNumber + 1));
            return sequences[stringNumber];
        }
        public static string Comparer(string string1, string string2)
        {
            if (Scorer(string1) > Scorer(string2))
            {
                return string1;
            }
            else
            {
                return string2;
            }
        }
    }
}
