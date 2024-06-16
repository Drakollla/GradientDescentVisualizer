using System.Windows;

namespace GradientDescentVisualizer.Model
{
    public class GradientDescentWithoutStepDivision : GradientDescent
    {
        public GradientDescentWithoutStepDivision(string function, Point initialPoint, double learningRate, double epsilon, int maxIterations)
            : base(function, initialPoint, learningRate, epsilon, maxIterations, false)
        {

        }

        public override Point FindMinimum(Func<Point, double> function, Func<Point, Point> gradient)
        {
            Point currentPoint = InitialPoint;

            for (int i = 0; i < MaxIterations; i++)
            {
                Point gradientValue = gradient(currentPoint);

                currentPoint = new Point(currentPoint.X - LearningRate * gradientValue.X, currentPoint.Y - LearningRate * gradientValue.Y);

                if (Math.Abs(gradientValue.X) < Epsilon && Math.Abs(gradientValue.Y) < Epsilon)
                    break;
            }

            return currentPoint;
        }
    }
}