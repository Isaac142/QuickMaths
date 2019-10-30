using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    private bool visible;

    public GameObject rayStart;

    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        RayCastActivator();

    }

    private void FixedUpdate()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Physics.Raycast(rayStart.transform.position, -rayStart.transform.up, out hit, 100))
        {
            Debug.DrawLine(rayStart.transform.position, hit.point);
        }
    }

    void RayCastActivator()
    {

        //raycast from weapon
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(rayStart.transform.position, -rayStart.transform.up, out hit, 100))
            {
                Debug.DrawLine(rayStart.transform.position, hit.point);
                print(hit.collider.name);
            }
        }

        //Old Raycast from middle of camera

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100))
        //    {
        //        print(hit.collider.name);
        //    }

        //    Debug.DrawLine(ray.origin, hit.point);
        //}
    }
}