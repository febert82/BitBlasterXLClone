using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float basicDuration;
    public bool powerUpActive = true;

    public MultiShot multiShot;

    float activeUntilTime = 0f;

    public GameObject laser;
    public GameObject berserkModeCirlce;

    string powerUpType = "multiShot";

    // Start is called before the first frame update
    void Start()
    {
        ActivateBerserkMode();   
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (powerUpActive && Time.time < this.activeUntilTime)
        {
            if (this.powerUpType == "multiShot")
            {
                this.multiShot.ShootRepeating();
            }
            else if (this.powerUpType == "laser")
            {
                this.laser.SetActive(true);
            }
            else if (this.powerUpType == "berserk")
            {
                this.berserkModeCirlce.SetActive(true);
            }
        }
        else
        {
            this.powerUpType = null;
            this.powerUpActive = false;
        }
        if (this.powerUpType != "laser")
        {
            this.laser.SetActive(false);
        }
        else if (this.powerUpType != "berserk")
        {
            this.berserkModeCirlce.SetActive(false);
        }
    }

    public void ActivateMultiShot()
    {
        this.powerUpActive = true;
        this.powerUpType = "multiShot";
        this.activeUntilTime = Time.time + this.basicDuration;
    }

    public void ActivateLaser()
    {
        this.powerUpActive = true;
        this.powerUpType = "laser";
        this.activeUntilTime = Time.time + this.basicDuration;
    }

    public void ActivateBerserkMode()
    {
        this.powerUpActive = true;
        this.powerUpType = "berserk";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
}
