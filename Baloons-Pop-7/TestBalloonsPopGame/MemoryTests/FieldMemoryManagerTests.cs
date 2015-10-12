namespace TestBalloonsPopGame.MemoryTests
{
    using System;

    using Balloons.FieldFactory.Field;
    using Balloons.Memory;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Balloons.Cell;
    using Moq;

    [TestClass]
    public class FieldMemoryManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassedNullGameFieldToSaveMethodShouldThrowExceptio()
        {
            var manager = new FieldMemoryManager();
            manager.Save(null);
        }

        [TestMethod]
        public void ManagerSaveMethodShouldCallGameFieldSaveFieldMethod()
        {
            var matrix = new Balloon[2, 2];
            var mockField = new Mock<IGameField>();
            mockField.Setup(f => f.SaveField()).Returns(new FieldMemory(matrix));

            var manager = new FieldMemoryManager();

            var field = mockField.Object;
            manager.Save(field);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassedNullGameFieldToUndoMethodShouldThrowExceptio()
        {
            var manager = new FieldMemoryManager();
            manager.Undo(null);
        }

        [TestMethod]
        public void ManagerUndoMethodShouldCallGameFieldRestoreFieldMethod()
        {
            var mockField = new Mock<IGameField>();
            var manager = new FieldMemoryManager();
            var field = mockField.Object;

            manager.Undo(field);
            mockField.Verify(f => f.RestoreField(It.IsAny<FieldMemory>()), Times.AtLeastOnce());
        }
    }
}
