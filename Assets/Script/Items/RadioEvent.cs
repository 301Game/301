using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioEvent : MonoBehaviour
{
    public string targetBlock;

    [Tooltip("The bound boolean variable")]
    public string booleanVar;
    public RadioPassword RadioPassword;

    private void OnEnable()
    {
        RadioPassword.Register(targetBlock, booleanVar);
    }
    public void OnKeyDown()
    {
        var flows = FindObjectsOfType<Fungus.Flowchart>();
        foreach (var flow in flows)
        {
            if (flow.HasBlock(targetBlock))
            {
                bool pass = flow.GetBooleanVariable(booleanVar);
                if (!pass)
                {
                    //
                }
                else
                {
                    flow.ExecuteBlock(targetBlock);
                }
            }
        }
    }
}
