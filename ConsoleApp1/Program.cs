using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using static System.Console;
namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //var result = FrequencyQueries.Execute(new List<List<int>>()
            //{
            //    new List<int>(){ 3, 4},
            //    new List<int>(){ 2, 1003},
            //    new List<int>(){ 1, 16},
            //    new List<int>(){ 3, 1}
            //});
            //result.ForEach(x => Console.WriteLine(x));

            //var s =ConvertBinaryToText(new List<List<int>>()
            //{
            //    new List<int>(){ 0, 0, 1, 1, 1, 0, 0, 0 },
            //    new List<int>(){ 0,0,1,1,1,0,0,0 },
            //    new List<int>(){ 0,0,1,1,1,0,0,0 },
            //    new List<int>(){ 0,0,1,0,1,1,0,1 },
            //    new List<int>(){ 0,0,1,1,0,0,1,1 },
            //    new List<int>(){ 0,1,1,0,1,1,0,1 },
            //    new List<int>(){ 0,1,1,1,1,0,0,0 },
            //    new List<int>(){ 0,0,1,0,1,1,0,1 },
            //    new List<int>(){ 0,1,1,0,1,1,0,0 },
            //    new List<int>(){ 0,1,1,0,1,1,1,1 },
            //    new List<int>(){ 0,1,1,1,0,0,1,0 },
            //    new List<int>(){ 0,1,1,0,0,1,0,0 },
            //});
            //Console.WriteLine(s);
            //Console.ReadLine();
            //ref var a = (aa != null ? ref aa[0] : ref aa[1]);
            //System.Threading.Thread.Sleep() t = new System.Threading.Thread(new para);

            //using (var api = OcrApi.Create())
            //{
            //    api.Init(Languages.English, oem: OcrEngineMode.OEM_TESSERACT_ONLY);
            //    using (var bmp = Bitmap.FromFile(@"C:\Users\manoj\OneDrive\Desktop\report.png") as Bitmap)
            //    {
            //        string plainText = api.GetTextFromImage(bmp);
            //        Console.WriteLine(plainText);
            //    }
            //}
            //var Ocr = new IronOcr.AdvancedOcr()
            //{
            //    CleanBackgroundNoise = true,
            //    EnhanceContrast = true,
            //    EnhanceResolution = true,
            //    Language = IronOcr.Languages.English.OcrLanguagePack,
            //    Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
            //    ColorSpace = AdvancedOcr.OcrColorSpace.Color,
            //    DetectWhiteTextOnDarkBackgrounds = true,
            //    InputImageType = AdvancedOcr.InputTypes.AutoDetect,
            //    RotateAndStraighten = true,
            //    ReadBarCodes = true,
            //    ColorDepth = 4
            //};

            //var testDocument = @"C:\Users\manoj\OneDrive\Desktop\test1.jpeg";
            //var Results = Ocr.Read(testDocument);
            //Console.WriteLine(Results.Text);
            ////Console.WriteLine("Barcodes:" + String.Join(",", Results.Barcodes.Select(b => b.Value)));
            ///Con


            //HourGlassProblem.Execute(new[] { "1 1 1 0 0 0", "0 1 0 0 0 0", "1 1 1 0 0 0", "0 0 2 4 4 0", "0 0 0 2 0 0", "0 0 1 2 4 0" });
            //HourGlassProblem.Execute(new[] { "-9 -9 -9 1 1 1", "0 -9 0 4 3 2", "-9 -9 -9 1 2 3", "0 0 8 6 6 0", "0 0 0 -2 0 0", "0 0 1 2 4 0" });
            //Console.WriteLine(string.Join(", ", rotLeft(new int[] { 1,2,3,4,5,}, 4)));


            //MinimumBribeProblem.minimumBribes(new int[] { 2,1,5,3,4});
            //MinimumBribeProblem.minimumBribes(new int[] { 1, 2, 5, 3, 7, 8, 6, 4 });

            //Min Swaps 2
            //WriteLine(MinSwapsTwo.Execute(new int[] { 2, 3, 4, 1, 5 }));
            //WriteLine(MinSwapsTwo.Execute(new int[] { 7,1,3,2,4,5,6}));

            //Array Manipulation
            //WriteLine(ArrayManipulationProblem.Execute(10, new[] { new[] { 1, 5, 3 }, new[] { 4, 8, 7 }, new[] { 6, 9, 1 } }));

            //Duplicate checker
            //People Kiko = new People() { Id = 1, Forename = "Kiko", Surname = "Cassilla" };
            //People Luke = new People() { Id = 2, Forename = "Luke", Surname = "Ayling" };
            //People Gani = new People() { Id = 3, Forename = "Gianni", Surname = "Allioski" };
            //People Liam = new People() { Id = 4, Forename = "Liam", Surname = "Cooper" };
            //People Ben = new People() { Id = 5, Forename = "Ben", Surname = "White" };

            //List<People> originals = new List<People>() { Kiko, Luke, Gani, Liam, Ben };
            //List<People> newPeople = new List<People>() { Gani, Liam };
            //var checker = new DuplicateChecker();

            //// act
            //var duplicates = checker.FindDuplicates(originals, newPeople);


            //// assert
            //WriteLine(duplicates.Contains(Gani));

            ///Ransom Note
            //RansomNote.Execute(7, 4, "ive got a lovely bunch of coconuts", "ive got some coconuts");
            //RansomNote.Execute(6, 5, "two times three is not four", "two times two is four");
            //RansomNote.Execute(6, 4, "give me one grand today night", "give one grand today");
            //string[] lines = System.IO.File.ReadAllLines(@"Data\input16.txt");
            //RansomNote.Execute(30000, 30000, lines[1], lines[2]);

            //Console.WriteLine(TwoStrings.Execute("hi", "world"));

            //Console.WriteLine(Anagrams.Execute("gffryqktmwocejbxfidpjfgrrkpowoxwggxaknmltjcpazgtnakcfcogzatyskqjyorcftwxjrtgayvllutrjxpbzggjxbmxpnde"));--471
            //Console.WriteLine(Anagrams.Execute("kkkk")); -- 10

            //Console.WriteLine(TripletCount.Execute(new List<long>() { 1, 3, 9, 9, 27, 81 }, 3));
            //Console.WriteLine(TripletCount.Execute(new List<long>() { 1, 5, 5, 25, 125 }, 5));
            Console.ReadLine();
        }

        static string ConvertBinaryToText(List<List<int>> seq)
        {
            return new String(seq.Select(s => (char)s.Aggregate((a, b) => a * 2 + b)).ToArray());
        }

        private static void NameStartsWith(string s) => s.StartsWith("S");

        static int[] rotLeft(int[] a, int d)
        {
            var b = new int[a.Length];
            Array.Copy(a, d, b, 0, a.Length - d);

            var actualLength = a.Length - d;
            for (int i = 0; i < d; i++)
            {
                b[actualLength + i] = a[i];
            }
            return b;
        }


        static long repeatedString(string s, long n)
        {
            var count = 0L;
            foreach (var letter in s)
            {
                if (letter == 'a')
                    count++;
            }
            var possibleStringRepeatitions = n / s.Length;
            count *= possibleStringRepeatitions;
            var offsetStringLength = n % s.Length;

            for (int i = 0; i < offsetStringLength; i++)
            {
                if (s[i] == 'a')
                    count++;
            }
            //var maxvalue = 61999999;
            //if (s.Length < n)
            //{
            //    if (n > maxvalue)
            //    {
            //        while (n > maxvalue || n > 0)
            //        {
            //            int nn = maxvalue;
            //            int v1 = (int)Math.Ceiling(Convert.ToDecimal(nn) / Convert.ToDecimal(s.Length));
            //            StringBuilder sb = new StringBuilder();
            //            for (int i = 0; i < v1; i++)
            //            {
            //                sb.Append(s);
            //            }
            //            temp = sb.ToString();
            //            //temp = string.Concat(Enumerable.Repeat(s, v1));
            //            count += temp.Substring(0, nn).ToCharArray().Count(c => c == 'a');
            //            n -= maxvalue;
            //        }
            //    }
            //    else
            //    {
            //        int v = Convert.ToInt32(Math.Ceiling((double)n / (double)s.Length));
            //        temp = string.Concat(Enumerable.Repeat(s, v));
            //        count += temp.Substring(0, Convert.ToInt32(n)).ToCharArray().Count(c => c == 'a');
            //    }

            //}

            return count;
        }
    }

   

}

