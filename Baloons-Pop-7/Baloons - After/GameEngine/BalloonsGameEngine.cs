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
            // TODO : When have restart command ask pool

            this.field = new GameField(5, 10);
            this.field.Fill();
            this.renderer.RenderGameField(this.field);
        }

        public void StartGame()
        {
            // TODO: 
        }

        public void IsGameFinished()
        {
            throw new NotImplementedException();
        }
    }
}
