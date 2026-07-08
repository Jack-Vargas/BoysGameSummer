using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Gun : MonoBehaviour
{
    public bool upgraded;

    public float baseDamage;
    public float damageMod;

    public float baseFireRate;
    public float fireRate; //fire every X seconds
    private float nextShot;
    public int blockers;

    public GameObject activeBullet;
    public GameObject baseBullet;
    public GameObject ghostBullet;
    public GameObject bigBullet;
    public GameObject smallBullet;

    public Transform firePoint;
    public InputAction ShootAction;
    public bool requestFire;

    public Transform f2;//extra bullet 1
    public Transform f3;


    public void Start()
    {
        ShootAction = InputSystem.actions.FindAction("Attack");
        baseFireRate = fireRate;
        if (PlayerPrefs.GetFloat("upgraded") == 1)
        {
            fireRate = 0.2f;
            activeBullet = bigBullet;
        }
    }

    public void FireMetaCheck(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            requestFire = true;
        }

        else if (context.canceled)
        {
            requestFire = false;
        }
    }

    void Update()
    {
        //ShootAction.started += ctx => requestFire = true;
        //ShootAction.canceled += ctx => requestFire = false;

        if (requestFire)
        {
            FireCheck();
        }
    }

    public void FireCheck()// the argument is only necisary if youre using my multiplayer setup
    {        
            if (nextShot < Time.time && blockers == 0)
            {
                Fire();
            }        
    }


    public void Fire()
    {
        nextShot = Time.time + fireRate;
        Instantiate(activeBullet, firePoint.position, firePoint.rotation); // GameObject b = instance
        if(upgraded)
        {
            Instantiate(smallBullet, f2.position, f2.rotation);
            Instantiate(smallBullet, f3.position, f3.rotation);
        }
    }


    public IEnumerator PowerUp(float damageAdded, float duration)
    {
        damageMod += damageAdded;

        yield return new WaitForSeconds(duration);

        damageMod -= damageAdded;
    }

    
}
