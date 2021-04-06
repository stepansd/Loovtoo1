using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickup;
    int xPos, zPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawnCo()
    {
        while (true)
        {
            xPos = Random.Range(-10, 10);
            zPos = Random.Range(10, -10);
            Instantiate(pickup, new Vector3(xPos, transform.position.y, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
