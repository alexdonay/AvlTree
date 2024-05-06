using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTree
{
    public class Nodo <T> where T : IComparable<T>
    {
        public Nodo<T> Left { get; set; }
        public Nodo<T> Right { get; set; }
        public int Height { get; set; }
        public T Value { get; set; }
        public Nodo(T value) { Value = value; }
        public void addNodoLeft(Nodo<T> nodo)
        {
            this.Left = nodo;
        }
        public void addNodoRight(Nodo<T> nodo)
        {
            this.Right = nodo;
        }
        public int CompareTo(Nodo<T> outroNo)
        {
            return Value.CompareTo(outroNo.Value);
        }
        public override string ToString()
        {
            return $"{this.Value}";
        }
        public int GetHeight()
        {
            if (this == null) return 0;
            return 1 + Math.Max(Left?.GetHeight() ?? 0, Right?.GetHeight() ?? 0);
        }
        public int GetBalanceFactor()
        {
            if (Left == null || Right == null) return 0;
            return (Left.GetHeight()) - Right.GetHeight();
        }
    }
}
