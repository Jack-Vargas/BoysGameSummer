using UnityEngine;
using System.Collections;

public class Zability : MonoBehaviour
{
    public Transform FirePos;
    public GameObject knife;
    public GameObject nuke;

    private GameObject projectile;

    private bool ready = true;
    public void ActivateAbility()
    { if (!ready)
        {
            return;
        }
        int r = Random.Range(0, 10);

        if (r == 0) { projectile = nuke; }


        else { projectile = knife; }
        Instantiate(projectile, FirePos.position, FirePos.rotation);

        StartCoroutine(Cool());
    }

    public IEnumerator Cool()
    {
        ready = false;
        yield return new WaitForSeconds(0.7f);
        ready = true;
    }
}
