using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public Nodo<T> root;
        public AVLTree() { }
        public void Add(T value)
        {
            Nodo<T> newNodo = new Nodo<T>(value);
            if (this.root == null)
            {
                this.root = newNodo;
            }
            else
            {
                AddRecursive(this.root, newNodo);
            }

            this.root = Balance(this.root);
        }
        public void Remove(T value)
        {
            Nodo<T> toRemove = new Nodo<T>(value);
            RemoveRecursive(this.root, toRemove);
            this.root = Balance(this.root);

        }
        private Nodo<T> Balance(Nodo<T> nodo)
        {
            if (nodo == null) return null;

            int balanceFactor = nodo.GetBalanceFactor();
            int leftBalanceFactor = nodo.Left != null ? nodo.Left.GetBalanceFactor() : 0;
            int rightBalanceFactor = nodo.Right != null ? nodo.Right.GetBalanceFactor() : 0;
            if (balanceFactor > 1 && leftBalanceFactor >= 0)
            {
                return RightRotate(nodo);
            }
            if (balanceFactor < -1 && rightBalanceFactor <= 0)
            {
                return LeftRotate(nodo);
            }
            if (balanceFactor > 1 && leftBalanceFactor < 0)
            {
                nodo.Left = LeftRotate(nodo.Left);
                return RightRotate(nodo);
            }
            if (balanceFactor < -1 && rightBalanceFactor > 0)
            {
                nodo.Right = RightRotate(nodo.Right);
                return LeftRotate(nodo);
            }

            return nodo;
        }
        private Nodo<T> RightRotate(Nodo<T> actNodo)
        {
            Nodo<T> auxLeftNodo = actNodo.Left;
            Nodo<T> leftNodo = auxLeftNodo.Right;
            auxLeftNodo.Right = actNodo;
            actNodo.Left = leftNodo;
            return auxLeftNodo;
        }

        private Nodo<T> LeftRotate(Nodo<T> actnodo)
        {
            Nodo<T> auxRightNodo = actnodo.Right;
            Nodo<T> rightNodo = auxRightNodo.Left;
            auxRightNodo.Left = actnodo;
            actnodo.Right = rightNodo;
            return auxRightNodo;
        }
        private Nodo<T> RemoveRecursive(Nodo<T> actNodo, Nodo<T> toRemove)
        {
            if (actNodo == null) { return null; }

            int comparer = actNodo.CompareTo(toRemove);
            if (comparer < 0)
            {
                actNodo.Right = RemoveRecursive(actNodo.Right, toRemove);
            }
            else if (comparer > 0)
            {
                actNodo.Left = RemoveRecursive(actNodo.Left, toRemove);
            }
            else
            {
                if (actNodo.Left == null && actNodo.Right == null)
                {
                    return null;
                }
                else if (actNodo.Left == null)
                {
                    return actNodo.Right;
                }
                else if (actNodo.Right == null)
                {
                    return actNodo.Left;
                }
                else
                {
                    Nodo<T> successor = FindMin(actNodo.Right);
                    actNodo.Value = successor.Value;
                    actNodo.Right = RemoveRecursive(actNodo.Right, successor);
                }
            }
            return Balance(actNodo);
        }

        private Nodo<T> FindMin(Nodo<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToStringRecursive(root, sb);
            return sb.ToString();
        }
        private void AddRecursive(Nodo<T> nodo, Nodo<T> newNodo)
        {
            int comparer = nodo.CompareTo(newNodo);
            if (comparer < 0)
            {
                if (nodo.Right == null)
                {
                    nodo.Right = newNodo;
                }
                else
                {
                    AddRecursive(nodo.Right, newNodo);
                }
            }
            else if (comparer >= 0)
            {
                if (nodo.Left == null)
                {
                    nodo.Left = newNodo;
                }
                else
                {
                    AddRecursive(nodo.Left, newNodo);
                }
            }
        }
        private void ToStringRecursive(Nodo<T> nodo, StringBuilder sb)
        {
            if (nodo == null)
            {
                return;
            }
            ToStringRecursive(nodo.Left, sb);
            sb.Append(nodo.Value + " ");
            ToStringRecursive(nodo.Right, sb);
        }
        public void PrintTree()
        {
            PrintTreeRecursive(this.root, 0, false);
        }

        private void PrintTreeRecursive(Nodo<T> nodo, int level, bool isRightChild)
        {
            if (nodo == null)
            {
                return;
            }

            PrintTreeRecursive(nodo.Right, level + 1, true);

            PrintSpaces(level * 4);
            if (isRightChild)
            {
                Console.Write(" /--");
            }
            else
            {
                Console.Write(" \\--");
            }
            Console.WriteLine(nodo.Value);

            PrintTreeRecursive(nodo.Left, level + 1, false);
        }

        private void PrintSpaces(int spaces)
        {
            for (int i = 0; i < spaces; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
