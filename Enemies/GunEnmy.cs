using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum enemyType { sceleton, demon}

public class GunEnmy : MonoBehaviour
{
    public float speed;

    public Transform target;

    public Transform firePos;
    public Transform gun;
    public float fireCool;
    private bool gunReady;
    private bool gunRotLock;
    public GameObject Bullet;

    public NavMeshAgent agent;

    public Rigidbody2D rb2d;

    public enemyType myType;

    public float twiceBulletDelay = 0.05f;

    public GamaManager gM;


    void Awake()
    {
        gM = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        gunReady = true;
    }

    public void OnEnable()
    {
        FindNewTarget();
    }

    void Update()
    {
        if (!gunRotLock && target != null)
        {
            Vector2 n = target.position - transform.position;
            gun.right = n.normalized;
        }
        
        if (gunReady)
        {            
            RaycastHit2D hitInfo = Physics2D.Raycast(firePos.position, firePos.right);
            
            if (hitInfo.collider == null)
            {
                return;
            }

            if (hitInfo.collider.tag == "Player")
            {
                StartCoroutine(Fire());
            }
            else
            {
                return;
            }
        }

        if (target !=null)
        {
            agent.SetDestination(target.position);
        }
        
    }
    
    public IEnumerator Fire()
    {
        gunReady = false;
        Instantiate(Bullet, firePos.position, firePos.rotation);

        if (myType == enemyType.demon)
        {
            StartCoroutine(SecondShot());
        }

        yield return new WaitForSeconds(fireCool);
        gunReady = true;
    }

    public IEnumerator SecondShot()
    {
        gunRotLock = true;
        yield return new WaitForSeconds(twiceBulletDelay);
        Instantiate(Bullet, firePos.position, firePos.rotation);

        gunRotLock = false;
    }

    public void FindNewTarget()
    {
        target = gM.FindRandomLivingPlayer(this).transform;
    }
}
