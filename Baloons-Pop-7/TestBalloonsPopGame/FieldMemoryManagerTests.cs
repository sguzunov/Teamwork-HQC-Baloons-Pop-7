namespace TestBalloonsPopGame.MemoryTests
{
    using System;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Balloons.FieldFactory.Field;
    using Balloons.Cell;
    using Balloons.Memory;

    [TestClass]
    public class FieldMemoryManagerTests
    {
        [TestMethod]
        public void FieldMemoryGetMementoShouldWorkProperly()
        {
            var matrix = new Balloon[2, 2];
            var filler = new Filler(new BalloonsFactory());
            filler.Fill(matrix);

            var fMemory = new FieldMemory(matrix);
            var savedField = fMemory.GetMemento();
            //not sure if it is ok
            Assert.AreEqual(matrix, savedField);
        }

        [TestMethod]
        public void FieldMemoryManagersaveShouldWorkProperly()
        {
            var matrix = new Balloon[2, 2];
            var filler = new Filler(new BalloonsFactory());
            filler.Fill(matrix);

            var fMemory = new FieldMemory(matrix);
            var savedField = fMemory.GetMemento();

            var ff = new GameFieldFactory();
            var field = ff.CreateGameField(GameDifficulty.Easy);

            var fMemoryManager = new FieldMemoryManager();
            fMemoryManager.Save(field);

            Assert.AreEqual(field, fMemoryManager);
        }
    }
}
