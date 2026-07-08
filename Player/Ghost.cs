using UnityEngine;
using System.Collections;


public class Ghost : MonoBehaviour
{
    public float reviveTime;
    public PStats Stats;
    public float reviveHealth = 5;

    public Gun gun;
    public float ghostFireRate;
    public SpriteRenderer sr;

    public Sprite ghostSprite;
    public Sprite liveSprite;
    private int playerNumber;


    public void BeginRevive()
    {
        sr.sprite = ghostSprite;
        gun.fireRate = ghostFireRate;
        gun.activeBullet = gun.ghostBullet;
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 7, true);
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 13, true);

        StartCoroutine(Revive());
    }


    public IEnumerator Revive()
    {
        yield return new WaitForSeconds(reviveTime);
        Stats.health = reviveHealth;
        gun.fireRate = gun.baseFireRate;
        sr.sprite = liveSprite;
        gun.activeBullet = gun.baseBullet;
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 7, false);
        Physics2D.IgnoreLayerCollision(playerNumber + 7, 13, false);
    }

    public void Awake()
    {
        playerNumber = Stats.playerNumber;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
}
