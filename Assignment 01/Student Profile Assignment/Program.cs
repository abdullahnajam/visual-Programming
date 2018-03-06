using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Profile_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path;
            if (args.Count() != 0)
            {

                path = args[0];
            }
            else
            {
                Console.WriteLine("Please Enter Path for file");
                path = Console.ReadLine();
            }
            if (File.Exists(path) != true)
            {
                using (StreamWriter makefile = new StreamWriter(path))
                {
                    makefile.Close();
                }
                   
            }


            studentProfile obj = new studentProfile(path);
            int id, sem; float cgpa; string name, dept, uni;
            int choice, searchChoice, menuChoice;
            Console.WriteLine("\t\t\t\"Student Profile System\"");
            Console.WriteLine("\n\n\n\t\t\t1.Enter Record");
            Console.WriteLine("\t\t\t2.Search Student Record");
            Console.WriteLine("\t\t\t3.Delete Student Record");
            Console.WriteLine("\t\t\t4.Get Top 3 Students");
            Console.WriteLine("\t\t\t5.Mark Attendance");
            Console.WriteLine("\t\t\t6.View Attendance");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {

                do
                {

                    Console.WriteLine("Enter Student ID");
                    id = int.Parse(Console.ReadLine());
                    if (obj.searchbyID(id) == true)
                    {
                        Console.WriteLine("Id already taken");
                    }
                }
                while (obj.searchbyID(id) == true);
                Console.WriteLine("Enter Student Name");
                name = Console.ReadLine();
                do
                {

                    Console.WriteLine("Enter Student Semester");
                    sem = int.Parse(Console.ReadLine());
                    if (sem > 8 || sem < 1)
                    {
                        Console.WriteLine("Semester must be from 1-8.Please enter Again");
                    }
                }
                while (sem < 1 || sem > 8);
                do
                {

                    Console.WriteLine("Enter Student CGPA");
                    cgpa = float.Parse(Console.ReadLine());
                    if (cgpa > 4 || cgpa < 0)
                    {
                        Console.WriteLine("CGPA must be from 0.0-4.0.Please enter Again");
                    }
                }
                while (cgpa < 1 || cgpa > 4);

                Console.WriteLine("Enter Student Department");
                dept = Console.ReadLine();
                Console.WriteLine("Enter Student University");
                uni = Console.ReadLine();
                obj.CreateProfile(path,id, name, sem, cgpa, dept, uni);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\n\n\n\t\t\t1.Search by ID");

                Console.WriteLine("\t\t\t2.Search by Name");
                Console.WriteLine("\t\t\t3.Search by Semester");
                searchChoice = int.Parse(Console.ReadLine());
                if (searchChoice == 1)
                {
                    do
                    {
                        Console.WriteLine("Enter Student ID");
                        id = int.Parse(Console.ReadLine());
                        if (obj.searchbyID(id) == false)
                        {
                            Console.WriteLine("\t\t\tno record found please try again");
                        }
                        else
                            obj.searchStudent(id);

                    }
                    while (obj.searchbyID(id) == false);
                }
                else if (searchChoice == 2)
                {
                    do
                    {
                        Console.WriteLine("Enter Student Name");
                        name = Console.ReadLine();
                        if (obj.searchbyStudent(name) == false)
                        {
                            Console.WriteLine("\t\t\tno record found please try again");
                        }
                        else
                            obj.searchStudent(name);

                    }
                    while (obj.searchbyStudent(name) == false);
                }
                else if (searchChoice == 3)
                {
                    do
                    {
                        Console.WriteLine("Enter Student Semester");
                        sem = int.Parse(Console.ReadLine());
                        if (obj.searchbySemester(sem) == false)
                        {
                            Console.WriteLine("\t\t\tno record found please try again");
                        }
                        else
                            obj.searchSemester(sem);

                    }
                    while (obj.searchbySemester(sem) == false);
                }
            }
            else if (choice == 3)
            {
                do
                {

                    Console.WriteLine("Enter Student ID");
                    id = int.Parse(Console.ReadLine());
                    if (obj.searchbyID(id) == false)
                    {
                        Console.WriteLine("Id doesnot Exists");
                    }
                    else
                        obj.deleteRecord(id);
                }
                while (obj.searchbyID(id) == false);
            }
            else if (choice == 4)
            {
                obj.getTop3();
            }
            else if (choice == 5)
            {
                do
                {

                    Console.WriteLine("Enter Student Semester");
                    sem = int.Parse(Console.ReadLine());
                    if (sem > 8 || sem < 1)
                    {
                        Console.WriteLine("Semester must be from 1-8.Please enter Again");
                    }
                    else
                        obj.markAttendence(sem);
                }
                while (sem < 1 || sem > 8);
            }
            else if (choice == 6)
            {
                do
                {

                    Console.WriteLine("Enter Student Semester");
                    sem = int.Parse(Console.ReadLine());
                    if (sem > 8 || sem < 1)
                    {
                        Console.WriteLine("Semester must be from 1-8.Please enter Again");
                    }
                    else
                        obj.viewAttendance(sem);
                }
                while (sem < 1 || sem > 8);
            }
            else
            {
                Console.WriteLine("invalid Choice");
            }


        }
    }
    
}
