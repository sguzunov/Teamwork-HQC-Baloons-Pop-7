##Patterns##

* **Creational**
	+ Singleton -already implemented into the ScoreBoard class
	 
	~~~c#
	public class ScoreBoard
    	{
        	private ScoreBoard()
        	{
        	    	this.listOfPlayers = new List<IPlayer>();
        	}

	        public static ScoreBoard Instance
        	{
            		get
            		{
                		if (instance == null)
                	{
                    	lock (syncLock)
                    	{
                        	if (instance == null)
                        	{
                            		instance = new ScoreBoard();
                        	}
                    	}
                }

                return instance;
        }
	~~~
	
	+ Factory -will be used in order to create the matrix 	 
	~~~c#
   
	~~~
	
* **Structural**
	+ Facade - into the engine ?

		
* **Behavioral**
	+ Memento ( in order to save)
	+ Command or Template Method (for the commands)
	+ Strategy 
	~~~c#
	
	// Strategy Abstract class
    	public abstract class ReorderBalloonsStrategy
    	{
        	public abstract void ReorderBalloons(string[,] gameField);
    	}

	// A 'ConcreteStrategy' class
    	public class ReorderBallonsStrategyGravityOn : ReorderBalloonsStrategy
    	{
        	public override void ReorderBalloons(string[,] gameField)
        	{
            		int row;
            		int col;

		        Queue<string> currentGameField = new Queue<string>();

         		for (col = 0; col < GameConstants.HEIGHT_OF_FIELD; col++)
            		{	
                		for (row = 0; row < GameConstants.WIDTH_OF_FIELD; row++)
                		{
                    			if (gameField[row, col] != ".")
                    			{
                        			currentGameField.Enqueue(gameField[row, col]);
                        			gameField[row, col] = ".";
                    			}
                		}

                		row = 0;
                		while (currentGameField.Count > 0)
                		{
                    			gameField[row, col] = currentGameField.Dequeue();
                    			row++;
                		}

                	currentGameField.Clear();
            		}
        	}   		
	}

	// Another 'ConcreteStrategy' class
    	public class ReorderBallonsStrategyGravityOn : ReorderBalloonsStrategy
    	{
        	public override void ReorderBalloons(string[,] gameField)
        	{
        		int row;
            		int col;

			Queue<string> currentGameField = new Queue<string>();

            		for (col = GameConstants.HEIGHT_OF_FIELD - 1; col >= 0; col--)
            		{	
                		 for (row = GameConstants.WIDTH_OF_FIELD - 1; row >= 0; row--)
                		{
                    			if (gameField[row, col] != ".")
                    			{
                        			currentGameField.Enqueue(gameField[row, col]);
                       				gameField[row, col] = ".";
                    			}
                		}

                		row = GameConstants.WIDTH_OF_FIELD - 1;
                		while (currentGameField.Count > 0)
                		{
                    			gameField[row, col] = currentGameField.Dequeue();
                    			row--;
                		}

                	currentGameField.Clear();
            		}
        	}
    	}
	~~~