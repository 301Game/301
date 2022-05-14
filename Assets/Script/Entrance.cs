using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public enum EntranceType{
        LEFT,
        MIDDLE,
        RIGHT,
        GAME_ENTRANCE,
        ANY,
    }
    public EntranceType type;
}
