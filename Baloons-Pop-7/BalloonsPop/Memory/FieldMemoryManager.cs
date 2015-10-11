namespace Balloons.Memory
{
    using System;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class FieldMemoryManager : IFieldMemoryManager
    {
        private const string GameFieldNullErrorMessage = "Game field cannot be null! ";

        private FieldMemory Memory { get; set; }

        public void Save(IMemorable gameField)
        {
            if (ObjectValidator.IsGameObjectNull(gameField))
            {
                throw new ArgumentNullException(GameFieldNullErrorMessage);
            }

            this.Memory = gameField.SaveField();
        }

        public void Undo(IMemorable gameField)
        {
            if (ObjectValidator.IsGameObjectNull(gameField))
            {
                throw new ArgumentNullException(GameFieldNullErrorMessage);
            }

            gameField.RestoreField(this.Memory);
        }
    }
}
