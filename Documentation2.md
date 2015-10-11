##Balloons Pop7 - Documentation##

1.  **Reformatted the source code:**

	+ ***Renaming:*** variables and metods renamed in order to make the code easier to understand (*Self-Documentating code*)
	int shirina -> int lenght 

	+ ***Character casing***: variables and fields made *camelCase*; types and methods made *PascalCase*
	private int gameRoundMoves;
	public void AddPlayer(IPlayer newPlayer)
	StyleCop rules are used

	+ ***Empty Lines:***
		+ Removed unnecessary empty lines
		  class StartBaloons
    {

        static void Main(string[] args)
        {
            Baloons.Start();
        }
    }
}

		+ Inserted empty lines between the methods

	+ ***Long expressions:***: split lines/expressions containing several statements into several simple lines/expressions

	IBalloonsEngine engine = new BalloonsGameEngine()
                .Renderer(renderer)
                .Input(inputHandler)
                .FieldFactory(fieldFactory)
                .FieldMemoryManager(fieldMemoryManager)
                .BalloonsFactory(balloonsFactory)
                .CommandManager(commandManager)
                .ReorderBalloonsStrategy(reorderStrategy)
                .GameFieldFiller(matrixFiller);

	+ ***Curly Braces:***
		+ Formatted the curly braces `{` and `}` according to the best practices for the C# language.

		  switch (difficulty)
            {
                case GameDifficulty.Easy:
                    {
                        IGameField field = new GameField(EasyGameFieldRows, EasyGameFieldColumns);
                        return field;
                    }

                case GameDifficulty.Hard:
                    {
                        IGameField field = new GameField(HardGameFieldRows, HardGameFieldColumns);
                        return field;
                    }

                default:
                    {
                        throw new InvalidOperationException(TypeErrorMessage);
                    }
            }

		+ Put `{` and `}` after all conditionals and loops (when missing).

		  for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    string randomSymbol = RandomProvider.GetRandomNumber(1, 5).ToString();

                    field[row, column] = this.balloonsFactory.GetBalloon(randomSymbol);
                }
            }

2. **Project Re-Structuration**: classes

	+ Cell:
		+ Balloon
		+ BalloonFour
		+ BalloonOne
		+ BalloonPoped
		+ BalloonsFactory
		+ BalloonThree
		+ BalloonTwo
		+ IBalloonsFactory
	+ Commands:
		+ CommandManager
		+ ExitCommand
		+ HelpCommand
		+ HelpCommand
		+ ICommandManager
		+ PopBalloonsCommand
		+ RestoreCommand
		+ SaveCommand
		+ TopScoresCommand
	+ Common:
		+ AnotherRound
		+ BalloonsColors
		+ EnumUtils
		+ GameConstants
		+ GameMessages
		+ GameMode
		+ GameType
		+ ObjectValidator
		+ Validator
	+ FieldFactory:
		+ Field
		  + Filler
		  + GameField
		  + IField
		  + IFiller
		  + IGameField
		  + IMemorable
		+ GameFieldFactory
		+ IFieldFactory
	+ GameEngine:
		+ BalloonsGameEngine
		+ GameEngineContex
		+ IBalloonsEngine
	+ GamePlayer:
		+ IPlayer
		+ Player
	+ GameScore:
		+ ScoreBoard
	+ Helpers:
		+ ConsoleHelper
	+ InputHandler:
		+ ConsoleInputHandler
		+ IInputHandler
	+ Memory:
		+ FieldMemory
		+ FieldMemoryManager
		+ IFieldMemoryManager
	+ ReorderStrategy:
		+ ReorderBallonsStrategyDefault
		+ ReorderBallonsStrategyFly
		+ ReorderBalloonsStrategy
	+ UI
	    + ConsoleRender
		+ IRender
	+ Facade
	+ RandomProvider
	+ StartBalloons

3. **Design Patterns:**

	+	Creational
		+	Singleton - ScoreBoard class
		+   Factory - FieldFactory

	+	Structural
		+	Facade - Facade.cs
		+   Flyweigh - ????
		+   Bridge - FieldFactory - Fill();

	+	Behavioral
		+	Memento - Memory
		+   Command - Command
		+   Strategy - ReoderStrategy

4. **Class Diagram** of the project (eventually)