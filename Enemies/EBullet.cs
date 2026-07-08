using UnityEngine;
using UnityEngine.Events;

public class EBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Rigidbody2D rb2d;
    public bool isPersistent;
    public bool variableSpeed;

    public void Update()
    {
        rb2d.linearVelocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PStats p = collision.GetComponent<PStats>();
            p.TakeDamage(damage);
        }
        if (!isPersistent)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        damage *= PlayerPrefs.GetFloat("difficultyDmg");

        if (variableSpeed)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                float additive = Random.Range(0, 4);
                speed += additive;
            }
            //Debug.Log(speed);
        }
    }
}