using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

    public float shootingSpeed;
    public float bulletSpeed;
    public int amountAmmo;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public Transform spawnPoint;

    float nextShot = 0;

    // TODO: Add Text UI
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.M) && Time.time > this.nextShot && this.amountAmmo >0){
            this.Shoot();
        }


	}

    void Shoot(){
        this.nextShot = Time.time + this.shootingSpeed;

        GameObject newBullet = GameObject.Instantiate(this.playerBulletPrefab);
        newBullet.transform.position = this.spawnPoint.position;
        newBullet.transform.parent = this.bullets.transform;

        Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        newBulletRigidBody.AddForce(this.transform.up * this.bulletSpeed);

        this.amountAmmo--;
    }
}
