using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_JoseAlvarez_OscarLemus.Extras
{
    public class BinaryTree<T>
    {
        private Node<T> root;
        private int element_count;

        public BinaryTree()
        {
            root = null;
            element_count = 0;
        }

        public void Insert(T Data)
        {
            if (root == null)
            {
                root = new Node<T>(Data);
            }
            else
            {

            }
        }
    }
}