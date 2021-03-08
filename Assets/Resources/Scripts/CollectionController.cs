using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    public ShootingController shooting;
    public PlayerHealth playerHealth;
    public BombController bombController;
    public PowerUpController powerUpController;

    public int ammoAmount;

    public void Collect(GameObject collectable)
    {
        Collectable collectableScript = collectable.GetComponent<Collectable>();

        string collectableType = collectableScript.collectableType;

        if (collectableType == "ammo")
        {
            Debug.Log("Collecting ammo");
            this.shooting.amountAmmo += ammoAmount;
        }
        else if (collectableType == "shield")
        {
            if (this.playerHealth.amountShields < 5)
            {
                this.playerHealth.amountShields++;
            }
        }
        else if (collectableType == "bomb")
        {
            if (this.bombController.amountBombs < 5)
            {
                this.bombController.amountBombs++;
            }
        }
        else if (collectableType == "berserk")
        {
            this.powerUpController.ActivateBerserkMode();
        }
        else if (collectableType == "multiFire")
        {
            this.powerUpController.ActivateMultiShot();
        }
        else if (collectableType == "laser")
        {
            this.powerUpController.ActivateLaser();
        }

        Destroy(collectable);
    }
}
