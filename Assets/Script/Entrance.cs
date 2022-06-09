using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public enum EntranceType{
        LEFT,
        MIDDLE_LEFT,
        MIDDLE,
        MIDDLE_RIGHT,
        RIGHT,
        GAME_ENTRANCE,
        ANY,
    }
    public EntranceType type;
}
