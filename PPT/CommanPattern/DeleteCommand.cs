using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DeleteCommand : ICommand
    {
        Shape _save;
        Shape _execute;
        Model _model;
        private Point _startPoint;
        private Point _endPoint;
        private int _layers;

        public DeleteCommand(Model model, Shape target)
        {
            _save = target.GetType();
            _startPoint = target.GetStartPoint();
            _endPoint = target.GetEndPoint();
            _layers = target.GetLayers();
            _model = model;
        }

        //執行
        public void Execute()
        {
            _execute = _save.GetType();
            _execute.SetPosition(_startPoint, _endPoint);
            _execute.SetLayers(_layers);
            _model.ExecuteDelete(_execute.GetLayers());
        }

        //不執行
        public void ReverseExecution()
        {
            _execute = _save.GetType();
            _execute.SetPosition(_startPoint, _endPoint);
            _execute.SetLayers(_layers);
            _model.SelectNoGraph();
            _execute.SetIsSelect(true);
            _model.ReverseExecutionDelete(_execute);
        }
    }
}
