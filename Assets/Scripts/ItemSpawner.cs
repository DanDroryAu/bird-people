using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

	//List Of Items To Spawn
	[SerializeField] GameObject[] trashItems;
	[SerializeField] GameObject[] foodItems;
	[SerializeField] int foodAmount;
	[SerializeField] int trashAmount;
	[SerializeField] float xSpawnRange;
	[SerializeField] float zSpawnRange;


	
    // Start is called before the first frame update
    void Start()
    {
		//define area to spawn items in and drawn the lines with debug
		//get bounds of the colliders X and Z 
		BoxCollider bcolldier = GetComponent<BoxCollider>();
		bcolldier.size = new Vector3(xSpawnRange, 0.2f, zSpawnRange);
		Debug.Log(bcolldier.bounds.min);
		Debug.Log(bcolldier.bounds.max);

		//Pick random item

		for(int i = 0; i < foodAmount; i++) {
		GameObject itemToSpawn = foodItems[Random.Range(0, foodItems.Length)];
		var position = new Vector3(Random.Range(bcolldier.bounds.min.x,bcolldier.bounds.max.x), 0, Random.Range(bcolldier.bounds.min.z,bcolldier.bounds.max.z));
        Instantiate(itemToSpawn, position, Quaternion.identity);
	}

		for(int i = 0; i < trashAmount; i++) {
		GameObject itemToSpawn = trashItems[Random.Range(0, trashItems.Length)];
		var position = new Vector3(Random.Range(bcolldier.bounds.min.x,bcolldier.bounds.max.x), 0, Random.Range(bcolldier.bounds.min.z,bcolldier.bounds.max.z));
        Instantiate(itemToSpawn, position, Quaternion.identity);
	}
	

        
    }

	private void OnDrawGizmos() {
		Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(xSpawnRange, 0.1f, zSpawnRange));
	}

    // Update is called once per frame
    void Update()
    {
         		
    }
}
