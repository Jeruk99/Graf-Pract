using System;
using System.Collections.Generic;
using System.Text;

namespace Graf_Pract
{
    class Graf
    {
        private int size; // количество вершин в графе
        private bool[,] adjacency; // матрица смежности (ссылка)
        private bool[,] achievement; // матрица достижимости (ссылка)
        private bool[] vector; // вектор посещенных вершин для обхода (ссылка)

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public bool[,] Adjacency
        {
            get { return adjacency; }
            set { adjacency = value; }
        }
        public bool[,] Achievement
        {
            get { return achievement; }
            set { achievement = value; }
        }
        public bool[] Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        public Graf(int size, bool[,] G) // конструктор
                                         // G – матрица для инициализации матрицы смежности графа
        {
            adjacency = G; // инициализации матрицы смежности
            achievement = new bool[size, size];
            vector = new bool[size]; // выделение памяти для вектора посещенных вершин
            for (int i = 0; i < size; i++) // инициализация вектора посещенных вершин
                vector[i] = false;
            Size = size;

        }
        public bool[,] MatrAssignment(bool[,] A)
        {
            bool[,] T = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    T[i, j] = A[i, j];
                }
            }
            return T;
        }
        public bool[,] MatrSum(bool[,] A, bool[,] B)
        {
            bool[,] T = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    T[i, j] = (A[i, j] || B[i, j]);
                }
            }
            return T;
        }
        public bool[,] MatrProduct(bool[,] A, bool[,] B)
        {
            bool[,] T = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        T[i, j] = T[i, j] || A[i, k] && B[k, j];
                    }
                }
            }
            return T;

        }
        public void MatrAchieve()
        {
            bool[,] T = new bool[size, size];
            T = MatrAssignment(Adjacency);
            bool[,] Achievement = MatrAssignment(T);
            for (int i = 1; i < size; i++)
            {
                T = MatrProduct(T, Adjacency);
                Achievement = MatrSum(Achievement, T);
            }
        }
        public void TrassDepth(int i)
        {
            vector[i] = true;
            Console.WriteLine(i);
            for (int k = 0; k < size; k++)
            {
                if ((achievement[i, k] == true) && (vector[k] == false)) ;
            }
        }
        public void TrassAll()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++) Vector[j] = false;
                TrassDepth(i);
            }
        }


    }
}

