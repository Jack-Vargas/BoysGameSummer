using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    public float delay;
    public BoxCollider2D trigger;
    public Rigidbody2D rb;

    public void Start()
    {
        StartCoroutine(WindUp());
    }

    public void Update()
    {
        if (transform.position.y < 0)
        {
            trigger.enabled = true;
            rb.gravityScale = 0;
            rb.linearVelocity= new Vector2(0, 0);
            StartCoroutine(SelfDestruct());
        }
    }

    public IEnumerator WindUp()
    {
        yield return new WaitForSeconds(delay);

        rb.gravityScale = 11;
    }

    public IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(transform.parent.gameObject);
    }
}
