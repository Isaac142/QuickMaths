using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100.0f))
            {
                print("Found a: " + hit.collider.name);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }

            Debug.DrawRay(transform.position, Vector3.forward, Color.blue);
        }

    }
}
