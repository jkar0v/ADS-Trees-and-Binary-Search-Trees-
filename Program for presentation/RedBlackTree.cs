using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_for_presentation
{
    internal class RedBlackTree
    {

        private Node root;
        private Node TNULL;

        public RedBlackTree()
        {
            TNULL = new Node(0);
            TNULL.color = Color.BLACK;
            TNULL.left = null;
            TNULL.right = null;
            root = TNULL;
        }

        // Търсене
        public Node SearchTree(int key)
        {
            return SearchTreeHelper(root, key);
        }

        private Node SearchTreeHelper(Node node, int key)
        {
            if (node == TNULL || key == node.data)
                return node;
            if (key < node.data)
                return SearchTreeHelper(node.left, key);
            return SearchTreeHelper(node.right, key);
        }

        // Лява ротация
        private void LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;
            if (y.left != TNULL)
                y.left.parent = x;
            y.parent = x.parent;
            if (x.parent == null)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;
            y.left = x;
            x.parent = y;
        }

        // Дясна ротация
        private void RightRotate(Node x)
        {
            Node y = x.left;
            x.left = y.right;
            if (y.right != TNULL)
                y.right.parent = x;
            y.parent = x.parent;
            if (x.parent == null)
                root = y;
            else if (x == x.parent.right)
                x.parent.right = y;
            else
                x.parent.left = y;
            y.right = x;
            x.parent = y;
        }

        // Добавяне
        public void Insert(int key)
        {
            Node node = new Node(key);
            node.parent = null;
            node.data = key;
            node.left = TNULL;
            node.right = TNULL;
            node.color = Color.RED;

            Node y = null;
            Node x = root;

            while (x != TNULL)
            {
                y = x;
                if (node.data < x.data)
                    x = x.left;
                else
                    x = x.right;
            }

            node.parent = y;
            if (y == null)
                root = node;
            else if (node.data < y.data)
                y.left = node;
            else
                y.right = node;

            if (node.parent == null)
            {
                node.color = Color.BLACK;
                return;
            }

            if (node.parent.parent == null)
                return;

            FixInsert(node);
        }

        private void FixInsert(Node k)
        {
            Node u;
            while (k.parent.color == Color.RED)
            {
                if (k.parent == k.parent.parent.right)
                {
                    u = k.parent.parent.left;
                    if (u.color == Color.RED)
                    {
                        u.color = Color.BLACK;
                        k.parent.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;
                        k = k.parent.parent;
                    }
                    else
                    {
                        if (k == k.parent.left)
                        {
                            k = k.parent;
                            RightRotate(k);
                        }
                        k.parent.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;
                        LeftRotate(k.parent.parent);
                    }
                }
                else
                {
                    u = k.parent.parent.right;
                    if (u.color == Color.RED)
                    {
                        u.color = Color.BLACK;
                        k.parent.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;
                        k = k.parent.parent;
                    }
                    else
                    {
                        if (k == k.parent.right)
                        {
                            k = k.parent;
                            LeftRotate(k);
                        }
                        k.parent.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;
                        RightRotate(k.parent.parent);
                    }
                }
                if (k == root)
                    break;
            }
            root.color = Color.BLACK;
        }

        // Минимален възел от поддървото
        private Node Minimum(Node node)
        {
            while (node.left != TNULL)
                node = node.left;
            return node;
        }

        // Изтриване
        public void DeleteNode(int data)
        {
            DeleteNodeHelper(this.root, data);
        }

        private void DeleteNodeHelper(Node node, int key)
        {
            Node z = TNULL, x, y;
            while (node != TNULL)
            {
                if (node.data == key)
                    z = node;
                if (node.data <= key)
                    node = node.right;
                else
                    node = node.left;
            }

            if (z == TNULL)
            {
                Console.WriteLine("Не е намерен елемент за изтриване.");
                return;
            }

            y = z;
            Color yOriginalColor = y.color;
            if (z.left == TNULL)
            {
                x = z.right;
                Transplant(z, z.right);
            }
            else if (z.right == TNULL)
            {
                x = z.left;
                Transplant(z, z.left);
            }
            else
            {
                y = Minimum(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if (y.parent == z)
                    x.parent = y;
                else
                {
                    Transplant(y, y.right);
                    y.right = z.right;
                    y.right.parent = y;
                }
                Transplant(z, y);
                y.left = z.left;
                y.left.parent = y;
                y.color = z.color;
            }

            if (yOriginalColor == Color.BLACK)
                FixDelete(x);
        }

        private void Transplant(Node u, Node v)
        {
            if (u.parent == null)
                root = v;
            else if (u == u.parent.left)
                u.parent.left = v;
            else
                u.parent.right = v;
            v.parent = u.parent;
        }

        private void FixDelete(Node x)
        {
            Node s;
            while (x != root && x.color == Color.BLACK)
            {
                if (x == x.parent.left)
                {
                    s = x.parent.right;
                    if (s.color == Color.RED)
                    {
                        s.color = Color.BLACK;
                        x.parent.color = Color.RED;
                        LeftRotate(x.parent);
                        s = x.parent.right;
                    }
                    if (s.left.color == Color.BLACK && s.right.color == Color.BLACK)
                    {
                        s.color = Color.RED;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.right.color == Color.BLACK)
                        {
                            s.left.color = Color.BLACK;
                            s.color = Color.RED;
                            RightRotate(s);
                            s = x.parent.right;
                        }
                        s.color = x.parent.color;
                        x.parent.color = Color.BLACK;
                        s.right.color = Color.BLACK;
                        LeftRotate(x.parent);
                        x = root;
                    }
                }
                else
                {
                    s = x.parent.left;
                    if (s.color == Color.RED)
                    {
                        s.color = Color.BLACK;
                        x.parent.color = Color.RED;
                        RightRotate(x.parent);
                        s = x.parent.left;
                    }
                    if (s.right.color == Color.BLACK && s.left.color == Color.BLACK)
                    {
                        s.color = Color.RED;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.left.color == Color.BLACK)
                        {
                            s.right.color = Color.BLACK;
                            s.color = Color.RED;
                            LeftRotate(s);
                            s = x.parent.left;
                        }
                        s.color = x.parent.color;
                        x.parent.color = Color.BLACK;
                        s.left.color = Color.BLACK;
                        RightRotate(x.parent);
                        x = root;
                    }
                }
            }
            x.color = Color.BLACK;
        }

        public void PrintInOrder()
        {
            InOrderHelper(root);
            Console.WriteLine();
        }

        private void InOrderHelper(Node node)
        {
            if (node != TNULL)
            {
                InOrderHelper(node.left);
                Console.Write(node.data + " ");
                InOrderHelper(node.right);
            }
        }
    }
}
