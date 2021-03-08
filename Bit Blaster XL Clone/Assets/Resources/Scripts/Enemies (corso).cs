using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public GameObject[] spawnAreas;
    public int maxEnemiesAmountOnStart;
    public int extraEnemiesPerXTotalEnemies;
    public int currentEnemiesAmount = 0;
    public int totalEnemiesAmount = 0;

    int maxEnemies;
	
	// Update is called once per frame
	void Update () {
        this.maxEnemies = this.maxEnemiesAmountOnStart + this.totalEnemiesAmount / this.extraEnemiesPerXTotalEnemies;

        if(this.currentEnemiesAmount < this.maxEnemies){

            this.SpawnRandomEnemy();
        }

	}

    public void SpawnRandomEnemy(){



        // TODO : Randomize
        CreateEnemy enemy;
        enemy = CreateEnemy.GetNewPrimitive();

        this.SetupNewEnemy(enemy);

        this.currentEnemiesAmount++;
        this.totalEnemiesAmount++;
    }

    public void SetupNewEnemy(CreateEnemy enemy, GameObject spawnArea = null){

        if(spawnArea == null){
            int i = Random.Range(0, this.spawnAreas.Length);
            spawnArea = this.spawnAreas[i];
        }

        Vector3 spawnPosition = GetSpawnPosition(spawnArea);

        enemy.transform.position = spawnPosition;
        enemy.transform.parent = this.transform;

        EnemyMovementController enemyMovementController = enemy.movementController;

        if(spawnArea.name == "Left"){
            enemyMovementController.movementDirection = Vector3.right;
		}
		else if (spawnArea.name == "Right")
		{
            enemyMovementController.movementDirection = Vector3.left;
		}
		else if (spawnArea.name == "Top")
		{
			enemyMovementController.movementDirection = Vector3.down;
		}
		else if (spawnArea.name == "Bottom")
		{
			enemyMovementController.movementDirection = Vector3.up;
		}
		

    }

    Vector3 GetSpawnPosition(GameObject spawnArea){

        Vector3 scale = spawnArea.transform.localScale;

        float x = spawnArea.transform.position.x + Random.Range(-scale.x / 2, scale.x / 2);
        float y = spawnArea.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);

        Vector3 location = new Vector3(x, y, 0);

        return location;

    }
}
