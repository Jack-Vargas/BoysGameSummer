using UnityEngine;

public class TesterMove : MonoBehaviour
{
    public bool type;
    private Vector3 Target;

    public Rigidbody2D rb2d;
    public float speed;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!type)
            {
                MoveOrder();
            }
        }

        else if(Input.GetMouseButtonDown(1))
        {
            if (type)
            {
                MoveOrder();
            }
        }

        if (speed !=0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        }
    }

    public void MoveOrder()
    {
        float divergence = Random.Range(-2, 2);
        speed = 2;
        Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target = Target + new Vector3(0,divergence, 5);
    }
}
