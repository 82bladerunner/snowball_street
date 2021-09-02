using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    [SerializeField] private Transform spawnerLocation;
    private float randMob;
    private float timer;
    // Start is called before the first frame update
    void OnEnable()
    {
        int randMob = Random.Range(0,(Enemies.Length)); //-1 is excluded, 4 included
        Instantiate(Enemies[randMob], spawnerLocation.position, spawnerLocation.rotation);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    

    
}


