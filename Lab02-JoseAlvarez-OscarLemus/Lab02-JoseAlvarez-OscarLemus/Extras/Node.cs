using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_JoseAlvarez_OscarLemus.Extras
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

        public Node(T data_)
        {
            this.Data = data_;
        }

        //public void insertData(ref Node<T> node, T data)
        //{
        //    if (node == null)
        //    {
        //        node = new Node<T>(data);

        //    }
        //    else if (node.Data < data)
        //    {
        //        insertData(ref node.right, data);
        //    }

        //    else if (node.Data > data)
        //    {
        //        insertData(ref node.left, data);
        //    }
        //}
    }
}