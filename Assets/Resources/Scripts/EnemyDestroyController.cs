using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public int pointsOnPlayerDestruction;

    public int isSplitter;

    Score score;

    Collectables collectables;

    Enemies enemiesScript;

    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        this.enemiesScript = gaOb.GetComponent<Enemies>();

        this.collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Collectables>();

        this.score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    public void DestroyByPlayer()
    {
        Debug.Log("Destroyed by the player");

        score.RaiseScore(pointsOnPlayerDestruction);

        this.collectables.SpawnRandomCollectable(this.transform);

        this.enemiesScript.currentEnemiesAmount--;
        Destroy(this.gameObject);
    }
}
