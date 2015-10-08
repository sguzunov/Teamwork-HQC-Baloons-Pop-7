namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;

    public class RestoreCommand : ICommand
    {
        private readonly IGameField field;
        private readonly IFieldMemoryManager fieldMemorizerManager;

        public RestoreCommand(IFieldMemoryManager fieldMemorizerManager, IGameField field)
        {
            this.field = field;
            this.fieldMemorizerManager = fieldMemorizerManager;
            this.Name = "restore";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            this.fieldMemorizerManager.Undo(this.field);
        }
    }
}
