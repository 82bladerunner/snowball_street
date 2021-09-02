using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnerSystem : MonoBehaviour
{
    
    [SerializeField] private GameObject[] Spawners;
    public int maxEnemies = 0;
    int randomSpawner;
    private float timer = 6;

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      if((timer) >= 9f)
      { 
          timer = 0f;

          if(maxEnemies > 10) 
            { 
              maxEnemies = 8;
            }
          
          for(int i=0; i<=maxEnemies; i++)
            {
          int randomSpawner = Random.Range(0,10);
          Spawners[randomSpawner].SetActive(true);
            }
           maxEnemies++;
      }
    }
               

    
}
