##Project Structure##

* **UI:**
	+ Start Menu class
		+ welcome message
		+ commands (top/exit/restart/help/save/restore)
		+ Difficulty (easy/hard)
		+ Mood / Gravity (on/off)
	+ Field Drawer (console renderer) class
		+ Draw balloons - different color per different number ( for exaple instead of 3 we will draw a red balloon)
	+ End Menu class
		+ Goodbye message + ask for name
	

* **Field**
	+ A factory pattern will be used in order to create different fields depending on the input (easy/hard)	

* **GameRules**
	+  Pop Balloons 
	+ Remove Balloons
		+ Strategy pattern - the balloons will be removed depending on the gravity 
		
* **Scoreboard**
	+	ScoreBoard class ( singleton pattern already implemented)
	+	Player class

* **Input handler**
	 +	Input handler class 
		+	read the input
		+	validate the input

* **Commands**
	+	Abstract class command with method execute
		+	Command pattern
		+	different classes for the different commands
			+	undo/save command - Memento pattern

* **Validator**
	+ A class containing the validations

* **Sounds**

* **Engine**
	+ Initialize (facade pattern)
	+ Play 
	+ end the game (IsFinished method)