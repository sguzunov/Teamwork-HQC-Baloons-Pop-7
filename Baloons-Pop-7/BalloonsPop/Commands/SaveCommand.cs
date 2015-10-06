namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;

    public class SaveCommand : ICommand
    {
        private readonly IGameField field;

        public SaveCommand(IGameField field)
        {
            this.field = field;
            this.Name = "save";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            // TODO: Implement memento
        }
    }
}
