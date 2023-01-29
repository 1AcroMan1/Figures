using System;
using System.Collections.Generic;

namespace Figure
{
    public class Figures
    {
        public static void Main(string[] args)
        {

        }
        private List<float> _data = new List<float>();
        public IFigure ConcretFigure { private get; set; }
        public Figures(List<float> data, IFigure figure)
        {
            _data = data;
            ConcretFigure = figure;
        }
        public float CalculateArea()
        {
            return ConcretFigure.CountArea(_data);
        }
    }
    public interface IFigure
    {
        public float CountArea(List<float> data);
    }
    public class Round: IFigure
    {
        public float CountArea(List<float> data)
        {
            float area = MathF.PI * data[0]*data[0];
            return area;
        }
    }
    public class Triangle: IFigure
    {
        public float CountArea(List<float> data)
        {
            if(data.ToArray().Length!=3)
            {
                return 0;
            }
            CheckCorner(data);
            float perim = data[0] + data[1] + data[2];
            float area = MathF.Sqrt(perim*(perim-data[0])*(perim-data[1])*(perim-data[2]));
            return area;
        }
        private void CheckCorner(List<float> data)
        {
            float max = MathF.Max(data[0], MathF.Max(data[1], data[2]));
            float min = MathF.Min(data[0], MathF.Min(data[1], data[2]));
            int minID = 99;
            int middleID = 99;
            for (int i = 0; i <= 2; i++)
            {
                if (data[i] == min)
                {
                    minID = i;
                }
                if (data[i] != min && data[i] != max)
                {
                    middleID = i;
                }
            }
            if (MathF.Sqrt(MathF.Pow(data[minID], 2) + MathF.Pow(data[middleID], 2)) == max)
            {
                Console.WriteLine("Triangle has a straight corner");
            }
        }
    }
}
