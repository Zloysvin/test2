using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{// 9.18; 11.9
    public GameObject[] Cubes = new GameObject[3];
    public GameObject Ground;

    GameObject Launch;
    int number = 0;

    void Update()
    {
        System.Random rnd = new System.Random();
        if (Input.GetMouseButtonDown(0)) 
        {
            int chance = rnd.Next(0, 100);
            if (chance >= 70)
                Launch = Instantiate(Cubes[2], new Vector3(0f, 1.417035f, -15.21301f), Quaternion.identity);
            else if (chance >= 50)
                Launch = Instantiate(Cubes[1], new Vector3(0f, 1.417035f, -15.21301f), Quaternion.identity);
            else
                Launch = Instantiate(Cubes[0], new Vector3(0f, 1.417035f, -15.21301f), Quaternion.identity);
            //Launch.GetComponent<Rigidbody>().drag = 1;
        }
        if(Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > 0 && Input.mousePosition.x <= 1080)
                Launch.transform.position = new Vector3(-1.28f + 0.00237037037037037037037037037037f * Input.mousePosition.x, Launch.transform.position.y, Launch.transform.position.z);
            //Debug.Log(Input.mousePosition.x);// 0.00251851851851851851851851851852
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            Launch.GetComponent<CubesCollision>().Launched = true;
            Launch.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 100), ForceMode.Impulse);
        }
    }
}
