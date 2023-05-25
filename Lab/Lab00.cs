using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

//Prompt the user to enter the low number. - Store the low number as an int variable.
//Prompt the user to enter the high number. - Store the high number as an int variable.
//Calculate and print out the difference between the low and high variables.
//Task 2: Looping and Input Validation
//Write a loop that keeps iterating until the user enters a positive low number.
//Write a loop that keeps iterating until the enters a high number greater than the low number.
//Task 3: Using Arrays and File I/O
//Create an array variable that holds every number between low and high.
//Create a new file called "numbers.txt".
//Write each number in the array to the file in reverse order (largest to smallest).

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
