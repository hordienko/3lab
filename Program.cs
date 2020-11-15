using System;
using System.IO;
using System.Linq;

namespace destheokond
{
    class Program
    {
        static int[] masNums;
        static char[,] masABC;
        static string[] masabc;
        static void Main(string[] args)
        {
            GetDataNums();
            GetDataAbs();
            GetDataABC();


            Console.WriteLine("Метод Кондорсе");
            int kondorseAB = Kondorse('A', 'B', "Кандидат А");
            int kondorseAC = Kondorse('A', 'C', "Кандидат А");
            int kondorseBA = Kondorse('B', 'A', "Кандидат В");
            int kondorseBC = Kondorse('B', 'C', "Кандидат В");
            int kondorseCA = Kondorse('C', 'A', "Кандидат С");
            int kondorseCB = Kondorse('C', 'B', "Кандидат С");

            int[] kondor = { kondorseAB, kondorseAC, kondorseBA, kondorseBC, kondorseCA, kondorseCB };
            int maximumKondorse = kondor.Max();
            Console.WriteLine($"\nA>B = {kondorseAB}" +
                $"\nA>C = {kondorseAC}" +
                $"\nB>A = {kondorseBA}" +
                $"\nB>C = {kondorseBC}" +
                $"\nC>A = {kondorseCA}" +
                $"\nC>B = {kondorseCB}");

            if (kondorseAB == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата А з к-стю голосiв -  { maximumKondorse}");
            }
            else if (kondorseAC == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата А з к-стю голосiв  - { maximumKondorse}");

            }
            else if (kondorseBA == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата В з к-стю голосiв - { maximumKondorse}");

            }
            else if (kondorseBC == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата В з к-стю голосiв - { maximumKondorse}");

            }
            else if (kondorseCA == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата С з к-стю голосiв - { maximumKondorse}");

            }
            else if (kondorseCB == maximumKondorse)
            {
                Console.WriteLine($"Перемога кандидата С з к-стю голосiв -{ maximumKondorse}");


            }

            Console.WriteLine("\n Метод Борда");

            int A = Borda('A', "A_kilkist");
            int B = Borda('B', "B_kilkist");
            int C = Borda('C', "C_kilkist");

            if (A > B && A > C)
                Console.WriteLine($"Перемога кандидата А з к-стю голосiв = {A}");
            if (B > A && B > C)
                Console.WriteLine($"Перемога кандидата В з к-стю голосiв = {B}");
            if (C > A && C > B)
                Console.WriteLine($"Перемога кандидата С з к-стю голосiв = {C}");

        }

        public static int[] GetDataNums() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("Nums.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');

            masNums = new int[lines.Length];

            for (int i = 0; i < masNums.Length; i++)
            {
                masNums[i] = Convert.ToInt32(lines[i]);
            }
            return masNums;
        }
        public static char[,] GetDataABC() // метод для зчитування і запису БУКВ в ДВОРІВНЕВИЙ МАСИВ 
        {
            string filePath = Path.GetFullPath("ABC.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] a = file.Split(' ');

            masABC = new char[5, 3];


            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    masABC[i, j] = a[i].ToCharArray()[j];
                    // Console.WriteLine(masABC[i,j]);
                }
            }
            return masABC;

        }

        public static string[] GetDataAbs()
        {
            string filePath = Path.GetFullPath("ABC.txt");
            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] b = file.Split(' ');
            masabc = new string[5];
            for (int i = 0; i < b.Length; i++)
            {
                masabc[i] = b[i];


            }

