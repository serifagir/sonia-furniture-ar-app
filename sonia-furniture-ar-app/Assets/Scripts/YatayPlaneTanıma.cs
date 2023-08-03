using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//Sema Nur

public class YatayPlaneTanıma : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;

    public GameObject furniturePrefab; //ya da models kullanılabilir

    // Start is called before the first frame update
    void Start()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    // Update is called once per frame
    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            if (IsHorizontalPlane(plane.size))
            {
                Vector3 planePosition = plane.transform.position;
                Quaternion planeRotation = plane.transform.rotation;

                GameObject furniture = Instantiate(furniturePrefab, planePosition, planeRotation);

                Vector3 furnitureScale = new Vector3(plane.size.x, plane.size.y);
                furniture.transform.localScale = furnitureScale;

            }
        }
    }

    bool IsHorizontalPlane(Vector3 size)
    {
        float width = size.x;
        float height = size.y;

        if (width > height)
        {
            return true;
        }

        return false;
    }
}
