using System.Collections;
using UnityEngine;

public class EStats : MonoBehaviour
{
    public float health;
    public float typicalStun;
    public GameObject Explosion;
    public RoomManager room;
    public MonoBehaviour onDestroy;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <1)
        {
            Die();
        }
        StartCoroutine(Stun(typicalStun));
    }

    public void Die()
    {
        if (onDestroy != null)
        {
            onDestroy.BroadcastMessage("IDied");
        }

        if (room != null)
        {
            room.EnemyDeath();
        }
        if (Explosion != null)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    public IEnumerator Stun(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
    }

    public void Start()
    {
        health *= PlayerPrefs.GetFloat("difficultyHp");
    }

}
