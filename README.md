# Lab3 - Contemporary software development
#### Solution by [Martin](https://github.com/bergstr) & [Daniel](https://github.com/DDaaNNee) 🚀

A tic-tac-toe inspired game created for a lab in the information systems master program at Uppsala university.


The game is a stacked tic-tac-toe with up to 2 levels. A player has to win three "small" boards each containing 
a tic-tac-toe to win the "large" board that contains the small boards.

![Tic tac toe](tic-tac-toe.png?raw=true "Tic tac toe")

A single command line argument provides the coordinates for each player move, where Player X starts and the following coordinates alternate between Player X and Player O. 
However, only valid moves i.e. not pointing to a tile already played or a small board already won is accepted, 
otherwise we assume that the next move in the list of coordinates belongs to the player in question since the first move was rejected.

![Coordinates](coordinates.png?raw=true "Coordinates")


Example input: `Lab3.exe "NW.CC, NC.CC, NW.NW, NE.CC, NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE"`

A scoreboard is printed at the end of the game, showing a list of winning large boards, list of winning small boards in the order in which they were played 
and a comma separated value denoting how many games player X has won while the second value denotes that of player O. Each value contains number of large and small board wins separated with a dot.

Example output:

<pre>NW, CW, SW<br>NW.CC, NW.NW, NW.SE, CW.CC, CW.NW, CW.SE, SW.CC, SW.NW, SW.SE<br>1.3, 0.1</pre>
