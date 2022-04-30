using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Event Set.
/// </summary>
public static class GameManagerSignals {
    public delegate void Hander();

    /// <summary>
    /// New Game signal. Sent just after player click Play to start a new game
    /// </summary>
    public static event Hander OnNewGameStart;

    public static void DoNewGameStart()
    {
        if (OnNewGameStart != null) OnNewGameStart();
    }

    /// <summary>
    /// Load Game Signal.Sent just after player click Load to load a old history
    /// </summary>
    public static event Hander OnLoadGameUnLoad;
    public static event Hander OnLoadGameLoaded;
    public static void DoLoadGameUnLoad()
    {
        if (OnLoadGameUnLoad!= null) OnLoadGameUnLoad();
    }
    public static void DoLoadGameLoaded()
    {
        if (OnLoadGameLoaded != null) OnLoadGameLoaded();
    }

    public static event Hander OnSaveGame;
    public static void DoSaveGame()
    {
        if (OnSaveGame != null) OnSaveGame();
    }
}
