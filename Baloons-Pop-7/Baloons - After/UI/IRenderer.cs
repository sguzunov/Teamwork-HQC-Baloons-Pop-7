﻿namespace Balloons.UI
{
    using Balloons.GameField;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);

        void RenderStartMenu();

        void RenderGameScoreBoard();
    }
}