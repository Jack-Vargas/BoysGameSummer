using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float delayTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Blast());
    }

    public IEnumerator Blast()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
