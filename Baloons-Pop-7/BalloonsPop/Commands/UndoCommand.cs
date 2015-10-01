namespace BalloonsPop.Commands
{
    using Balloons.Logic;

    public class UndoCommand : ICommand
    {
        internal static void Save(string[,] gameField, MemoryManager gameMemory, int moves, int filledCells)
        {
            string[,] cloneGameField = (string[,])gameField.Clone();

            gameMemory.Memory = new Memory(cloneGameField, moves, filledCells);
            gameMemory.SaveMemory();
        }

        internal static Memory Load(MemoryManager gameMemory)
        {
            var memory = gameMemory.RestoreMemory();
            return memory;
        }
        internal static void ClearMemory(MemoryManager gameMemory)
        {
            gameMemory.Clear();
        }

        public string Name
        {
            get { return "undo"; }
        }

        public void Execute()
        {
            System.Console.WriteLine("Implement the execute method"); ;
        }
    }
}
