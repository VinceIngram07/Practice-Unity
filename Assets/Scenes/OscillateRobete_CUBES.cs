using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    public float anStp = 0.4f, an = 0f, limit = 30f;

    void globalcontrol()
    {
        if (Input.GetKey(KeyCode.Slash))
        {
            anStp += 0.05f; // faster walk
        }

        if (Input.GetKey(KeyCode.Backslash))
        {
            if (anStp > 0.1f) anStp -= 0.05f; // slower walk
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            an = anStp = 0f; // stop
        }
    }

    void Start()
    {
    }

    void Update()
    {
        an += anStp;
        this.transform.Rotate(Vector3.forward * anStp);

        if (an < -limit || an > limit)
        {
            anStp *= -1f;
        }

        // Uncomment the lines below if needed
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     GameObject.Instantiate(Vector3(3f, 3f, 0f));
        // }

        globalcontrol();
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class OscillateRobete_CUBES : MonoBehaviour
// {
//     public static float stp = 1f, max = 40f;
//     float anx = 0f acc = 1.1f,dec = 0.9f;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.M)) (stp += acc; print{"acc" = + stp};)
//         if (Input.GetKeyDown(KeyCode.N)) (stp += dec; print{"dec" = + stp};)

//         this.transform.Rotate(new Vector (stp, 0f, 0f)); anx += stp;
//         if (Mathf.Abs(anx) >=max {anx -= 2 stp; stp = -stp;})
//     }
// }
