using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManagerSignals {
    /// <summary>
    /// New Game signal. Sent just after player click Play to start a new game
    /// </summary>
    public delegate void NewGameHander();
    public static event NewGameHander OnNewGameStart;

    public static void DoNewGameStart()
    {
        if (OnNewGameStart != null) OnNewGameStart();
    }

    /// <summary>
    /// Load Game Signal.Sent just after player click Load to load a old history
    /// </summary>
    public delegate void LoadGameHander();
    public static event LoadGameHander OnLoadGameLoaded;
    public static void DoLoadGameLoaded()
    {
        if (OnLoadGameLoaded != null) OnLoadGameLoaded();
    }

}