            return masabc;
        }



        public static int Borda(char Bukva, string Perekluchatel)
        {
            /*  для методу борда створено масив другого виміру де в кожному елементі першого виміру є масив з трьо елементів
            де перший рівень елемент це є буквосполучення а елемент другого рівня - символ словосполучення
            для вирішення задачі методом борда я створив я створив загальний метод який  приймає параметри необхідбні для підрахунку голосів кожного кандидата
            метод  приймає два значення букву кандидата і сам переключатель для кожного кандидата щоб змогти рахувати кількість голосів для нього і повертати її
            далі за допомогою методів ІФ реалізований обрахунок кількості голосів для кожного кандидата де ми беремо коефіцієнт довіри помножений число з заданої 
            умови і доданий до змінної кількості голосів
            Всі шість кількостей голосів для можливих варіантів я записую в масив , вибирає з нього максимальне значення, та виводжу її на екран.
            */
            int kilkist = 0, A_kilkist = 0, B_kilkist = 0, C_kilkist = 0;

            if (Perekluchatel == "A_kilkist") { kilkist = A_kilkist; }
            else if (Perekluchatel == "B_kilkist") { kilkist = B_kilkist; }
            else if (Perekluchatel == "C_kilkist") { kilkist = C_kilkist; }



            if (masABC[0, 0] == Bukva) { kilkist += masNums[0] * 3; }
            else if (masABC[0, 1] == Bukva) { kilkist += masNums[0] * 2; }
            else if (masABC[0, 2] == Bukva) { kilkist += masNums[0] * 1; }

            if (masABC[1, 0] == Bukva) { kilkist += masNums[1] * 3; }
            else if (masABC[1, 1] == Bukva) { kilkist += masNums[1] * 2; }
            else if (masABC[1, 2] == Bukva) { kilkist += masNums[1] * 1; }

            if (masABC[2, 0] == Bukva) { kilkist += masNums[2] * 3; }
            else if (masABC[2, 1] == Bukva) { kilkist += masNums[2] * 2; }
            else if (masABC[2, 2] == Bukva) { kilkist += masNums[2] * 1; }

            if (masABC[3, 0] == Bukva) { kilkist += masNums[3] * 3; }
            else if (masABC[3, 1] == Bukva) { kilkist += masNums[3] * 2; }
            else if (masABC[3, 2] == Bukva) { kilkist += masNums[3] * 1; }


            if (masABC[4, 0] == Bukva) { kilkist += masNums[4] * 3; }
            else if (masABC[4, 1] == Bukva) { kilkist += masNums[4] * 2; }
            else if (masABC[4, 2] == Bukva) { kilkist += masNums[4] * 1; }

            Console.WriteLine($"Кандитат {Bukva} набирає {kilkist} голосiв");

            return kilkist;
        }


        public static int Kondorse(char First, char Second, string Kandidat)
        {
            /*для методу Кондорсе створений метод який також приймає вже три параметри, це перша буква, друга буква - для виокремлення буквосполучення яка тотожна
             * з пріоритетом довіри (АВ=A>B .
             Після чого в масиві елементів (де елемент це буквосполучення трьох букв ( кандидатів_  з умови таблиці, я обирає індекс першого параметра та порівнбюю індекс
            другого парметру, якщо він менший то в змінну WIN присвоюю число з відповідним індексом з масиву чисел заданих в умові. Таку дію я проробляю для кожного 
             масиву буквосполучень ( пріоритетів кандидатів ) та формую три значеення змінної WIN . */

            int A = 0;
            int B = 0;
            int C = 0;
            int win = 0;

            if (Kandidat == "Кандидат А") { win = A; }
            else if (Kandidat == "Кандидат В") { win = B; }
            else if (Kandidat == "Кандидат С") { win = C; }

            if (masabc[0].IndexOf(First) < masabc[0].IndexOf(Second))
            { win += masNums[0]; }

            if (masabc[1].IndexOf(First) < masabc[1].IndexOf(Second))
            { win += masNums[1]; }


            if (masabc[2].IndexOf(First) < masabc[2].IndexOf(Second))
            { win += masNums[2]; }


            if (masabc[3].IndexOf(First) < masabc[3].IndexOf(Second))
            { win += masNums[3]; }


            if (masabc[4].IndexOf(First) < masabc[4].IndexOf(Second))
            { win += masNums[4]; }


            return win;


        }



    }

}
