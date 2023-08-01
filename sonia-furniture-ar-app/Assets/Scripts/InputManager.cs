using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputManager : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private GameObject spawnedFurniture;
    [SerializeField] private Camera arCam;
    [SerializeField] private GameObject crosshair;
    private Touch touch;
    private Pose pose;
    private Vector2 touchPosition;
    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        CrosshairCalculation();
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (IsPointerOverUI(touch)) return;

        Instantiate(DataManager.Instance.GetFurniture(), pose.position, pose.rotation);
    }

    bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
        Ray ray = arCam.ScreenPointToRay(origin);
        if (arRaycastManager.Raycast(ray, _hits))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);

        }
    }
}