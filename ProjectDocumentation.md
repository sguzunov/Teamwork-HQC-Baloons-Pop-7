
High-Quality Programming Code – Team Projects
=============================================
This is the documentation of project "Balloons-Pop-7"


1. All code is copied to folder "After", code is briefly formatted in order to be more readable. 

  private static bool IsLegalMove(int i, int j)
         {
             if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1)) return false;
             else return (_t[i, j] != ".");
	}

 private static bool IsLegalMove(int i, int j)
         {
            if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1))
                return false;
            else
                return (_t[i, j] != ".");
         }

2. Variables and methods are named better, the goal is self - documented code.

 const int shirina = 5;
 const int length = 10;

 const int WIDTH = 5;
 const int HEIGHT = 10;

 3. Repository structure is changer in order to organize the code into classes

namespace BalloonsPops
{
    using System;
    using System.Linq;
    public static class RamdomGenerator
    {
        static Random rnd = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string result = null;
            result = legalChars[rnd.Next(0, legalChars.Length)].ToString();
            return result;
        }
    }
}

 4. InputHandler class is extracted in order to reduce cohesion and coupling
 
 5. Namespaces are also renamed with suitable names 
 
 namespace Baloons -> namespace Balloons.Commands
 
 6. GameField class is refactored by adding a new one Field. 

 7. Some bugs are fixed (example: public void RenderGameField,  IsFinished())

 8. ScoreLogic is added in order to extend the functionality of the game 

 9. Constants are named better and removed in separate class

  {
     public static class GameConstants
     {
         public  const int WIDTH_OF_FIELD = 5;
         public const int HEIGHT_OF_FIELD = 10;
         public const int FIRST_STATISTIC_POSITION = 1;
         public const int LAST_STATISTIC_POSITION = 5;
     }
 }

 10. Encapsulate some fields 

  internal static SortedDictionary -> private static SortedDictionary

 11.Some commands are extracted in folder "Commands" -> RemovePopBallons();

 12. Abstraction for GameEngine is added.

 13. Some design patterns are implemented

     Singleton -> class ScoreBoard 
	 Facade -> in the engine 
	 Memento -> in the logic of saving scores 

 14. ConsoleInputHandler class is implemented 

 15. Factory for GameField is implemented 

 16. Class Validators is added in order to validate public methods 

 17. Some missed variables are named better 

      Queue<string> temp = new Queue<string>(); -> Queue<string> currentBaloon = new Queue<string>();

 18. Added strategy methods in order to reorder balloons

 19. Method for changing the color of the balloons is added

 20. Some random refactoring of the code for better understanding 
    
	             //Up
                Clear(i - 1, j, activeCell);
                //Down
                Clear(i + 1, j, activeCell);
                //Left
                Clear(i, j + 1, activeCell);
                //Right
               Clear(i, j - 1, activeCell);


                Clear(row - 1, col, activeCell); // Up
                Clear(row + 1, col, activeCell); // Down
                Clear(row, col + 1, activeCell); // Left
                Clear(row, col - 1, activeCell); // Right


21. All rendering methods are implemented at some basic level.

22. Console sound is added 

23. Code is refactored according to StyleCop rules

24. Removing new refactored code in new folder "src" / better explanation ? :/

25. Command pattern is added in order to achieve easier architecture of the commands of the game

26. Game mode and game difficulty are added to achieve more functionality 

27. Flyweight pattern is used / where ?

28. Added new abstract logic for commands and their taking - interface pattern for CommandManager

29. Bridge design is used in method Fill(); (in case of future development of the game)

30. Implemented TopScoresCommand, ExitCommand, HelpCommand, Pop

31. InputHandler and command Manager are refactored

32. Code is refactored again according to StyleCop rules, some unnecessary classes/code are removed

33. Play again option is added

34. Save and Restore commands, fluent interface are implemented

