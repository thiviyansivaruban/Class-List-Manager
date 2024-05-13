//Name: Thiviyan Sivaruban
//Date: May 3rd, 2024
//Title: Class List File
//Purpose: To read and store student information from two different files into three different arrays and allow the user to sort the list

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Policy;

namespace A7ThiviyanSivaruban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //VARIABLE DECLARATION
            string strInput = null, strUser, strChoice, strTemp, strAddName, strFileName;
            string[] strNamesOriginal, strNames, strNamesTemp;
            int[] intAgesOriginal, intAges, intAgesTemp, intGradesOriginal, intGrades, intGradesTemp;
            int intNumStudents = 0, intTemp, intHighestGrade, intLowestGrade, intPosition, intTotal, intAddGrade, intAddAge, intAvgAge;
            double dblAvgGrade, dblMedian;

            //opens names file
            StreamReader re = File.OpenText("names.txt");

            //counts number of students
            while ((strInput = re.ReadLine()) != null)
            {
                intNumStudents++;
            }
            re.Close();

            //sets sizes of arrays
            strNamesOriginal = new string[intNumStudents];
            intAgesOriginal = new int[intNumStudents];
            intGradesOriginal = new int[intNumStudents];

            strNames = new string[intNumStudents];
            intAges = new int[intNumStudents];
            intGrades = new int[intNumStudents];

            //opens names file
            re = File.OpenText("names.txt");

            //splices the data in the file, putting the names into one array and the ages into another array
            for (int i = 0; i < strNamesOriginal.Length; i++)
            {
                strInput = re.ReadLine();
                strNamesOriginal[i] = strInput.Substring(0, strInput.IndexOf(","));

                strInput = strInput.Substring(strInput.IndexOf(",") + 1, strInput.Length - strInput.IndexOf(",") - 1);
                intAgesOriginal[i] = Int32.Parse(strInput);
            }
            re.Close();

            //opens grades file
            re = File.OpenText("grades.txt");

            //transfers data from file into grades array
            for (int i = 0; i < strNamesOriginal.Length; i++)
            {
                strInput = re.ReadLine();
                intGradesOriginal[i] = Int32.Parse(strInput);
            }
            re.Close();

            //transfers all values from original arrays into new arrays that may be sorted later
            for (int i = 0; i < strNames.Length; i++)
            {
                strNames[i] = strNamesOriginal[i];
                intAges[i] = intAgesOriginal[i];
                intGrades[i] = intGradesOriginal[i];
            }

            while (true)
            {
                //displays menu
                Menu();

                Console.WriteLine("\nChoose an option by entering the corresponding number:");
                strUser = Console.ReadLine();
                strChoice = strUser;

                if (strChoice == "1") //option 1
                {
                    //displays header
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", "NAME", "GRADE", "AGE"));
                    Console.WriteLine();

                    //displays unsorted list
                    for (int i = 0; i < strNamesOriginal.Length; i++)
                    {
                        Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", strNamesOriginal[i], intGradesOriginal[i], intAgesOriginal[i]));
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "2") //option 2
                {
                    //sorts array by highest grade to lowest grade
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        for (int j = 0; j < strNames.Length - 1; j++)
                        {
                            if (intGrades[j] < intGrades[j + 1])
                            {
                                strTemp = strNames[j];
                                strNames[j] = strNames[j + 1];
                                strNames[j + 1] = strTemp;

                                intTemp = intGrades[j];
                                intGrades[j] = intGrades[j + 1];
                                intGrades[j + 1] = intTemp;

                                intTemp = intAges[j];
                                intAges[j] = intAges[j + 1];
                                intAges[j + 1] = intTemp;
                            }
                        }
                    }

                    //displays header
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", "NAME", "GRADE", "AGE"));
                    Console.WriteLine();

                    //displays sorted list by grades
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", strNames[i], intGrades[i], intAges[i]));
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "3") //option 3
                {
                    //sorts arrays by name (A-Z)
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        for (int j = 0; j < strNames.Length - 1; j++)
                        {
                            if (strNames[j].CompareTo(strNames[j + 1]) > 0)
                            {
                                strTemp = strNames[j];
                                strNames[j] = strNames[j + 1];
                                strNames[j + 1] = strTemp;

                                intTemp = intGrades[j];
                                intGrades[j] = intGrades[j + 1];
                                intGrades[j + 1] = intTemp;

                                intTemp = intAges[j];
                                intAges[j] = intAges[j + 1];
                                intAges[j + 1] = intTemp;
                            }
                        }
                    }

                    //displays header
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", "NAME", "GRADE", "AGE"));
                    Console.WriteLine();

                    //displays sorted list by name
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        Console.WriteLine(String.Format("{0,-10} {1,-10} {2,-10}", strNames[i], intGrades[i], intAges[i]));
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "4") //option 4
                {
                    intHighestGrade = 0;
                    intPosition = 0;

                    //goes through all values in array to stores highest grade
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        if (intGrades[i] > intHighestGrade)
                        {
                            intHighestGrade = intGrades[i];
                            intPosition = i;
                        }
                    }

                    //displays highest grade
                    Console.WriteLine("\nStudent with Highest Grade: " + strNames[intPosition] + ", age " + intAges[intPosition] + ", with a grade of " + intHighestGrade);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "5") //option 5
                {
                    intLowestGrade = 0;
                    intPosition = 0;

                    //goes through all values in array and stores lowest grade
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        if (i == 0)
                        {
                            if (intGrades[i] < intGrades[i + 1])
                            {
                                intLowestGrade = intGrades[i];
                                intPosition = i;
                            }
                            else
                            {
                                intLowestGrade = intGrades[i + 1];
                                intPosition = i + 1;
                            }
                        }

                        else if (intGrades[i] < intLowestGrade)
                        {
                            intLowestGrade = intGrades[i];
                            intPosition = i;
                        }
                    }

                    //displays lowest grade
                    Console.WriteLine("\nStudent with Lowest Grade: " + strNames[intPosition] + ", age " + intAges[intPosition] + ", with a grade of " + intLowestGrade);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "6") //option 6
                {
                    intTotal = 0;

                    //adds all grades from the list into a total
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        intTotal += intGrades[i];
                    }

                    //calculates average by dividing the total by the number of students
                    dblAvgGrade = Math.Round((double)intTotal / (double)strNames.Length, 2);

                    //outputs average grade
                    Console.WriteLine("\nAverage Grade of the class: " + dblAvgGrade);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "7") //option 7
                {
                    //sorts all arrays where the grades are sorted from highest to lowest
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        for (int j = 0; j < strNames.Length - 1; j++)
                        {
                            if (intGrades[j] < intGrades[j + 1])
                            {
                                strTemp = strNames[j];
                                strNames[j] = strNames[j + 1];
                                strNames[j + 1] = strTemp;

                                intTemp = intGrades[j];
                                intGrades[j] = intGrades[j + 1];
                                intGrades[j + 1] = intTemp;

                                intTemp = intAges[j];
                                intAges[j] = intAges[j + 1];
                                intAges[j + 1] = intTemp;
                            }
                        }
                    }

                    //calculates median, if number of students is odd then takes middle value, if even then divides both middle values by 2
                    if (intGrades.Length % 2 != 0)
                    {
                        dblMedian = (double)intGrades[(intGrades.Length - 1) / 2];
                    }
                    else
                    {
                        dblMedian = ((double)intGrades[(intGrades.Length / 2) - 1] + (double)intGrades[intGrades.Length / 2]) / 2;
                    }

                    //displays class median
                    Console.WriteLine("\nMedian Grade of the class: " + Math.Round(dblMedian, 2));
                    Console.ReadKey();
                }

                else if (strChoice == "8") //option 8
                {
                    intTotal = 0;

                    //adds all ages into a total 
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        intTotal += intAges[i];
                    }

                    //calculates average by dividing the total by the number of students
                    intAvgAge = intTotal / strNames.Length;

                    //outputs average age
                    Console.WriteLine("\nAverage Age of the class: " + intAvgAge);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "9") //option 9
                {
                    //asks user to input name they would like to add
                    Console.WriteLine("\nEnter the NAME of the student that you would like to add to the list:");
                    strUser = Console.ReadLine();
                    strAddName = strUser;

                    //asks user to enter grade of the student they would like to add, if any errors occur from parsing, lets user know
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("\nEnter the GRADE of the student that you would like to add to the list:");
                            strUser = Console.ReadLine();
                            intAddGrade = Int32.Parse(strUser);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\n" + e.Message);
                        }
                    }

                    //asks user to enter age of the student they would like to add, if any errors occur from parsing, lets user know
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("\nEnter the AGE of the student that you would like to add to the list:");
                            strUser = Console.ReadLine();
                            intAddAge = Int32.Parse(strUser);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\n" + e.Message);
                        }
                    }

                    //sets sizes of temporary arrays
                    strNamesTemp = new string[intNumStudents];
                    intGradesTemp = new int[intNumStudents];
                    intAgesTemp = new int[intNumStudents];

                    //transfers values of arrays into temp arrays
                    for (int i = 0; i < intNumStudents; i++)
                    {
                        strNamesTemp[i] = strNames[i];
                        intGradesTemp[i] = intGrades[i];
                        intAgesTemp[i] = intAges[i];
                    }

                    //number of students increases by 1
                    intNumStudents++;

                    //resets the sizes of sorted arrays
                    strNames = new string[intNumStudents];
                    intGrades = new int[intNumStudents];
                    intAges = new int[intNumStudents];

                    //adds new student to the end of the list
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        if (i < strNames.Length - 1)
                        {
                            strNames[i] = strNamesTemp[i];
                            intGrades[i] = intGradesTemp[i];
                            intAges[i] = intAgesTemp[i];
                        }
                        else
                        {
                            strNames[i] = strAddName;
                            intGrades[i] = intAddGrade;
                            intAges[i] = intAddAge;
                        }
                    }

                    //displays successful message
                    Console.WriteLine("\nSuccessfully added " + strAddName + ", age " + intAddAge + ", with a grade of " + intAddGrade);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "10") //option 10
                {
                    //asks user for name of file
                    Console.WriteLine("\nWhat would you like to name the file?");
                    strUser = Console.ReadLine();
                    strFileName = strUser;

                    //creates file
                    FileInfo t = new FileInfo(strFileName + ".txt");
                    StreamWriter FileText = t.CreateText();

                    //inputs values of all arrays (which is sorted in the way that was last viewed by the user) into the new file
                    for (int i = 0; i < strNames.Length; i++)
                    {
                        FileText.WriteLine(strNames[i] + "," + intGrades[i] + "," + intAges[i]);
                    }
                    FileText.Close();

                    //lets user know file has been saved
                    Console.WriteLine("\nStudent information has been saved to a new file: " + strFileName + ".txt");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                else if (strChoice == "11") //option 11
                {
                    //exit message
                    Console.WriteLine("\nThanks, please come again! Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                else
                {
                    //lets user know they inputted an invalid number and tells them to press any key to try again
                    Console.WriteLine("\nInvalid number. Press any key to restart...");
                    Console.ReadKey();
                }
            }
        }

        public static void Menu()
        {
            //clears console and shows menu
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|~|~|~|~|~|~|~|~|   M E N U   |~|~|~|~|~|~|~|~|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" 1. Show Name, Grade, Age List from File (Unsorted)");
            Console.WriteLine(" 2. Show Sorted List by Grade (Along with Name and Age) (Highest to Lowest)");
            Console.WriteLine(" 3. Show Sorted List by Name (Along with Grades and Age) (A-Z)");
            Console.WriteLine(" 4. Show Highest Grade and Student Name and corresponding age");
            Console.WriteLine(" 5. Show Lowest Grade and Student Name and corresponding age");
            Console.WriteLine(" 6. Average Grade");
            Console.WriteLine(" 7. Median Grade");
            Console.WriteLine(" 8. Average Age");
            Console.WriteLine(" 9. Add a new Student with a Grade and Age");
            Console.WriteLine("10. Save to a New File");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("11. EXIT");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
