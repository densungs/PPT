using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class MoveCommand : ICommand
    {
        Shape _origin;
        Shape _result;
        Shape _execute;
        Model _model;
        private Point _originStartPoint;
        private Point _originEndPoint;
        private int _originLayers;
        private Point _resultStartPoint;
        private Point _resultEndPoint;
        private int _resultLayers;

        public MoveCommand(Model model, Shape origin, Shape result)
        {
            _origin = origin.GetType();
            _originStartPoint = origin.GetStartPoint();
            _originEndPoint = origin.GetEndPoint();
            _originLayers = origin.GetLayers();
            _result = result.GetType();
            _resultStartPoint = result.GetStartPoint();
            _resultEndPoint = result.GetEndPoint();
            _resultLayers = result.GetLayers();
            _model = model;
        }

        //執行
        public void Execute()
        {
            _execute = _result.GetType();
            _execute.SetPosition(_resultStartPoint, _resultEndPoint);
            _execute.SetLayers(_resultLayers);
            _model.SelectNoGraph();
            _execute.SetIsSelect(true);
            _model.ExecuteMove(_execute);
        }

        //不執行
        public void ReverseExecution()
        {
            _execute = _origin.GetType();
            _execute.SetPosition(_originStartPoint, _originEndPoint);
            _execute.SetLayers(_originLayers);
            _model.SelectNoGraph();
            _execute.SetIsSelect(true);
            _model.ReverseExecutionMove(_execute);
        }
    }
}
