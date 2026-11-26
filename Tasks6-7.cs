using System;

namespace Lab4Tasks6and7
{
    public class RightTriangle
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set
            {
                if (value <= 0) throw new ArgumentException("Катет должен быть больше нуля.");
                a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value <= 0) throw new ArgumentException("Катет должен быть больше нуля.");
                b = value;
            }
        }

        public RightTriangle() { a = 1; b = 1; }
        public RightTriangle(double a, double b) { A = a; B = b; }

        // Убрал все знаки из вывода
        public override string ToString()
        {
            return "Треугольник (катет a: " + a + ", катет b: " + b + ")";
        }

        public double GetArea() { return 0.5 * a * b; }

        public static RightTriangle operator ++(RightTriangle t) { return new RightTriangle(t.a * 2, t.b * 2); }
        public static RightTriangle operator --(RightTriangle t) { return new RightTriangle(t.a / 2, t.b / 2); }

        public static explicit operator double(RightTriangle t)
        {
            if (t.a > 0 && t.b > 0) return t.GetArea();
            else return -1;
        }

        public static implicit operator bool(RightTriangle t) { return t.a > 0 && t.b > 0; }

        public static bool operator <=(RightTriangle t1, RightTriangle t2) { return t1.GetArea() <= t2.GetArea(); }
        public static bool operator >=(RightTriangle t1, RightTriangle t2) { return t1.GetArea() >= t2.GetArea(); }
    }
}
