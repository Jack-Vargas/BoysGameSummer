using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float delay = 1;

    public void Start()
    {
        StartCoroutine(SpawnGuy());
    }

    public IEnumerator SpawnGuy()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(Enemy,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
