namespace Balloons.Memory
{
    using System;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    /// <summary>
    /// This class manages field saving and restoring.
    /// </summary>
    public class FieldMemoryManager : IFieldMemoryManager
    {
        private const string GameFieldNullErrorMessage = "Game field cannot be null! ";

        private FieldMemory Memory { get; set; }

        /// <summary>
        /// Method which manages saving field.
        /// </summary>
        /// <param name="gameField">The field to be saved.</param>
        public void Save(IMemorable gameField)
        {
            if (ObjectValidator.IsGameObjectNull(gameField))
            {
                throw new ArgumentNullException(GameFieldNullErrorMessage);
            }

            this.Memory = gameField.SaveField();
        }

        /// <summary>
        /// Method which manages restoring field.
        /// </summary>
        /// <param name="gameField">The field to be restored.</param>
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
