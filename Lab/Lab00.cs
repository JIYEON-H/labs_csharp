using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Lab00
    {
        public static void Main(String[] args)
        {

            int lowNumber = 0;
            int highNumber = 0;

            bool activeLow = true;
            while (activeLow)
            {
                Console.WriteLine("Enter the low number. ");
                lowNumber = Convert.ToInt32(Console.ReadLine());
                if (lowNumber > 0)
                {
                    activeLow = false;
                }
            }


            bool activeHigh = true;
            while (activeHigh)
            {
                Console.WriteLine("Enter the high number. ");
                highNumber = Convert.ToInt32(Console.ReadLine());
                if (highNumber > lowNumber)
                {
                    activeHigh = false;
                }
            }


            Console.Write("Difference between the low and high variables is : ");
            Console.WriteLine(highNumber - lowNumber);

            int[] nums = new int[highNumber - lowNumber - 1];

            for (int i = 0; i < nums.Length; i++)
            {
                highNumber -= 1;
                nums[i] = highNumber;
                Console.WriteLine(nums[i]);
            }


            string[] changeToString = Array.ConvertAll(nums, num => num.ToString());
            
            string filepath = @"C:\Users\jiyeo\OneDrive\Desktop\CPRG211_B\Lab\Lab\numbers.txt";

            FileStream fs = File.Create(filepath);
            fs.Close();
            File.WriteAllLines(filepath, changeToString);
            fs.Close();


            //additional Tasks
            string[] readFromFile = File.ReadAllLines(filepath);
            fs.Close();

            //foreach(string line in readFromFile)
            //{
            //    Console.WriteLine(line);
            //}

            int[] sumFromFile = Array.ConvertAll(readFromFile, int.Parse);
            Console.WriteLine("The sum of the numbers between highest and lowest is " + sumFromFile.Sum());

        }
    }
}
