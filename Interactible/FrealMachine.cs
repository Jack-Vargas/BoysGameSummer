using UnityEngine;

public class FrealMachine : MonoBehaviour
{
    public float health;
    public GameObject[] cups;
    public Transform fire;
    private int healther = 9;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health < 1)
        {
            if (healther > 1)
            {
                
            }
        }
    }

    public void IDied()
    {
        for (int i = 0; i < 20; i++)
        {
            int R = Random.Range(0, 3);
            Instantiate(cups[R], fire.position, new Quaternion(0, 0, 0, 0));
        }
        healther--;
    }
}
