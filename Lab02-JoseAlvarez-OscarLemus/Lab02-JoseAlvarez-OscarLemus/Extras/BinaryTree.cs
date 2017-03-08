using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_JoseAlvarez_OscarLemus.Extras
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        int element_count;

        public BinaryTree()
        {
            root = null;
            element_count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return root.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Insert(Node<T> node, T Data, Comparison<T> comparer)
        {
            if (node == null)
            {
                root = new Node<T>(Data);
                element_count++;
            }

            else if (comparer(Data, node.Data) == -1)
            {
                if (node.right == null)
                {
                    node.right = new Node<T>(Data);
                    element_count++;
                }
                else
                    Insert(node.right, Data, comparer);
            }

            else if (comparer(Data, node.Data) == 1)
            {
                if (node.left == null)
                {
                    node.left = new Node<T>(Data);
                    element_count++;
                }
                else
                    Insert(node.left, Data, comparer);
            }

        }

        public void Insert(T Data, Comparison<T> comparer)
        {
            Insert(root, Data, comparer);
        }

        public int Size()
        {
            return element_count;
        }


        public void Search(Node<T> node, Comparison<T> comparer, T data_)
        {
            if (comparer(data_, node.Data) == 0)
            {
                node.Data = data_;
            }
            else if (comparer(data_, node.Data) == 1)
            {
                Search(node.left, comparer, data_);
            }
            else if (comparer(data_, node.Data) == -1)
            {
                Search(node.right, comparer, data_);
            }
        }

        public void Search(Comparison<T> comparer, T data_)
        {
            Search(root, comparer, data_);
        }

    }
}