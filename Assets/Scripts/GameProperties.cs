using UnityEngine;
using System.Collections;

public class GameProperties
{
    public bool gameStarted = false;
    public bool gamePaused = false;

    private static GameProperties currentGame;

    public static GameProperties GetCurrentGame()
    {
        if (currentGame == null)
        {
            currentGame = new GameProperties();
        }
        return currentGame;
    }
}
