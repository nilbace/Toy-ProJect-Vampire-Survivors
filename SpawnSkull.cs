using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkull : MonoBehaviour
{
    [SerializeField] GameObject skull;
    [SerializeField] GameObject Player;

    void Start()
    {
        StartCoroutine(SkullSpawnPoint());
    }

    IEnumerator SkullSpawnPoint()
    {
        while(true)
        {
            for(int i = 0; i < 14; i++)
            {
                GameObject instance = Instantiate(skull,
                            Player.transform.position + new Vector3(-20, -9+3*i), Quaternion.identity);
                GameObject instance2 = Instantiate(skull,
                            Player.transform.position + new Vector3(20, -9+3*i), Quaternion.identity);
                Destroy(instance, 50f); Destroy(instance2, 50f);
                
            }
            yield return new WaitForSeconds(20f);
        }
    }

}

    
