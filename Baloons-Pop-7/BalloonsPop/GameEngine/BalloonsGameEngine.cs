namespace Balloons.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Balloons.UI;
    using Balloons.InputHandler;
    using Balloons.FieldFactory;
    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class BalloonsGameEngine : IBalloonsEngine
    {
        private IRenderer renderer;
        private IInputHandler inputHandler;
        private IFieldFactory fieldFactory;
        private IGameField field;
        private GameMode gameMode;
        private GameDifficulty gameDifficulty;

        public BalloonsGameEngine(IRenderer renderer, IInputHandler inputHandler, IFieldFactory fieldFactory)
        {
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.fieldFactory = fieldFactory;
        }

        public void InitializeGame()
        {
            // TODO : When have restart command ask pool.

            this.renderer.RenderMenu();

            this.gameMode = this.inputHandler.GetGameMode();
            this.gameDifficulty = this.inputHandler.GetGameDifficulty();

            this.field = this.fieldFactory.CreateGameField(this.gameDifficulty);
            this.field.Fill();

            this.renderer.RenderGameField(this.field);
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
