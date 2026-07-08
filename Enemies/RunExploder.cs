using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RunExploder : MonoBehaviour
{

    public float speed;
    public float explodeTime;
    public Transform target;

    public NavMeshAgent agent;

    public int moveBlockers;
    public int attackBlockers;
    public float chargeDistance;
    public float recovery;

    public Rigidbody2D rb2d;

    public GameObject Explosion;
    public GamaManager gM;

    public EStats stats;


    public void Start()
    {
        gM = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        FindNewTarget();
        StartCoroutine(GracePeriod());
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance < chargeDistance && attackBlockers == 0)
        {
            StartCoroutine(Explode());
        }

        if (moveBlockers == 0)
        {
            agent.SetDestination(target.position);
        }
    }

    public IEnumerator Explode()
    {
        moveBlockers++;
        attackBlockers++;
        rb2d.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(explodeTime);

        Instantiate(Explosion, transform.position, transform.rotation);

        stats.Die();

    }

    public void FindNewTarget()
    {
        target = gM.FindRandomLivingPlayer(this).transform;
    }

    public IEnumerator GracePeriod()
    {
        attackBlockers++;
        yield return new WaitForSeconds(0.3f);
        attackBlockers--;
    }
}
