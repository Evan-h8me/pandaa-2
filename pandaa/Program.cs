using System;
using System.IO;
using System.Collections.Generic;


namespace compressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var list = new List<string>();

            using (var streamReader = new StreamReader("../../panda-small.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                    Console.WriteLine(line);
                }

            }
            Console.ReadKey();
            using (StreamWriter writer = new StreamWriter("../../panda-compressed.txt"))
            {
                string temp;
                foreach (string item in list)
                {
                    temp = compression(item);
                    writer.WriteLine(temp);
                    Console.WriteLine(temp);
                }
            }

            var clist = new List<string>();

            using (var streamReader = new StreamReader("../../panda-compressed.txt"))
            {
                string cline;
                while ((cline = streamReader.ReadLine()) != null)
                {
                    clist.Add(cline);
                    Console.WriteLine(cline);
                }

            }

            using (StreamWriter writer = new StreamWriter("../../panda-dcompressed.txt"))
            {
                string temp;
                foreach (string item in clist)
                {
                    temp = Compression(item);
                    writer.WriteLine(temp);
                    Console.WriteLine(temp);
                }
            }
            var dclist = new List<string>();

            using (var streamReader = new StreamReader("../../panda-dcompressed.txt"))
            {
                string dcline;
                while ((dcline = streamReader.ReadLine()) != null)
                {
                    dclist.Add(dcline);
                    //Console.WriteLine(dcline);
                }

            }
            bool compareIsSame = true;
            if (list.Count == dclist.Count)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != dclist[i])
                    {
                        Console.WriteLine("something went wrong on line - " + i.ToString()); ;
                        compareIsSame = false;
                    }
                }
            }
            Console.WriteLine("file compare: " + compareIsSame);


            Console.ReadKey();
        }

        static string compression(string line)
        {

            char digit = '0';
            int zero = 0;
            string empty = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == digit)
                {
                    zero++;
                }
                else
                {
                    //Console.Write(hold0+" ");   
                    empty = empty + zero + " ";
                    if (digit == '0') { digit = '1'; }
                    else { digit = '0'; }
                    zero = 1;
                }

            }
            //Console.Write(hold0);
            empty = empty + zero;
            return empty;
        }

        static string Compression(string line)
        {
            string[] lineElements = line.Split(' ');
            string retval = "";
            for (int i = 0; i < lineElements.Length; i++)
            {
                for (int j = 0; j < Int32.Parse(lineElements[i]); j++)
                {
                    if (i % 2 == 0) { retval += "0"; }
                    else { retval += "1"; }
                }
            }
            return retval;
        }
    }
}