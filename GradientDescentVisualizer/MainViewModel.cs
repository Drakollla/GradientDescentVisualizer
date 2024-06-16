using GradientDescentVisualizer.Model;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace GradientDescentVisualizer
{
    public class MainViewModel : ObservableObject
    {

        //Just tempriary simple

        private PlotModel _plotModel;

        public MainViewModel()
        {
            //_plotModel = new PlotModel { Title = "Comparison of Gradient Descent Methods" };
            //_plotModel.Series.Add(new LineSeries { Title = "Method 1", StrokeThickness = 2 });
            //_plotModel.Series.Add(new LineSeries { Title = "Method 2", StrokeThickness = 2 });

            //double[] x = new double[] { 1, 2, 3, 4, 5 };
            //double[] y = new double[] { 2, 4, 6, 8, 10 };

            //UpdateData(x, y);



            var model = new PlotModel { Title = "Function Series" };

            //var functionSeries = new FunctionSeries(
            //    (x, y) => x * x + y * y,
            //    -10, 10, 0.1,
            //    -10, 10, 0.1);

            //var functionSeries = new FunctionSeries(
            //     (x) => x * x,
            //    -10, 10, 0.1);

            //model.Series.Add(functionSeries);


            //1)

            double[,] data = new double[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    data[i, j] = (i - 10) * (i - 10) + (j - 10) * (j - 10);
                }
            }

            var contourSeries = new ContourSeries
            {
                ColumnCoordinates = Enumerable.Range(-10, 20).Select(x => (double)x).ToArray(),
                RowCoordinates = Enumerable.Range(-10, 20).Select(y => (double)y).ToArray(),
                Data = data
            };



            model.Series.Add(contourSeries);


            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "X" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Y" });

            // Show the plot
            _plotModel = model;
        }


        public PlotModel PlotModel
        {
            get => _plotModel;
            set => SetProperty(ref _plotModel, value);
        }

        public void UpdateData(double[] x, double[] y)
        {
            var lineSeries = _plotModel.Series.FirstOrDefault(s => s is LineSeries) as LineSeries;

            if (lineSeries != null)
            {
                for (int i = 0; i < x.Length; i++)
                    lineSeries.Points.Add(new DataPoint(x[i], y[i]));
            }
        }
    }
}