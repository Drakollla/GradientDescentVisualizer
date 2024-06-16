using System.Windows;

namespace GradientDescentVisualizer.Model
{
    public class GradientDescentWithStepDivision : GradientDescent
    {
        private double _stepDivisionCoefficient;

        public GradientDescentWithStepDivision(string function, Point initialPoint, double learningRate, double epsilon, int maxIterations, bool stepDivision, double stepDivisionCoefficient)
            : base(function, initialPoint, learningRate, epsilon, maxIterations, stepDivision)
        {
            _stepDivisionCoefficient = stepDivisionCoefficient;
        }

        public override Point FindMinimum(Func<Point, double> function, Func<Point, Point> gradient)
        {
            Point currentPoint = InitialPoint;

            double currentLearningRate = LearningRate;

            for (int i = 0; i < MaxIterations; i++)
            {
                Point gradientValue = gradient(currentPoint);

                currentPoint = new Point(currentPoint.X - currentLearningRate * gradientValue.X, currentPoint.Y - currentLearningRate * gradientValue.Y);

                if (Math.Abs(gradientValue.X) < Epsilon && Math.Abs(gradientValue.Y) < Epsilon)
                    break;

                currentLearningRate *= _stepDivisionCoefficient;
            }

            return currentPoint;
        }
    }
}