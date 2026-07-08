using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.XR;

public class CameraMove : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform mover;

    private bool isB;

    public CinemachineCamera cineCam;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isB)
            {
                mover.position = b.position;
            }
            else
            {
                mover.position = a.position;
            }
            isB = !isB;
        }
    }
}
