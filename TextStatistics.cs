using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Доп_задания
{
    
    class TextStatistics
    {
        public string Text { get; }
        public int Count { get; }
        private BinarySearchTree searchTree;
        public TextStatistics(string text)
        {
            Text = text;
            searchTree = new BinarySearchTree(Text);
            Count = text.Split().Count();
        }
        public bool Contains(string word)
        {
            return Text.Contains(word);
        }
        public int CountWord(string word)
        {
            var node = searchTree.FindWord(word, searchTree.First);
            if (node == null)
                return 0;
            else
                return node.Value.Count;
        }
        public string FindMinByBool(int number)
        {
            var min = int.MaxValue;
            var en = Text.Split().Distinct();
            string result = "nil";
            foreach (var x in en)
            {
                var count = CountWord(x);
                if (count < min&& count >= number)
                {
                    min = count;
                    result = x;
                }
            }
            return result;
        }

        public string FindMaxNotMore (int ceil)
        {
            var count_str = searchTree.FindMaxNotMore(searchTree.First, ceil);
            return count_str.String;
        }

        public LinkedList<string> GetWordsByStart (string start)
        {
            var result = new LinkedList<string>();
            var ss = Text.Split().Distinct();
            foreach (String s in ss)
            {
                if (s.StartsWith(start))
                    result.AddLast(s);
            }
            return result;
        }

        public void PrintInAlphabetOrder()
        {
            BinarySearchTree.PrintInAlphabetOrder(this.searchTree.First);
        }
    }
}
