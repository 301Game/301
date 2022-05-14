using UnityEngine;

/// <summary>
/// The item data.
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "New Data", menuName = "Game Data/New Item Data")]
public class ItemData_SO : ScriptableObject
{
    public string ItemTitle;

    [TextArea]
    public string ItemDesc;
    public Sprite ItemImg;
}

