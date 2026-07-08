using JetBrains.Annotations;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;

    // Update is called once per frame
    void Update()
    {
        transform.position = (p1.position + p2.position + p3.position + p4.position) / 4;
    }
}
