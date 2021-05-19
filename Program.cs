using System;
using System.IO;

namespace day_14_binaryfiles
{
    class Program
    {
        static void Main(string[] args)
        {

            //ko mēs gribam izdarīt ?
            //sarakstīt skaitļus failā

            var ints = new[] { 0x01020304, 0x00000001, 3, 4 ,5 ,6, 7, 8 };

            /*
            //1. FileStream - faila atvēršana
            FileStream fs = new FileStream("binary.bin", FileMode.Create);

            //2. Binārais rakstītājs/lasītājs
            BinaryWriter writer = new BinaryWriter(fs);

            //3. pati rakstīšana/lasīšana
            foreach (short skaitlis in ints)
            {
                writer.Write(skaitlis);
            }

            //4. Faila aizvēršana
            writer.Close();
            */

            using (FileStream fs = new FileStream("binary.bin", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (int skaitlis in ints)
                    {
                        writer.Write(skaitlis);
                    }
                    writer.Close();

                }
            }


            /*
                //1. FileStream - faila atvēršana
                FileStream readfs = new FileStream("binary.bin", FileMode.Open);

                //2. Binārais rakstītājs/lasītājs
                BinaryReader reader = new BinaryReader(readfs);

            //3. pati rakstīšana/lasīšana

            //tekošā pozīcija strīmā
            int pos = 0;

            //cik daudaz datu ir jālasa
            int len = (int)reader.BaseStream.Length;

            int[] rez_maz = new int[len/4];

            int i = 0;
              while (pos < len)
                {
                rez_maz[i++] = reader.ReadInt32();
                pos += 4;
                }

            //4. Faila aizvēršana
            reader.Close();
            */



            using (FileStream fs = new FileStream("binary.bin", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    //tekošā pozīcija strīmā
                    int pos = 0;

                    //cik daudaz datu ir jālasa
                    int len = (int)reader.BaseStream.Length;

                    int[] rez_maz = new int[len / 4];

                    int i = 0;
                    while (pos < len)
                    {
                        rez_maz[i++] = reader.ReadInt32();
                        pos += 4;
                    }


                    reader.Close();

                }
            }





            Console.WriteLine("Hello World!");
        }
    }
}
