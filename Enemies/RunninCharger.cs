using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RunninCharger : MonoBehaviour
{
    public bool isTackling;

    public float speed;
    public float damage;
    public float tackleTime;
    public Transform target;

    public NavMeshAgent agent;

    public int moveBlockers;
    public int attackBlockers;
    public float chargeDistance;
    public float recovery;

    public Rigidbody2D rb2d;
    public GamaManager gM;


    public void Awake()
    {
        gM = GameObject.FindWithTag("manager").GetComponent<GamaManager>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if(distance < chargeDistance && attackBlockers == 0)
        {
            StartCoroutine(Tackle());
        }

        if (moveBlockers == 0)
        {
            agent.SetDestination(target.position);
            //rb2d.linearVelocity = (target.position - transform.position).normalized * speed;
        }
    }

    private void OnEnable()
    {
        FindNewTarget();
    }

    public IEnumerator Tackle()
    {
        moveBlockers++;
        attackBlockers++;
        rb2d.linearVelocity = rb2d.linearVelocity = (target.position - transform.position).normalized * speed * 3;
        yield return new WaitForSeconds(tackleTime);

        rb2d.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(recovery);
        moveBlockers--;
        yield return new WaitForSeconds(recovery * 2f);
        attackBlockers--;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Player")
        {
            PStats pS = other.GetComponent<PStats>();
            pS.TakeDamage(damage);
        }
    }

    public void FindNewTarget()
    {
        target = gM.FindRandomLivingPlayer(this).transform;
    }
}
