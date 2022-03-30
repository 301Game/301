using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public GameData gameData;

    #region Data From GameData
    public float[] position
    {
        get { if (gameData != null) return gameData.position; else return null; }

        set { gameData.position = value; }
    }
    public bool lookAtRight
    {
        get { if (gameData != null) return gameData.lookAtRight; else return true; }

        set { gameData.lookAtRight = value; }
    }
    #endregion
}
