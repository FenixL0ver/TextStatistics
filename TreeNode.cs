using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Доп_задания
{
    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode (T value = default(T), TreeNode<T> left = null, TreeNode<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public bool IsLeaf()
        {
            return (Left == null && Right == null);
        }
    }
}
