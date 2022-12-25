//I JUST WANNA SAY THAT I DON'T UNDERSTAND SHIT ABOUT THIS
//ALL I DID IS THAT I CTRL C + CTRL V FROM THIS DUDE: https://stackoverflow.com/questions/38426338/c-sharp-console-disable-resize

using System.Runtime.InteropServices;
using System;

sealed class NoResizing
{

public const int MF_BYCOMMAND = 0x00000000;
public const int SC_CLOSE = 0xF060;
public const int SC_MINIMIZE = 0xF020;
public const int SC_MAXIMIZE = 0xF030;
public const int SC_SIZE = 0xF000;//resize

[DllImport("user32.dll")]
public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

[DllImport("user32.dll")]
public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

[DllImport("kernel32.dll", ExactSpelling = true)]
public static extern IntPtr GetConsoleWindow();

}