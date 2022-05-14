using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVEvent : MonoBehaviour
{
    public string targetBlock;

    [Tooltip("The bound boolean variable")]
    public string booleanVar;
    public PasswordLock passwordLock;

    private void OnEnable()
    {
        passwordLock.Register(targetBlock, booleanVar);
    }
    public void OnKeyDown()
    {
        var flows = FindObjectsOfType<Fungus.Flowchart>();
        foreach(var flow in flows)
        {
            if (flow.HasBlock(targetBlock))
            {
                bool pass = flow.GetBooleanVariable(booleanVar);
                if (!pass)
                {
                    passwordLock.Show();
                }
                else
                {
                    flow.ExecuteBlock(targetBlock);
                }
            }
        }
    }
}
