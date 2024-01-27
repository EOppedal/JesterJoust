using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnScript : MonoBehaviour
{
    public GameObject[] prefabItems;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnThings());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnThings()
    {
        for (int i = 1; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);

        	//Choose random X position and random prefab item to spawn
            float xrand = Random.Range(-10.0f, 10.0f); 
            float yrand = Random.Range(-5.0f, 5.0f); 
	        Vector2 v = new Vector2(xrand, yrand);
	        int index = Random.Range(0, 4);
	        Instantiate(prefabItems[index], v, Quaternion.identity);
        }
    }
}
