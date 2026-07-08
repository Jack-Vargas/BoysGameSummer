using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    public int a;
    public float b;
    public float c;
    public Transform firePos;
    public GameObject bullet;

    private bool passedFirst;
    private int previousAttack;
    public List<int> d ;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            StartCoroutine(fire());
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            int r = Random.Range(0, d.Count);
            Debug.Log(d[r].ToString());

            if (passedFirst)
            {
                int hold = d[r];
                d[r] = previousAttack;
                previousAttack = hold;
            }
            else
            {
                previousAttack = d[r];
                d.Remove(d[r]);
                passedFirst = true;
            }            
        }
    }

    public IEnumerator fire()
    {
        for (int i = 0; i < a; i++)
        {
            yield return new WaitForSeconds(c);
            firePos.eulerAngles += new Vector3(0, 0, b);
            for (int i2 = 0; i2 < 4; i2++)
            {
                //firePos.eulerAngles = new Vector3(0, 0, i * (360 / 4));

                Instantiate(bullet, firePos.GetChild(i2).position, firePos.GetChild(i2).rotation);
            }

        }
    }
}
