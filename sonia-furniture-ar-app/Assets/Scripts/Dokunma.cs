using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sema Nur

public class Dokunma : MonoBehaviour
{
    bool isDragging = false;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = touch.position;

            if ( touch.phase == TouchPhase.Began )
            {
                Ray ray = Camera.main.ScreenPointToRay( touchPosition );
                RaycastHit hit;
                if ( Physics.Raycast( ray, out hit ) )
                {
                    if ( hit.transform == transform)
                    {
                        isDragging = true;
                        offset = hit.point - transform.position;
                    }
                }
            }
            else if ( touch.phase == TouchPhase.Moved && !isDragging )
            {
                Ray ray = Camera.main.ScreenPointToRay ( touchPosition );
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                float rayDistance;
                if(plane.Raycast( ray, out rayDistance ))
                {
                    Vector3 newPosition = ray.GetPoint(rayDistance) - offset;
                    transform.position = newPosition;
                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
