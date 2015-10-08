namespace Balloons.Memory
{
    using System;

    using Balloons.FieldFactory.Field;

    public class FieldMemoryManager : IFieldMemoryManager
    {
        private FieldMemory Memory { get; set; }

        public void Save(IMemorable gameField)
        {
            this.Memory = gameField.SaveField();
        }

        public void Undo(IMemorable gameField)
        {
            gameField.RestoreField(this.Memory);
        }
    }
}
