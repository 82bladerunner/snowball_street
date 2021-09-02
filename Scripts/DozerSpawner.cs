using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozerSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject Snowdozer;
    void Start()
    {
        Invoke("SpawnDozers", 80f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnDozers()
    {
        Instantiate(Snowdozer, spawnPoint.position, spawnPoint.rotation);
    }
}
