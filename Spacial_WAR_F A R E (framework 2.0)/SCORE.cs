using System;
using System.IO;

public sealed class SCORE
{

   public static int ScoreINT;

  public static void ScoreWritingScreen()
  {


    Console.SetCursorPosition(54, 0);
    Console.BackgroundColor = ConsoleColor.Black; //THIS IS HERE TO AVOID A BUG THAT CAN SET THE BACKGROUND OF SCORE TO WHITE

    Console.Write("     ");
    Console.Write(ScoreINT);
    Console.Write("     ");
    //THESE "CONSOLE.WRITE()" ARE ALSO HERE TO AVOID A BUG THAT CAN SET THE BACKGROUND OF SCORE TO WHITE

  }

  public static void ScoreToFile()
  {
    DateTime dt = DateTime.Now;
    string dateTODAY = dt.ToShortDateString();
   
    File.AppendAllText("HIGHSCORE.txt", $"SCORE: { Convert.ToString(ScoreINT) }                    DATE: {dateTODAY }                             ");

  }


}