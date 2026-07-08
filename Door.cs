using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private int players;
    private GamaManager gm;
    public Vector2 exitPoint;
    public bool isVertical;
    public Vector3 camEndPos;

    public RoomManager nextRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        players++;

        if(players == 4)
        {
            NextRoom();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        players--;
    }

    public void NextRoom()
    {
        gm.Warp(exitPoint, camEndPos);
        StartCoroutine(BeginCombat());
    }

    public void Start()
    {
        gm = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
    }

    public IEnumerator BeginCombat()
    {
        yield return new WaitForSeconds(0.7f);
        nextRoom.SpawnWave();
    }
}
