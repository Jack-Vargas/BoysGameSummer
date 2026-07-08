using System.Collections;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;

    public float speed;
    public bool moving;
    public float startDelay;
    public float endDelay;

    public void Update()
    {
        if (moving)
        {
            if (transform.position != targetPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
            }

            else
            {
                StartCoroutine(Transition());
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            beatLevel();
        }
    }

    public IEnumerator ComenceMove()
    {
        yield return new WaitForSeconds(startDelay);
        moving = true;
    }

    public IEnumerator Transition()
    {
        yield return new WaitForSeconds(endDelay);

    }

    public void beatLevel()
    {
        targetPos= target.position;
        StartCoroutine(ComenceMove());
    }
}
