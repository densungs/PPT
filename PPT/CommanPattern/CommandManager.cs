using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        //執行
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        //上一步
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(Constant.ERROR_MESSAGE_CAN_NOT_UNDO);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.ReverseExecution();
        }

        //還原上一步
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(Constant.ERROR_MESSAGE_CAN_NOT_REDO);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        //unittest用檢查undo stack
        public Stack<ICommand> GetUndoStack()
        {
            return _undo;
        }

        //unittest用檢查undo stack
        public Stack<ICommand> GetRedoStack()
        {
            return _redo;
        }
    }
}
