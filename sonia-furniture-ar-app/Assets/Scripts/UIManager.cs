using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private GraphicRaycaster _graphicRaycaster;
    public Transform selectionPoint;
    private PointerEventData _pointerEventData;
    private EventSystem _eventSystem;
    public static UIManager instance;
  

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    void Start()
    {
        _graphicRaycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
        _pointerEventData = new PointerEventData(_eventSystem);
        _pointerEventData.position = selectionPoint.position;
    }


  
    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(_pointerEventData,results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            }
        }

        return false;
    }
}