using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        transform.LookAt(target.transform);
        

        if (time >= 3)
        {
            time = 0;
            GameObject t = Instantiate(projectile, transform.position, Quaternion.identity);
            Destroy(t, 3);
            t.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
        

    }
}
