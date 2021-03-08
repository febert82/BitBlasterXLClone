using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {

	public EnemyMovementController movementController;

	void Start()
	{
		GetNewPrimitive();
	}

	public static CreateEnemy GetNewPrimitive()
	{

		GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/EnemyPrimitive"));
		return enemy.GetComponent<CreateEnemy>();
	}
}
