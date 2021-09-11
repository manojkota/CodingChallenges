using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeChallenge
{
    class PalindromicCrossword
    {
        static void Main(string[] args)
        {
            var readFromFile = true;
            string[] lines = null;
            if (readFromFile)
            {
                lines = System.IO.File.ReadAllLines(@"Data\palindromecrossword_sample_input.txt");
            }
            int t = readFromFile ? Convert.ToInt32(lines[0]) : Convert.ToInt32(Console.ReadLine());
            var ln = 1;
            using StreamWriter file = new StreamWriter(@"Data\output.txt", append: false);
            
                for (int i = 0; i < t; i++)
                {
                    var inputData = new List<int>();
                    var rowData = new List<string>();
                    var line = readFromFile ? lines[ln] : Console.ReadLine();
                    ln++;
                    inputData.AddRange(line.Split(' ').Select(x => Convert.ToInt32(x)));
                    var caseInputLines = inputData[0];
                    for (int j = 0; j < caseInputLines; j++)
                    {
                        rowData.Add(readFromFile ? lines[ln] : Console.ReadLine());
                        ln++;
                    }
                    go(i + 1, inputData, rowData);
                }
            
            
            Console.ReadLine();
        }

        static void go(int cn, List<int> inputData, List<string> rowData)
        {
            int n = inputData[0], m = inputData[1];
            char[][] map = nm(n,m, rowData);
            DJSet ds = new DJSet(n * m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m;)
                {
                    int k = j;
                    while (k < m && map[i][k] != '#') k++;

                    for (int l = j, r = k - 1; l < r; l++, r--)
                    {
                        ds.union(i * m + l, i * m + r);
                    }

                    j = k + 1;
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n;)
                {
                    int k = j;
                    while (k < n && map[k][i] != '#') k++;

                    for (int l = j, r = k - 1; l < r; l++, r--)
                    {
                        ds.union(l * m + i, r * m + i);
                    }

                    j = k + 1;
                }
            }

            char[] let = new char[n * m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i][j] == '#' || map[i][j] == '.') continue;
                    int root = ds.root(i * m + j);
                    let[root] = map[i][j];
                }
            }
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i][j] == '.')
                    {
                        int root = ds.root(i * m + j);
                        if (let[root] == 0) continue;
                        ans++;
                        map[i][j] = let[root];
                    }
                }
            }
            Console.WriteLine("Case #{0}: {1}", cn, ans);
            foreach (var row in map)
            {
                Console.WriteLine(new string(row));
            }
        }

        private static char[][] nm(int n, int m, List<string> rowData)
        {
            char[][] map = new char[n][];
            for (int i = 0; i < n; i++) map[i] = rowData[i].ToCharArray();
            return map;
        }

        static void Execute(int cn, List<int> inputData, List<string> rowData, StreamWriter ms)
        {
            var result = 0;
            int n = inputData[0], m = inputData[1];
            char empty = '.', block = '#';
            var horizontalDict = new Dictionary<int, (int, string)>();
            var verticalDict = new Dictionary<int, (int, string)>();
            for (int i = 0; i < n; i++)
            {
                horizontalDict.Clear();
                for (int j = 0; j < m; j++)
                {
                    if(rowData[i][j] == block)
                    {
                        continue;
                    }
                    if (rowData[i][j] == empty)
                    {
                        //if (horizontalDict.ContainsKey(j))
                        //{
                        //    var word = horizontalDict[j];
                        //    var wli = word.Item2.Length - 1;
                        //    var wfi = word.Item1;
                        //    var ci = j - wfi;
                        //    //check the equal lenth word from the other end
                        //    if (word.Item2[wli - ci] != empty)
                        //    {
                        //        rowData[i] = Replace(rowData[i].ToCharArray(), j, word.Item2[wli - ci]);
                        //        result++;
                        //        AddtoDict(horizontalDict, wfi, wfi + wli, word.Item2);
                        //        continue;
                        //    }
                        //}
                        //first lertter of the word
                        if (j == 0 || rowData[i][j - 1] == block)
                        {
                            //check the word length by finding '#'
                            var endIndex = rowData[i].Substring(j).IndexOf(block) > 0 ? rowData[i].Substring(j).IndexOf(block) : m - j;
                            var word = rowData[i].Substring(j, endIndex);
                            var wli = word.Length - 1;
                            //AddtoDict(horizontalDict, j, endIndex, word);
                            //check first letter equals last letter..if not fill it
                            if (rowData[i][j + wli] != empty && rowData[i][j] != rowData[i][j + wli])
                            {
                                rowData[i] = Replace(rowData[i].ToCharArray(), j, j + wli);
                                result++;
                                //AddtoDict(horizontalDict, j, endIndex, rowData[i].Substring(j, wli));
                                continue;
                            }

                        }
                        else
                        {
                            var wfi = rowData[i].Substring(0, j).LastIndexOf(block) > 0 ? rowData[i].Substring(0, j).LastIndexOf(block) + 1 : 0;
                            //check the word length by finding '#'
                            var subWord = rowData[i].Substring(wfi);
                            var word = rowData[i].Substring(wfi, subWord.IndexOf(block) > 0 ? subWord.IndexOf(block) : subWord.Length);
                            var wli = word.Length - 1;
                            var ci = j - wfi;
                            //AddtoDict(horizontalDict, wfi, wfi + wli, word);
                            //check the equal lenth word from the other end
                            if (word[wli - ci] != empty)
                            {
                                rowData[i] = Replace(rowData[i].ToCharArray(), j, word[wli - ci]);
                                result++;
                                //AddtoDict(horizontalDict, wfi, wfi + wli, rowData[i].Substring(wfi, wli));
                                continue;
                            }
                        }


                        //check vertically
                        char[] vw = new char[n];
                        int vu = 0, vufat = 0;
                        for (int vr = i - 1; vr >= 0; vr--)
                        {
                            if (rowData[vr][j] == block)
                            {
                                break;
                            }
                            vw[vr] = rowData[vr][j];
                            vufat = vr;
                            vu++;
                        }
                        int vd = 0, vdfat = 0;
                        for (int vr = i + 1; vr < n; vr++)
                        {
                            if (rowData[vr][j] == block)
                            {
                                break;
                            }
                            vw[vr] = rowData[vr][j];
                            vdfat = vr;
                            vd++;
                        }
                        if (vu != 0 || vd != 0)
                        {
                            if(vu == vd)
                            {
                                continue;
                            }
                            if (vu > vd)
                            {
                                if (vw[vufat + vd] != empty)
                                {
                                    rowData[i] = Replace(rowData[i].ToCharArray(), j, vw[vufat + vd]);
                                    result++;
                                    continue;
                                }
                            }
                            else
                            {
                                if (vw[vdfat -vu] != empty)
                                {
                                    rowData[i] = Replace(rowData[i].ToCharArray(), j, vw[vdfat - vu]);
                                    result++;
                                    continue;
                                }
                            }
                        }
                    }
                }
                
            }
            Console.WriteLine("Case #{0}: {1}", cn, result);
            ms.WriteLine("Case #{0}: {1}", cn, result);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(rowData[i]);
                ms.WriteLine(rowData[i]);
            }
        }

        private static void AddtoDict(Dictionary<int, (int, string)> hd, int j, int endIndex, string word)
        {
            for (int d = j; d <= endIndex; d++)
            {
                if (hd.ContainsKey(d))
                {
                    hd[d] = (d, word);
                }
                else
                {
                    hd.Add(d, (d, word));
                }
            }
        }

        static string Replace(char[] word, int i, int j)
        {
            word[i] = word[j];
            return new string(word);
        }

        static string Replace(char[] word, int i, char j)
        {
            word[i] = j;
            return new string(word);
        }
    }

    public class DJSet
    {
        public int[] upper;

        public DJSet(int n)
        {
            upper = new int[n];
            upper.Fill(-1);
        }

        public int root(int x)
        {
            return upper[x] < 0 ? x : (upper[x] = root(upper[x]));
        }

        public bool equiv(int x, int y)
        {
            return root(x) == root(y);
        }

        public bool union(int x, int y)
        {
            x = root(x);
            y = root(y);
            if (x != y)
            {
                if (upper[y] < upper[x])
                {
                    int d = x;
                    x = y;
                    y = d;
                }
                upper[x] += upper[y];
                upper[y] = x;
            }
            return x == y;
        }

        public int count()
        {
            int ct = 0;
            foreach (var u in upper)
            {
                if (u < 0) ct++;
            }
            return ct;
        }

        public int[][] toBucket()
        {
            int n = upper.Length;
            int[][] ret = new int[n][];
            int[] rp = new int[n];
            for (int i = 0; i < n; i++) if (upper[i] < 0) ret[i] = new int[-upper[i]];
            for (int i = 0; i < n; i++)
            {
                int r = root(i);
                ret[r][rp[r]++] = i;
            }
            return ret;
        }
    }

    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }
    }
}
