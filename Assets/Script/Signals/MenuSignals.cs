using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuSignals
{
    public delegate void MenuStartHandler(MonoBehaviour menu);
    public delegate void MenuEndHander(MonoBehaviour menu);


    public static event MenuStartHandler OnMenuShow;
    public static event MenuEndHander OnMenuEnd;

    public static void DoMenuShow(MonoBehaviour menu) { if (OnMenuShow != null) OnMenuShow(menu); }
    public static void DoMenuEnd(MonoBehaviour menu) { if (OnMenuEnd != null) OnMenuEnd(menu); }



}
