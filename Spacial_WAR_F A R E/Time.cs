using System;
using System.Reflection.PortableExecutable;
using System.Timers;

sealed class Time
{

 public static Timer timer = new Timer(5500);

  public static void Timer()
  {

     timer.Start();

   if (Program.timerElapse == true)
   {

     timer.Elapsed += (Object? source, ElapsedEventArgs e) => 
     {

     Program.gameOverBOOL = true; 
     System.Threading.Thread.Sleep(200);  //THIS IS HERE TO ENSURE THAT EVERYTHING WILL "ABORT/END" PROPERLY"

     timer.Stop(); 



     Console.Clear();
     System.Threading.Thread.Sleep(150);
     Console.Write(GameOverString.GameOver);
     System.Threading.Thread.Sleep(150);



     Console.Clear();
     System.Threading.Thread.Sleep(150);
     Console.Write(GameOverString.GameOver);
     System.Threading.Thread.Sleep(150);



     Console.Clear();
     System.Threading.Thread.Sleep(150);
     Console.Write(GameOverString.GameOver);
     System.Threading.Thread.Sleep(150);



     Console.Clear();
     System.Threading.Thread.Sleep(150);
     Console.Write(GameOverString.GameOver);
     System.Threading.Thread.Sleep(150);



     Console.Clear();
     System.Threading.Thread.Sleep(430);
     Console.SetCursorPosition(34, 13);
     Console.Write(@"D O  Y O U  W A N T  T O  P L A Y  A G A I N ?   Y \ N");

     };

   }

  }

}