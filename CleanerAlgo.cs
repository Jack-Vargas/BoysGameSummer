using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerAlgo : MonoBehaviour
{
    public CleanTarget[] ts;
    public List<GameObject> testMarked = new List<GameObject>();
    public List<MonoBehaviour> t;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = t.Count -1; i != -1; i--) // made this backwards so removing items is easier
            {
                if (t[i] != null)
                {
                    t[i].BroadcastMessage("acti");
                }
                else
                {
                    t.RemoveAt(i);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < testMarked.Count; i++)
            {
                Destroy(testMarked[i]);
            }
        }
    }

    public void Start()
    {
        for (int i =0; i <5; i ++)
        {
            t[i] = ts[i];
        }
    }
}
