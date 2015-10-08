namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;

    public class SaveCommand : ICommand
    {
        private readonly IGameField field;
        private readonly IFieldMemoryManager fieldMemoryManager;

        public SaveCommand(IFieldMemoryManager fieldMemoryManager, IGameField field)
        {
            this.field = field;
            this.fieldMemoryManager = fieldMemoryManager;
            this.Name = "save";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            this.fieldMemoryManager.Save(this.field);
        }
    }
}
