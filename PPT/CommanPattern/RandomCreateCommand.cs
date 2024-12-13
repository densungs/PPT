using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class RandomCreateCommand : ICommand
    {
        Shape _save;
        Shape _execute;
        Model _model;
        private Point _startPoint;
        private Point _endPoint;

        public RandomCreateCommand(Model model, Shape target)
        {
            _save = target.GetType();
            _startPoint = target.GetStartPoint();
            _endPoint = target.GetEndPoint();
            _model = model;
        }

        //執行
        public void Execute()
        {
            _execute = _save.GetType();
            _execute.SetPosition(_startPoint, _endPoint);
            _model.SelectNoGraph();
            _execute.SetIsSelect(true);
            _model.CreateShapeByRandomCreate(_execute);
        }

        //不執行
        public void ReverseExecution()
        {
            _model.DeleteShapeByRandomCreate();
        }
    }
}
