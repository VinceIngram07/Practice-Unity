using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class generateWalls : MonoBehaviour
{
    public GameObject brk;
    float h = 16f, l = 16f;   //wall:  height,length 

    void Start() { }

    void ResiseWall()
    {
        if (Input.GetKeyDown(KeyCode.L)) l++; if (Input.GetKeyDown(KeyCode.K)) l--;
        if (Input.GetKeyDown(KeyCode.H)) h--; if (Input.GetKeyDown(KeyCode.H)) h++;
        print(l); print(h);
    }

    void Wall(float i, float j)
    {
        brk = GameObject.CreatePrimitive(PrimitiveType.Cube);
        brk.transform.position = new Vector3(j * 2f + i % 2f, i * 1f - .1f, 1.5f);
        brk.transform.localScale = new Vector3(1.9f, .9f, 1f);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R)) ResiseWall();

        if (Input.GetKeyDown(KeyCode.B)) for (int i = 0; i < h; i++) for (int j = 0; j < l; j++) Wall(i, j);    //Build Wall
    }
}