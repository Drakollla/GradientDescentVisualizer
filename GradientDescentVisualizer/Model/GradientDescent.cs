using System.Windows;

namespace GradientDescentVisualizer.Model
{
    public abstract class GradientDescent : ObservableObject
    {
        /*
         Function - строковое поле для ввода математической функции, которую пользователь хочет оптимизировать.
         InitialPoint - точка, с которой начинается поиск минимума функции.
         LearningRate - шаг градиентного спуска.
         Epsilon - точность, до которой необходимо найти минимум функции.
         MaxIterations - максимальное количество итераций градиентного спуска.
         StepDivision - флаг, указывающий, использовать ли дробление шага или нет.
        */

        protected string _function;
        protected Point _initialPoint;
        protected double _learningRate;
        protected double _epsilon;
        protected int _maxIteration;
        protected bool _stepDivision;

        protected GradientDescent(string function, Point initialPoint, double learningRate, double epsilon, int maxIterations, bool stepDivision)
        {
            _function = function;
            _initialPoint = initialPoint;
            _learningRate = learningRate;
            _epsilon = epsilon;
            _maxIteration = maxIterations;
            _stepDivision = stepDivision;
        }

        public string Function
        {
            get => _function;
            set => SetProperty(ref _function, value);
        }

        public Point InitialPoint
        {
            get => _initialPoint;
            set => SetProperty(ref _initialPoint, value);
        }

        public double LearningRate
        {
            get => _learningRate;
            set => SetProperty(ref _learningRate, value);
        }

        public double Epsilon
        {
            get => _epsilon;
            set => SetProperty(ref _epsilon, value);
        }

        public int MaxIterations
        {
            get => _maxIteration;
            set => SetProperty(ref _maxIteration, value);
        }

        public bool StepDivision
        {
            get => _stepDivision;
            set => SetProperty(ref _stepDivision, value);
        }

        public abstract Point FindMinimum(Func<Point, double> function, Func<Point, Point> gradient);
    }
}