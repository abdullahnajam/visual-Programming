using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Profile_Assignment
{
    class studentProfile
    {
        string path;
        
        string [] storeHead={"ID : ","Name : ","Semester : ","CPGA : ","Department : ","University : "} ;
        public studentProfile(string filepath)
        {
            path = filepath;
        }
        public void CreateProfile(string p,int id, string name, int sem, float cgpa, string dept, string uni)
        {
            try
            {
                using (StreamWriter write = File.AppendText(p))
                {
                    write.WriteLine(id);
                    write.WriteLine(name);
                    write.WriteLine(sem);
                    write.WriteLine(cgpa);
                    write.WriteLine(dept);
                    write.WriteLine(uni);
                    write.WriteLine("f");

                }
            }
            catch
            {
                Console.WriteLine("File not found");
                    File.Create(path);
            }
            
        }
        public bool searchStudent(int id)
        {
            
            string[] store_data = new String[7];
            bool ack = false;
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }


                    if (store_data[0] == id.ToString())
                    {
                        ack = true;
                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write(storeHead[i]);
                            Console.WriteLine(store_data[i]);
                        }
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
            
            return ack;
            
        }
        public bool searchbyID(int id)
        {
            string[] store_data = new String[7]; bool rtype = false;
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }


                    if (store_data[0] == id.ToString())
                    {
                        rtype = true;

                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
            return rtype;
        }


        public void searchStudent(string name)
        {
            

            string[] store_data = new String[7];
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }


                    if (store_data[1] == name)
                    {

                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write(storeHead[i]);
                            Console.WriteLine(store_data[i]);
                        }
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
        }
        public bool searchbyStudent(string name)
        {
            bool ack = false;

            string[] store_data = new String[7];
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }


                    if (store_data[1] == name)
                    {
                        ack = true;
                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write(storeHead[i]);
                            Console.WriteLine(store_data[i]);
                        }
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
            return ack;
        }
        public bool searchbySemester(int sem)
        {
            bool ack=false;
            string[] store_data = new String[7];
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }
                    if (store_data[2] == sem.ToString())
                    {
                        ack = true;
                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write(storeHead[i]);
                            Console.WriteLine(store_data[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
            return ack;
        }
        public void searchSemester(int sem)
        {
            
            string[] store_data = new String[7];
            using (StreamReader r = new StreamReader(path))
            {
                while (!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }
                    if (store_data[2] == sem.ToString())
                    {

                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write(storeHead[i]);
                            Console.WriteLine(store_data[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            store_data[i] = null;
                        }
                    }
                }
            }
                
        }
        public int recordlist()
        {
            string line;
            int count = 0;
            StreamReader r = new StreamReader(path);
            while ((line = r.ReadLine()) != null)
            {
                if (line != "")
                    count++;
            }
            return count / 7;
        }
        public void getTop3()
        {
            string[] store_data = new String[recordlist()];
            string line;
            int j = 0;
            StreamReader r = new StreamReader(path);
            while ((line = r.ReadLine()) != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    line = r.ReadLine();
                    if (i == 2)
                    {
                        store_data[j] = line;
                        j++;
                    }
                }
            }
            Array.Sort(store_data);
            try
            {
                for (int i = 2; i >= 0; i--)
                {
                    Console.WriteLine(store_data[i]);
                }
            }
            catch
            {
                Console.WriteLine("less than 3 records");
            }
            

        }
        public void deleteRecord(int id)
        {
            string line;
            int count = 0;
            StreamReader r = new StreamReader(path);
            while ((line = r.ReadLine()) != null)
            {
                count++;
            }
            r.Close();
            r = new StreamReader(path);
            string[] store_data = new String[count];
            for (int i = 0; i < count; i++)
            {

                store_data[i] = r.ReadLine();
                if (store_data[i] == id.ToString())
                {
                    //store_data[i] = null;
                    i--;
                    for (int j = 0; j < 6; j++)
                    {
                        line = r.ReadLine();
                    }
                }
            }
            r.Close();
            using (StreamWriter write = new StreamWriter(path))
            {
                for (int i = 0; i < store_data.Length; i++)
                {
                    write.WriteLine(store_data[i]);
                }
            }



        }

        
        
        public void markAttendence(int semester)
        {
            
            string[] store_data = new String[7];
            string line;
            int count = 0,inc=0;
            using (StreamReader r = new StreamReader(path))
            {
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
                
            }
            string[] storeRecord = new String[count];
            using (StreamReader r = new StreamReader(path))
            {
                for (int i = 0; i < count; i++)
                {
                    storeRecord[i] = r.ReadLine();
                }

                for (int i = 0; i < storeRecord.Length; i++)
                {
                    inc = i;
                    for (int j = 0; j < 7; j++)
                    {
                        store_data[j] = storeRecord[i];
                        i++;
                    }
                    i--;
                    if (store_data[2] == semester.ToString())
                    {
                        Console.Write(store_data[0] + "  ");
                        Console.Write(store_data[1] + "  : ");
                        storeRecord[i] = Console.ReadLine();

                    }



                }
            }
                
            
            using (StreamWriter w = new StreamWriter(path))
            {
                for (int i = 0; i < storeRecord.Length; i++)
                {
                    w.WriteLine(storeRecord[i]);

                }
                
            }
            
            

        }
        public void viewAttendance(int semester)
        {
            string[] store_data = new String[7];
            string line;
            using (StreamReader r = new StreamReader(path))
            {
                while(!r.EndOfStream)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        store_data[i] = r.ReadLine();
                    }
                    if(store_data[2]==semester.ToString())
                    {
                        Console.Write(store_data[0] + "  ");
                        Console.Write(store_data[1] + "  : ");
                        Console.WriteLine(store_data[6]);
                    }
                }
                
            }
        }
        
    }
}
        
            
            

        


    

