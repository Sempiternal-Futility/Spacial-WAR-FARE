using System;
using System.Threading;
using System.Runtime.InteropServices;

//ADD LINUX VERSION
//BUG TEST

/*
NOTES FOR DEVS/MODDERS :)

THE BUG 1 AND 2 THAT I MENTION ON MY COMMENTS, ARE REFERENCE TO THE README FILE, ON THE "KNOWN BUGS" SECTION
FOR SOME REASON THAT I DON'T UNDERSTAND, THERE'S AN EXCEPTION THROWN (ArgumentOutOfRangeException) WHEN THE PLAYER MOVES TO THE LEFT CORNER OF THE SCREEN, OF COURSE I HANDLED IT, BUT IN A VERY UGLY WAY ( see more on PLAYERMOVEMENT() )
if you see any weird things happen to your character / to your ship when you move to the left corner, now you know why
FOR SOME REASON, I NEED DIFFERENT VALUES x VALUES WHEN MOVING TO THE LEFT OR RIGHT, THAT'S THE PURPOSE OF THE "leftDIRpressed" and rightDIRpressed" BOOLS ( you can see more on SHOOT()   and on PLAYERMOVEMENT() )
*/
sealed class Program
{

  static int x = 56;
  static int y = 25;


  static int enemyPOS;
  static (int Left, int Top) curPOS;


  static bool leftDIRpressed;
  static bool rightDIRpressed;
  //THESE TWO BOOLS EXIST BECAUSE IF YOU SHOOT WHILE MOVING TO THE LEFT, THE SHOT WILL BE MISALIGNED, SO THIS FIXES IT ( see how i use them on SHOOT() )


  static bool enemyKILLED = true;

  public static bool gameOverBOOL = false;


  static bool loopSWITCHstatement = false;
  //THIS BOOL IS HERE TO LOOP THE SWITCH STATEMENT
  //the switch needs to be looped because if the player game over, and presses 'd' or 'a', etc. even once, the statement ends, but, since i got this bool, the only way the switch ends is either pressing 'n' or 'y', no other way



  public static bool timerElapse = true;
  //THIS BOOL IS HERE BECAUSE SINCE I RUN THE "MAIN()" AGAIN AFTER GAME OVER, IT WOULD KEEP CREATING MULTIPLE "timer.Elapsed" ON "Time.cs", SO THE GAME OVER WOULD GET TRIGGERED MULTIPLE TIMES, AND THE SCORE WOULD BE WRITTEN TO THE FILE MULTIPLE TIMES
  //SEE HOW I USED IT ON "Time.cs"


  static void Main()
  {

     Console.Title = "Spacial_WAR_F A R E";
     Console.CursorVisible = false;
     Console.Clear(); //THIS IS HERE IF AN USER WANTS TO RUN THE GAME STRAIGHT THROUGH CMD, BASH, ETC.
     Console.ForegroundColor = ConsoleColor.White;


     Console.SetCursorPosition(38, 13);
     Console.WriteLine("P R E S S  A N Y  K E Y  T O  S T A R T");
     Console.ReadKey();
     Console.Clear();


     new Thread(spawnENEMY).Start();
     Thread.Sleep(150); //THIS IS HERE TO ENSURE THAT THE ENEMY WILL SPAWN BEFORE THE PLAYER, AVOIDING BUGS
     new Thread(PLAYERMOVEMENT).Start();
     Time.Timer();



     CheckForKill();


     loopSWITCHstatement = false;
     timerElapse = false;
     Thread.Sleep(2100); //THIS IS HERE TO MATCH THE GAME OVERS FLASHING ON "Time.cs"
     

  do
  {

     switch(Console.ReadKey(true).KeyChar)
     {
       case 'y' : SCORE.ScoreToFile(); gameOverBOOL = false; SCORE.ScoreINT = 0; enemyKILLED = true; loopSWITCHstatement = false; Main();   //RESTARTS THE GAME
       break;

       case 'n' : SCORE.ScoreToFile(); loopSWITCHstatement = false;
       break;

       default : loopSWITCHstatement = true;
       break;
     }

  } while (loopSWITCHstatement == true);

}













static void Draw(int x, int y, ConsoleColor color, string stringToWrite)
  {

  try {

    Console.SetCursorPosition(x, y);
    Console.BackgroundColor = color;
    Console.Write(stringToWrite);

      } catch(ArgumentOutOfRangeException) {x = 1;} //THIS IS HERE TO FIX A BUG THAT IF THE PLAYER MOVES TO THE FAR LEFT SIDE OF THE SCREEN, (for some unknown reason) AN EXCEPTION IS CAUSED
  }













