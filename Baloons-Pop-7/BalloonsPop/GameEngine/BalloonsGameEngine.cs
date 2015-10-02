namespace Balloons.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.GameField;

    public class BalloonsGameEngine : IBalloonsEngine
    {
        private IRenderer renderer;
        private IInputHandler inputHandler;
        private IGameField field;

        public BalloonsGameEngine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
        }

        public void InitializeGame()
        {
            // TODO : When have restart command ask pool.
            // TODO : Read game mode.
            // TODO : Read game difficulty.

            this.renderer.RenderMenu();
            var mode = this.inputHandler.ReadGameMode();
            var diff = this.inputHandler.ReadGameDifficulty();
            Console.WriteLine(mode);
            Console.WriteLine(diff);
        }

        public void StartGame()
        {

        }

        public void IsGameFinished()
        {
            throw new NotImplementedException();
        }
    }
}
