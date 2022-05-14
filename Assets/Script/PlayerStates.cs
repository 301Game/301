using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public PlayerData_SO gameData;

    #region Data From GameData
    public float[] position
    {
        get { if (gameData != null) return gameData.position; else return null; }

        set { 
            gameData.position[0] = value[0];
            gameData.position[1] = value[1];
            gameData.position[2] = value[2];
            }
    }
    public bool lookAtRight
    {
        get { if (gameData != null) return gameData.lookAtRight; else return true; }

        set { gameData.lookAtRight = value; }
    }
    #endregion
}
