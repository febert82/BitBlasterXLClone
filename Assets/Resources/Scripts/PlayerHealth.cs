using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int amountShields;
    public GameObject shipSprite;
    public float invincibleTime = 2f;
    public GameObject[] shieldSprites;
    public Score score;

    bool invincible = false;

    // take damage
    public void TakeDamage()
    {
        if (!this.invincible)
        {
            this.amountShields--;

            if (this.amountShields < 0)
            {
                // destroy ship
                Debug.Log("Destroy ship");
                this.DestroyShip();   
            }
            else
            {
                // bling bling invincible
                Debug.Log("Start invincibility");
                StartCoroutine(this.InvincibleAfterDamage());
            }
        }
    }

    // destroy ship
    public void DestroyShip()
    {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        PlayerPrefs.SetInt("highscore", score.currentScore);

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Destroy(this.gameObject);
    }

    // bling bling invincibility
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Triggered in player health");
    }

    public IEnumerator InvincibleAfterDamage()
    {
        this.invincible = true;
        Debug.Log("Invincible");

        float invisTime = invincibleTime / 8;

        for (int i = 0; i < 4; i++)
        {
            this.shipSprite.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            this.shipSprite.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }

        this.invincible = false;
        Debug.Log("Not invincible");
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < this.amountShields)
            {
                this.shieldSprites[i].SetActive(true);
            }
            else
            {
                this.shieldSprites[i].SetActive(false);
            }
        }
    }
}
