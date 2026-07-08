using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;

    void Start()
    {
        int rand = Random.Range(0, 350);
        transform.eulerAngles = new Vector3(0, 0, rand);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z > 360)
        {
            transform.eulerAngles = Vector3.zero;
        }
        transform.eulerAngles += new Vector3(0, 0, speed *Time.deltaTime);
    }
}
