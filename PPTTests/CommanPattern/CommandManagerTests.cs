using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        private CommandManager _commandManager;
        private Model _model;
        PrivateObject _commandManagerPrivateObject;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _commandManager = new CommandManager();
            _commandManagerPrivateObject = new PrivateObject(_commandManager);
            _model = new Model();
        }

        //執行
        [TestMethod()]
        public void ExecuteTest()
        {
            ICommand command1 = new MockCommand();
            ICommand command2 = new MockCommand();
            ICommand command3 = new MockCommand();
            ICommand command4 = new MockCommand();
            Assert.IsFalse(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
            _commandManager.Execute(command1);
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 1);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 0);
            _commandManager.Execute(command2);
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 2);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 0);
            _commandManager.Execute(command3);
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 3);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 0);
            _commandManager.Execute(command4);
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 4);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 0);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
        }

        //上一步
        [TestMethod()]
        public void UndoTest()
        {
            ICommand command1 = new MockCommand();
            ICommand command2 = new MockCommand();
            ICommand command3 = new MockCommand();
            ICommand command4 = new MockCommand();
            _commandManager.Execute(command1);
            _commandManager.Execute(command2);
            _commandManager.Execute(command3);
            _commandManager.Execute(command4);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 3);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 1);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 2);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 2);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 1);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 3);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 0);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 4);
            Assert.IsFalse(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
        }

        //還原上一步
        [TestMethod()]
        public void RedoTest()
        {
            ICommand command1 = new MockCommand();
            ICommand command2 = new MockCommand();
            ICommand command3 = new MockCommand();
            ICommand command4 = new MockCommand();
            _commandManager.Execute(command1);
            _commandManager.Execute(command2);
            _commandManager.Execute(command3);
            _commandManager.Execute(command4);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 3);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 1);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 2);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 2);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 1);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 3);
            _commandManager.Undo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 0);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 4);
            Assert.IsFalse(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
            _commandManager.Redo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 1);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 3);
            _commandManager.Redo();
            Assert.AreEqual(_commandManager.GetUndoStack().Count, 2);
            Assert.AreEqual(_commandManager.GetRedoStack().Count, 2);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
        }
    }
}