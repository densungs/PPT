using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface ICommand
    {
        //執行
        void Execute();

        //不執行
        void ReverseExecution();
    }
}
