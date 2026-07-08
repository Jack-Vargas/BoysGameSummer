using UnityEngine;

public class HealPPickUp : MonoBehaviour
{
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PStats p = collision.GetComponent<PStats>();
            p.Heal(heal);
            Destroy(gameObject);
        }
    }
}
