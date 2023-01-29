using System;
using Xunit;
using Figure;
using System.Collections.Generic;


namespace FiguresTest
{
    public class FigureTest
    {
        [Fact]
        public void RoundWithRadius10()
        {
            List<float> data = new List<float>();
            data.Add(10);

            Figures figure = new Figures(data, new Round());
            float result = figure.CalculateArea();

            Assert.Equal(314.15926535897932384626433832795f, result);
        }
        [Fact]
        public void AddingSoMuchDataForRound()
        {
            List<float> data = new List<float>();
            data.Add(10);
            data.Add(5);
            data.Add(3);

            Figures figure = new Figures(data, new Round());
            float result = figure.CalculateArea();

            Assert.Equal(314.15926535897932384626433832795f, result);
        }
        [Fact]
        public void Triangle_3_4_5()
        {
            List<float> data = new List<float>();
            data.Add(3);
            data.Add(4);
            data.Add(5);

            Figures figure = new Figures(data, new Triangle());
            float result = figure.CalculateArea();

            Assert.Equal(77.76889f, result);
        }
        [Fact]
        public void TriangleWithoutEnoughtData()
        {
            List<float> data = new List<float>();
            data.Add(3);

            Figures figure = new Figures(data, new Triangle());
            float result = figure.CalculateArea();

            Assert.Equal(0, result);
        }
        [Fact]
        public void StraightCornerTriangle()
        {
            List<float> data = new List<float>();
            data.Add(6);
            data.Add(8);
            data.Add(10);

            float max = MathF.Max(data[0], MathF.Max(data[1], data[2]));
            float min = MathF.Min(data[0], MathF.Min(data[1], data[2]));
            int minID = 99;
            int middleID = 99;
            for (int i =0; i<=2;i++)
            {
                if (data[i] == min)
                {
                    minID = i;
                }
                if(data[i]!=min && data[i] != max)
                {
                    middleID = i;
                }
            }
            Assert.Equal(max, MathF.Sqrt(MathF.Pow(data[minID], 2) + MathF.Pow(data[middleID], 2)));
        }
    }
}
