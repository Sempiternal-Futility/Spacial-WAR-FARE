1- RULES: You have 6.5 seconds to kill an enemy, kill one and the time resets, however, if you run out of time GAME OVER. 
Try to the highest score you can!


&nbsp;

2- SCORE: Each enemy you kill, your score is incremented by 1 (duhhh)
After you get the game over screen, your score will get saved to a file in your game's directory!
(NOTE THAT, THE SCORE IS ONLY GOING TO GET SAVED IF YOU PRESS Y OR N, SO IF YOU QUIT WITH ALT+F4 THE SCORE WON'T SAVE, ONLY WAY TO QUIT THE GAME SAVING YOUR SCORE IS PRESSING 'N' ON GAME OVER SCREEN)


&nbsp;

3- MOVEMENT: You can move only 2 directions (left and right).
To move to the left you can use either 'a' or the 'left arrow'.
To move to the right you can use either 'd' or the 'right arrow'.

If you move to the right corner of the screen, you will teleport to the left side (and vice-versa)
Sorta like pac-man

(if your character / ship is looking weird when moving to the left corner, this is normal)



&nbsp;

4- SHOOTING: That's you kill your foes, you can press either 's' or 'spacebar'


&nbsp;

5 - KNOWN BUGS:

1- Sometimes if you kill an enemy you will get 2 scores, but let's just call it a """""feature""""" (lmao)
2- (not on linux) Very rarely, when you shoot an enemy, it won't die, so you'll have to shoot him again

If you find anymore bugs, please open up an issue in github so i can be aware of it ^.^



&nbsp;

6- .NET 6 VS .FRAMEWORK 2.0 VERSIONS: There's very few differences in the code of these 2 versions.

In the .Framework 2.0, the highscore is written all in a single line, this is because framework 2.0 doesn't support 'append all lines' (i'm refering to the file on your game directory that saves your scores)

Performance is the same (at least on my computer)

There are some other changes to the code, yes, but they are very minor, and as far as i know, doesn't change the behavior of the game at all.



&nbsp;

7- WHICH ONE SHOULD I USE (.net 6 ,  framework 2.0,  or linux):

When it comes to windows, I would recommend .NET 6, since it's newer, but they are pretty much the same, the only big difference is when writing to the "HIGHSCORE.txt" file on your game's directory, as i stated above
Both .Net 6 for windows and framework 2.0 have cpu spikes whenever you shoot, these spikes can vary from 5%-25%

But the best one is the linux version, it has the least amount of bugs (1), its the most stable of the three, and the performance is INCREDIBLE, with no cpu spikes at all, running at around 5% of cpu usage constantly on an old celeron 847

&nbsp;

Hardware used to test .NET 6 version: 
OS: Windows 10 Pro x86_64
Kernel: 10.0.19045
CPU: AMD Ryzen 3 2200g

&nbsp;

Hardware used to test .NET Framework 2.0 version:
OS: Windows XP (Virtual Box VM)
Kernel: ?
CPU: AMD Ryzen 3 2200g

&nbsp;

Hardware used to test .NET 6 (linux):
OS: GNU/Linux Debian 11 (bullseye) x86_64 (Virtualbox VM)
Kernel: Linux 5.10.0-20-amd64
CPU: AMD Ryzen 3 2200g

&nbsp;

Hope you enjoy the game!!!
