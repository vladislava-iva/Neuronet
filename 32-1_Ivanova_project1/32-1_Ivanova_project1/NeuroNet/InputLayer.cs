using System;
using System.IO;

namespace _32_1_Ivanova_project1.NeuroNet
{
    class InputLayer
    {

        //  Поля
        private double[,] trainset;//100 изображений в обучающей выборке
        private double[,] testset;//10 изображений в тестовой выборке

        //Свойства
        public double [,] Trainset { get => trainset; }
        public double [,] Testset { get => testset; }

        // Перемешивание строк файла
        private void Shuffle(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Random rnd = new Random();

            for (int i = lines.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);

                string temp = lines[i];
                lines[i] = lines[j];
                lines[j] = temp;
            }

            File.WriteAllLines(path, lines);
        }

        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;  //директория, в которой экзэшник находится
            string[] tmpArrStr; //временный массив строк
            string[] tmpStr; //временный (вспомогательный)массив элементов в строке

            switch (nm)
            {
                case NetworkMode.Train:

                    Shuffle(path + "train.txt");

                    tmpArrStr = File.ReadAllLines(path + "train.txt");
                    trainset = new double[tmpArrStr.Length, 16];

                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');

                        for (int j = 0; j < 16; j++)
                        {
                            trainset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    break;
                case NetworkMode.Test:
                    tmpArrStr = File.ReadAllLines(path + "train.txt");
                    testset = new double[tmpArrStr.Length, 16];

                    for (int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split(' ');

                        for (int j = 0; j < 16; j++)

                        {
                            testset[i, j] = double.Parse(tmpStr[j]);
                        }
                    }
                    break;
                case NetworkMode.Demo:
                    break;
                default:
                    break;
            }
        }
    }
}
