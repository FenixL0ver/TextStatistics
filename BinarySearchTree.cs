using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Доп_задания
{
    class BinarySearchTree 
    {
        public string Val { get; }
        private TreeNode<CountString> _first;

        public TreeNode<CountString>  First
        {
            get { return _first; }
            set
            {
                Debug.Assert(value != null);
                _first = value;
            }
        }

        public BinarySearchTree (string val)
        {
            Debug.Assert(val != "");
            Val = val;
            var ss = val.Split();
            var FNode = new CountString(ss[0]);
            First = new TreeNode<CountString>(FNode);
            for (int i=1;i<ss.Length;++i)
            {
                this.AddWord(ss[i],First);
            }
        }

        public void AddWord(string word,TreeNode<CountString> tree)
        {
            if (tree == null)
                return;
            if (word.CompareTo(tree.Value.String) > 0)
            {
                if (tree.Right == null)
                    tree.Right = new TreeNode<CountString>(new CountString(word));
                else
                    AddWord(word, tree.Right);
            }
            else if (word.CompareTo(tree.Value.String) < 0)
            {
                if (tree.Left == null)
                    tree.Left = new TreeNode<CountString>(new CountString(word));
                else
                    AddWord(word, tree.Left);
            }
            else
            {
                tree.Value.IncCount();
            }
        }

        public TreeNode<CountString> FindWord (string word,TreeNode<CountString> tree)
        {
            if (tree == null)
                return null;
            if (word.CompareTo(tree.Value.String) == 0)
            {
                return tree;
            }
            else if (word.CompareTo(tree.Value.String) < 0)
                return FindWord(word, tree.Left);
            else
                return FindWord(word, tree.Right);
        }

        public CountString FindMaxNotMore(TreeNode<CountString> treeNode,int ceil)
        {
            if (treeNode != null &&  treeNode.Value.Count <= ceil )
            {
                if (treeNode.IsLeaf())
                {
                    return treeNode.Value;
                }
                else
                {
                    var left_max = FindMaxNotMore(treeNode.Left, ceil);
                    var right_max = FindMaxNotMore(treeNode.Right, ceil);
                    var subtree_max = left_max.Count > right_max.Count ? left_max : right_max;
                    return subtree_max.Count > treeNode.Value.Count ? subtree_max : treeNode.Value;
                }
            }
            else
            {
                return new CountString();
            }
        }

        static public void PrintInAlphabetOrder(TreeNode<CountString> tree)
        {
            if (tree == null)
                return;
            PrintInAlphabetOrder(tree.Left);
            tree.Value.Print();
            PrintInAlphabetOrder(tree.Right);
        }
    }
}
