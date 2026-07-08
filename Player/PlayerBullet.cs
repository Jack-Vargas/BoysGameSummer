using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EStats e = collision.GetComponent<EStats>();
            e.TakeDamage(damage);
        }
        else if (collision.tag == "boss")
        {

        }
        Destroy(gameObject);
    }
}
