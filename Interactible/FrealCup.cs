using System.Diagnostics.Contracts;
using UnityEngine;

public class FrealCup : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        float randY = Random.Range(-0.5f, -0.1f);
        float randX = Random.Range(-0.9f, 0.9f);
        rb.linearVelocity = new Vector2(randX,randY);
    }

    
}
