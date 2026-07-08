using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class GamaManager : MonoBehaviour
{
    public int ghostCount;
    public List<GameObject> livingPlayers;

    public bool isPaused;
    public GameObject pauseScreen;
    public InputAction PauseAction;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Transform[] ps; 

    public DifficultyAdjuster DA;
    public Transform camTarget;

    public List<MonoBehaviour> targeting1;
    public List<MonoBehaviour> targeting2;
    public List<MonoBehaviour> targeting3;
    public List<MonoBehaviour> targeting4;

    public Vector2[] respawnPoints;

    public Slider[] sliders;


    public void Start()
    {
        Time.timeScale = 1.0f;
        PauseAction = InputSystem.actions.FindAction("Pause");        
    }

    public void SetUpPlayers()
    {
        livingPlayers.Add(p1);
        livingPlayers.Add(p2);
        livingPlayers.Add(p3);
        livingPlayers.Add(p4);

        ps[0] = p1.transform;
        ps[1] = p2.transform;
        ps[2] = p3.transform;
        ps[3] = p4.transform;

        p1.GetComponent<PStats>().bar = sliders[0];
        p2.GetComponent<PStats>().bar = sliders[1];
        p3.GetComponent<PStats>().bar = sliders[2];
        p4.GetComponent<PStats>().bar = sliders[3];
    }

    void Update()
    {
        PauseAction.started += ctx => GamePause();
    }    

    public void addGhost(GameObject deceased) 
    {
        switch (deceased.layer)// depending on which player died make all enemies targeting them find a new target
        {
            case 8:
                DemandRecall(targeting1);
            break;

            case 9:
                DemandRecall(targeting2);
                break;


            case 10:
                DemandRecall(targeting3);
                break;

            case 11:
                DemandRecall(targeting4);
                break;
            
        }

        livingPlayers.Remove(deceased);
        ghostCount++;
        if (ghostCount == 4)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void reviveGhost(GameObject player)
    {
        livingPlayers.Add(player);
        ghostCount--;
    }

    public void GamePause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);
        if (isPaused )
        {
            DA.canEdit = true;
            Time.timeScale = 0;
        }
        else
        {
            DA.canEdit = false;
            Time.timeScale = 1;
        }
    }

    public GameObject FindRandomLivingPlayer(MonoBehaviour asker)
    {
        int rando = Random.Range(0, livingPlayers.Count);
        switch (livingPlayers[rando].layer)
        {
            case 8:
                targeting1.Add(asker);
                break;

            case 9:
                targeting2.Add(asker);
                break;


            case 10:
                targeting3.Add(asker);
                break;

            case 11:
                targeting4.Add(asker);
                break;

        }
        return livingPlayers[rando];
        
    }

    public void Warp(Vector2 endSpot, Vector3 camPos)
    {
        for (int i = 0; i < 4; i++)
        {
            ps[i].position = endSpot + Additive(i);
        }

        camTarget.position = camPos;
    }

    public void DemandRecall(List<MonoBehaviour> l)
    {
        for (int i = l.Count - 1; i != -1; i--) // made this backwards so removing items is easier
        {
            if (l[i] != null)
            {
                l[i].BroadcastMessage("FindNewTarget");
            }
            else
            {
                l.RemoveAt(i);
            }
        }
    }

    public Vector2 Additive(int pID)
    {
        switch (pID)
        {
            case 0:
                return new Vector2(-1.5f, 1.5f);

            case 1:
                return new Vector2(1.5f, 1.5f);

            case 2:
                return new Vector2(-1.5f, -1.5f);

            case 3:
                return new Vector2(1.5f, -1.5f);

            default:
                return Vector2.zero;
        }
    }

}
