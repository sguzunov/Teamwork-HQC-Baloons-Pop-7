namespace Balloons.Commands
{
    using Balloons.FieldFactory.Field;
    using Balloons.Commands;

    public class RestoreCommand : ICommand
    {
        private readonly IGameField field;

        public RestoreCommand(IGameField field)
        {
            this.field = field;
            this.Name = "restore";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            // TODO : Get saved matrix from memento.
        }
    }
}
