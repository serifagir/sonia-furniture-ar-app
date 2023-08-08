using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//Sema Nur


public class UrünYerleştirme : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject furniturePrefab;
    List<ARRaycastHit> hit = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (IsHorizontalPlane(hit.transform))
                    {
                        Pose planePose = new Pose(hit.point, hit.transform.rotation);
                        Instantiate(furniturePrefab, planePose.position, planePose.rotation);
                    }
                }
            }
        }
    }

    bool IsHorizontalPlane(Transform planeTransform)
    {
        Vector3 planeUp = planeTransform.up;
        return Mathf.Abs(planeUp.y) > 0.9f; // değiştirilebilr
    }
}
