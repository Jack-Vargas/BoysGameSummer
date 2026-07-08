using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool armour;
    //public GameObject ghost;
    public Ghost ghostScript;

    public float iFrames;
    public int playerNumber; // 1,2,3,4

    public Material saved;
    public Material damaged;
    public SpriteRenderer sR;

    public Slider bar;

    public void Heal(float heal)
    {
        health += heal;
        if (health < maxHealth)
        {
            health = maxHealth;
            if (bar != null)
            {
                bar.value = health;
            }
        }
    }

    public void OnEnable()
    {
        GamaManager gm = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
        switch(playerNumber)
        {
            case 1:
                gm.p1 = gameObject;
                break;

            case 2:
                gm.p2 = gameObject;
                break;

            case 3:
                gm.p3 = gameObject;
                break;

            case 4:
                gm.p4 = gameObject;
                break;
        }
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        
        if (health < 0.1f)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageFlash());
            StartCoroutine(IFrames());
        }
        if (bar != null)
        {
            bar.value = health;
        }
    }

    public IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 7, true);
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 13, true);
        yield return new WaitForSeconds(iFrames);
        //Debug.Log("endIFrames");
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 7, false);
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 13, false);
    }

    public IEnumerator DamageFlash()
    {
        sR.material = damaged;
        yield return new WaitForSeconds(iFrames);
        sR.material = saved;
    }

    public void Die()
    {
        ghostScript.BeginRevive();
    }

    public void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        saved = sR.material;
    }

    public void Revive()
    {

    }
}
