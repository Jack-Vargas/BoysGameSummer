using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public GameObject exitDoorBlocker;
    public GameObject exitDoorTrigger;
    public GameObject enterDoor;
    public Transform[] waves;
    private int waveIndex;
    public bool Debugging;

    public void EnemyDeath()
    {
        if (waves[waveIndex].childCount!= 1) // its 1 because the enemy whose telling the manager to check for deaths hasnt been destroyed yet
        {
            Debug.Log("somebodies alive");
            return;
        }

        if (waveIndex == waves.Length -1)
        {
            Debug.Log("beat room");
            OpenDoors();
        }
        else
        {
            waveIndex++;
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        for (int i = 0; i < waves[waveIndex].childCount; i++)
        {
            waves[waveIndex].GetChild(i).gameObject.SetActive(true);
        }

        
    }

    public void LockDown()
    {
        enterDoor.SetActive(true);
        exitDoorBlocker.SetActive(true);
    }

    public void OpenDoors()
    {
        if (Debugging) { return; }
        exitDoorBlocker.SetActive(false);
        exitDoorTrigger.SetActive(true);
    }

    public void Update()
    {
        //this is just for testing
        if(Input.GetKeyDown(KeyCode.K))
            {
            SpawnWave();
        }
    }
}
