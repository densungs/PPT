using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    class MockCommand : ICommand
    {
        public bool _isExecuteCalled = false;
        public bool _isReverseExecutionCalled = false;

        //執行
        public void Execute()
        {
            _isExecuteCalled = true;
        }

        //不執行
        public void ReverseExecution()
        {
            _isReverseExecutionCalled = true;
        }
    }
}
