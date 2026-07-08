using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByAi : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public Transform fire4; // a cross shape of fire points

    public float a1Duration = 2.5f;
    public float a1loops = 30;
    public float a1gap = 10;

    public float CoolDownTime;

    private bool passedFirst;
    private int previousAttack;
    public List<int> attacks;

    public Transform[] bombSpawns;
    public GameObject bombs;

    public Transform scarySpawn;
    public GameObject scaryMan;

    public Transform fire3x3;

    public void NewAttack()
    {
        int r = Random.Range(0, attacks.Count);
        Debug.Log(attacks[r].ToString());

        switch (attacks[r])
        {
            case 0:
                StartCoroutine(A1());
                break;
            case 1:
                A2();
                break;
            case 2:
                A3();
                break;
            case 3:
                A4();
                break;
        }

        if (passedFirst)
        {
            int hold = attacks[r];
            attacks[r] = previousAttack;
            previousAttack = hold;
        }
        else
        {
            previousAttack = attacks[r];
            attacks.Remove(attacks[r]);
            passedFirst = true;
        }
    }

    public IEnumerator A1()
    {
        for (int i = 0; i < a1loops; i++)
        {
            yield return new WaitForSeconds(a1Duration);
            firePos.eulerAngles += new Vector3(0, 0, a1gap);
            for (int i2 = 0; i2 < 4; i2++)
            {
                //firePos.eulerAngles = new Vector3(0, 0, i * (360 / 4));

                Instantiate(bullet, firePos.GetChild(i2).position, firePos.GetChild(i2).rotation);
            }

        }


        StartCoroutine(CoolDown());
    }

    public void A2()
    {
        Instantiate(bombs, bombSpawns[0].position, transform.rotation);
        Instantiate(bombs, bombSpawns[1].position, transform.rotation);
        Instantiate(bombs, bombSpawns[2].position, transform.rotation);
        Instantiate(bombs, bombSpawns[3].position, transform.rotation);

        StartCoroutine(CoolDown());
    }

    public void A3()
    {
        Instantiate(scaryMan, scarySpawn.position, transform.rotation);

        StartCoroutine(CoolDown());
    }

    public void A4()
    {
        for (int i = 0; i < fire3x3.childCount; i++)
        {
            Instantiate(bullet, fire3x3.GetChild(i).position, fire3x3.GetChild(i).rotation);
        }
        StartCoroutine(CoolDown());
    }




    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(CoolDownTime);


        NewAttack();

    }

    public void OnEnable()
    {
        StartCoroutine(CoolDown());
    }
}
