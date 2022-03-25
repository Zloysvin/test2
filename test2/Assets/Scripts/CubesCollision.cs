using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesCollision : MonoBehaviour
{
    public GameObject[] Cubes = new GameObject[11];

    public bool Launched = false;
    public bool isMoving;
    public bool hasColided = false;

    public Vector3 LastPos;

    public int value = 2;


    public void FixedUpdate()
    {
        if (transform.position == LastPos)
            isMoving = false;
        else
            isMoving = true;
        LastPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log(value + " " + GetComponent<Rigidbody>().velocity.magnitude);
            if (GetComponent<Rigidbody>().velocity.magnitude > collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude)
            {
                if (collision.gameObject.GetComponent<CubesCollision>().value == value && !hasColided)
                {
                    hasColided = true;
                    Destroy(gameObject);
                    GameObject temp;
                    System.Random rnd = new System.Random();
                    Vector3 oldPos = collision.gameObject.transform.position;
                    Quaternion oldRot = collision.gameObject.transform.rotation;
                    Destroy(collision.gameObject);
                    temp = Instantiate(Cubes[(int)Math.Log(value * 2, 2) - 1], oldPos, Quaternion.identity);
                    temp.transform.rotation = oldRot;
                    Debug.Log(temp.GetComponent<CubesCollision>().value);
                    if (rnd.Next(0, 100) <= 30)
                    {
                        temp.GetComponent<Rigidbody>().AddForce(new Vector3(0, 40, 0), ForceMode.Impulse);
                    }
                    Camera.current.gameObject.GetComponent<ScoreCount>().score += value * 2;
                }
            }
        }
    }
}
