using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PStats p = collision.GetComponent<PStats>();
            p.TakeDamage(damage);
        }
    }
}
