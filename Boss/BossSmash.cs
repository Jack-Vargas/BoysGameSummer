using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossSmash : MonoBehaviour
{
    public float CoolDownTime;

    public Transform target;

    public Transform firePos;
    public GameObject pill;
    public GameObject paluLight;
    public GameObject incin;
    public GameObject rock;

    public int pillCount;
    private Vector2 area;

    private bool passedFirst;
    private int previousAttack;
    public List<int> attacks;

    public void NewAttack()
    {
        int r = Random.Range(0, attacks.Count);
        Debug.Log(attacks[r].ToString());

        switch (attacks[r])
        {
            case 0:
                Rock();
                break;
            case 1:
                Palu();
                break;
            case 2:
                Incin();
                break;
            case 3:
                Pills();
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



    public void Rock()
    {
        for (int i = 0; i < 5; i++)
        {
            float randX = Random.Range(-6,6);
            float randY = Random.Range(-3,3);

            Instantiate(rock, area + new Vector2(randX, randY), transform.rotation);
        }
        StartCoroutine(CoolDown());
    }

    public void Palu()
    {
        Vector2 n = target.position - transform.position;
        firePos.right = n.normalized;
        for (int i = 0; i < firePos.childCount; i++)
        {
            Instantiate(paluLight, firePos.GetChild(i).position, firePos.rotation);
        }

        StartCoroutine(CoolDown());
    }

    public void Incin()
    {
        Vector2 n = target.position - transform.position;
        firePos.right = n.normalized;

        Instantiate(incin, transform.position, firePos.rotation);

        StartCoroutine(CoolDown());
    }

    public void Pills()
    {
        for (int i = 0;i < pillCount;i++)
        {
            firePos.eulerAngles = new Vector3(0, 0, i * (360 / pillCount));
            Instantiate(pill, transform.position, firePos.rotation);
        }
        StartCoroutine(CoolDown());
    }


    public void Start()
    {
        area = transform.position;
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
