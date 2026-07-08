using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject spawnPrefab;
    public void IDied()
    {
        Instantiate(spawnPrefab,transform.position,transform.rotation);
    }
}
