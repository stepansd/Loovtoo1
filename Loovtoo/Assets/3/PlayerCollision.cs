using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameObject.Find("Message").GetComponent<Text>().text = "";
        GameObject.Find("Score").GetComponent<Text>().text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 4)
        {
            GameObject.Find("Message").GetComponent<Text>().text = "VICTORY";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "pickup")
        {
            Destroy(collision.collider.gameObject);
            score++;
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score;
        }

        if (collision.gameObject.tag == "Bullet")
        {
           gameObject.transform.position = GameObject.Find("Start").transform.position;
           GameObject.Find("Score").GetComponent<Text>().text = "Score: ";
            score = 0;
        }

    }
}
