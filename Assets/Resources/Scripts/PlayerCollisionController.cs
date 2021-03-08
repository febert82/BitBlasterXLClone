using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;

    public CollectionController collectionController;

    // Start is called before the first frame update
    void Start()
    {
        this.player = this.transform.parent.gameObject;
        this.playerHealth = this.player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InnerBorder")
        {
            print("Destroyed the ship");
            this.playerHealth.DestroyShip();
        }
        else if (collision.gameObject.tag == "EnemyCollider")
        {
            print("Touched enemy");
            this.playerHealth.TakeDamage();
        }
        else if (collision.gameObject.tag == "Collectable")
        {
            this.collectionController.Collect(collision.gameObject);
        }
    }
}
