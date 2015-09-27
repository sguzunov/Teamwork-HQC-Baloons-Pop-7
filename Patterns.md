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
	+	Strategy (when setting the gravity)