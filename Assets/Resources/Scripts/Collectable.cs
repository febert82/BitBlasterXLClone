using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Collectable : MonoBehaviour
{
    public float duration;
    float killTime;

    public float blinkingTime;
    bool isBlinking = false;

    public string collectableType;

    SpriteRenderer collectableSprite;

    // Start is called before the first frame update
    void Start()
    {
        this.killTime = Time.time + this.duration;
        this.collectableSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if ((Time.time > this.killTime - this.blinkingTime) && !this.isBlinking)
        {
            StartCoroutine(this.Blink());
            this.isBlinking = true;
        }
        if (Time.time > this.killTime)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < 4; i++)
        {
            this.collectableSprite.enabled = false;
            yield return new WaitForSeconds(0.25f);
            this.collectableSprite.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public static Collectable CreateAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefabs/Ammo"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateShield()
    {
        GameObject shield = (GameObject)Instantiate(Resources.Load("Prefabs/Shield"));
        return shield.GetComponent<Collectable>();
    }

    public static Collectable CreateLaser()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Prefabs/Laser"));
        return laser.GetComponent<Collectable>();
    }

    public static Collectable CreateBomb()
    {
        GameObject bomb = (GameObject)Instantiate(Resources.Load("Prefabs/Bomb"));
        return bomb.GetComponent<Collectable>();
    }

    public static Collectable CreateBerserkMode()
    {
        GameObject berserk = (GameObject)Instantiate(Resources.Load("Prefabs/Berserk"));
        return berserk.GetComponent<Collectable>();
    }

    public static Collectable CreateMultiShot()
    {
        GameObject multiShot = (GameObject)Instantiate(Resources.Load("Prefabs/MultiFire"));
        return multiShot.GetComponent<Collectable>();
    }
}