  static void CheckForKill()
  {

while (gameOverBOOL == false)
{ 

     curPOS = Console.GetCursorPosition();

     if (curPOS == (enemyPOS, 2) || curPOS == (enemyPOS + 1, 2) || curPOS == (enemyPOS + 2, 2) || curPOS == (enemyPOS + 3, 2))
     {

     Time.timer.Stop(); Time.timer.Start(); //RESETS THE TIMER
     enemyKILLED = true; 
     
     }
     
     Thread.Sleep(new TimeSpan(10000));

}

  }













static void PLAYERMOVEMENT()
  {


while(gameOverBOOL == false)
 {

  if (enemyKILLED == true) {Thread.Sleep(50);}


    switch(Console.ReadKey(true).Key)
    {

      case ConsoleKey.LeftArrow : 
      Draw(x--, y, ConsoleColor.White, "       "); 
      Draw(x + 3, y - 1, ConsoleColor.White, "  "); //DRAWS THE "CANNON" OF YOUR SHIP         
      
      Draw(x + 7, y, ConsoleColor.Black, "      "); 
      Draw(x + 5, y - 1, ConsoleColor.Black, "   ");           
      
      try { Console.SetCursorPosition(x, y); }
      catch (ArgumentOutOfRangeException) { Draw(x + 1, y, ConsoleColor.Black, "       "); Draw(x + 1, y - 1, ConsoleColor.Black, "    ");   x = 111; } //IF THE PLAYER MOVES TOO MUCH TO THE LEFT, THE GAME DOESN'T CRASH, INSTEAD, IT "TELEPORTS" TO THE OTHER SIDE OF THE SCREEN
      
      leftDIRpressed = true; rightDIRpressed = false;
      break;






      case ConsoleKey.RightArrow : 
      Draw(x++, y, ConsoleColor.White, "       "); 
      Draw(x + 2, y - 1, ConsoleColor.White, "  "); //DRAWS THE "CANNON" OF YOUR SHIP

      Draw(x - 6, y, ConsoleColor.Black, "      "); 
      Draw(x - 1, y - 1, ConsoleColor.Black, "   ");           
      
      try { Console.SetCursorPosition(x + 6, y); }
      catch (ArgumentOutOfRangeException) {Draw(x - 6, y, ConsoleColor.Black, "       "); Draw(x, y + 1, ConsoleColor.Black, "    ");   x = 111;} //IF THE PLAYER MOVES TO THE FAR LEFT SIDE OF THE SCREEN, THE GAME DOESN'T CRASH
      
      rightDIRpressed = true; leftDIRpressed = false;
      
      if (x == 111) { Draw(x - 1, y, ConsoleColor.Black, "       "); Draw(x, y - 1, ConsoleColor.Black, "    ");   x = 1; } //THIS IS HERE SO THE PLAYER CAN "TELEPORT" TO THE OTHER SIDE, I USED A DIFFERENT TECHNIQUE HERE BECAUSE NO EXCEPTION IS THROWN WHEN THE PLAYER MOVES TO THE RIGHT CORNER
      break;






      case ConsoleKey.A :
      Draw(x--, y, ConsoleColor.White, "       "); 
      Draw(x + 3, y - 1, ConsoleColor.White, "  "); //DRAWS THE "CANNON" OF YOUR SHIP         
      
      Draw(x + 7, y, ConsoleColor.Black, "      "); 
      Draw(x + 5, y - 1, ConsoleColor.Black, "   ");           
      
      try { Console.SetCursorPosition(x, y); }
      catch (ArgumentOutOfRangeException) { Draw(x + 1, y, ConsoleColor.Black, "       "); Draw(x + 1, y - 1, ConsoleColor.Black, "    ");   x = 111; } //IF THE PLAYER MOVES TOO MUCH TO THE LEFT, THE GAME DOESN'T CRASH, INSTEAD, IT "TELEPORTS" TO THE OTHER SIDE OF THE SCREEN
      
      leftDIRpressed = true; rightDIRpressed = false;
      break;






      case ConsoleKey.D :
      Draw(x++, y, ConsoleColor.White, "       "); 
      Draw(x + 2, y - 1, ConsoleColor.White, "  "); //DRAWS THE "CANNON" OF YOUR SHIP

      Draw(x - 6, y, ConsoleColor.Black, "      "); 
      Draw(x - 1, y - 1, ConsoleColor.Black, "   ");           
      
      try { Console.SetCursorPosition(x + 6, y); }
      catch (ArgumentOutOfRangeException) {Draw(x - 6, y, ConsoleColor.Black, "       "); Draw(x, y + 1, ConsoleColor.Black, "    ");   x = 111;} //IF THE PLAYER MOVES TO THE FAR LEFT SIDE OF THE SCREEN, THE GAME DOESN'T CRASH
      
      rightDIRpressed = true; leftDIRpressed = false;
      
      if (x == 111) {Draw(x - 1, y, ConsoleColor.Black, "       "); Draw(x, y - 1, ConsoleColor.Black, "    ");   x = 1;} //THIS IS HERE SO THE PLAYER CAN "TELEPORT" TO THE OTHER SIDE, I USED A DIFFERENT TECHNIQUE HERE BECAUSE NO EXCEPTION IS THROWN WHEN THE PLAYER MOVES TO THE RIGHT CORNER
      break;






      case ConsoleKey.Spacebar : SHOOT();
      break;

      case ConsoleKey.S : SHOOT();
      break;
    }
 }
}













  static void SHOOT()
  {

for (int fall = 24; fall > 1; fall--)
{

   if (gameOverBOOL == false)
   {


      if (rightDIRpressed == true)
      { 

      Draw(x + 2, fall, ConsoleColor.White, "  ");
      Thread.Sleep(51);
      Draw(x + 2, fall, ConsoleColor.Black, "  ");

      }


      if (leftDIRpressed == true)
      {

      Draw(x + 3, fall, ConsoleColor.White, "  ");
      Thread.Sleep(51);
      Draw(x + 3, fall, ConsoleColor.Black, "  ");

      } //FOR SOME REASON THE LEFT AND RIGHT SIDE NEED DIFFERENT VALUES TO SHOOT PROPERLY

   }

 }
 
}













  static void spawnENEMY()
  {

while(gameOverBOOL == false)
{ 

  Thread.Sleep(158); //THIS IS HERE TO INCREASE THE PERFORMANCE OF THE GAME

   while(enemyKILLED == true)
   {

     Draw(enemyPOS -2, 2, ConsoleColor.Black, "        ");  //USED TO "ERASE" THE ENEMY


     Random randoM = new Random();
     enemyPOS = randoM.Next(5, 111);

     Draw(enemyPOS - 1, 2, ConsoleColor.White, "   ");
     SCORE.ScoreINT++;
     SCORE.ScoreToScreen();
     
     enemyKILLED = false;

   }

}


  }
}
