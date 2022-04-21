
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName ="New Data", menuName = "Game Data/New data")]
public class GameData: ScriptableObject
{
    //����λ����Ϣ
    public float[] position;
    public bool lookAtRight;//���ﳯ��trueΪ�����ң�
}
