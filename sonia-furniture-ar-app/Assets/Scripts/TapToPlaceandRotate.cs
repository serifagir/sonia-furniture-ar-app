using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceandRotate : MonoBehaviour
{
    [SerializeField] private ColorManager _colorManager; // ColorManager scriptini i�eren �rnek de�i�ken
    [SerializeField] private ARRaycastManager arrayman; // AR Raycast Manager bile�eni
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject InstantiatedFurniture; // Olu�turulan mobilya nesnesi

    private float rotationSpeed = 5f; // Mobilyay� d�nd�rme h�z�
    private Vector2 rotationTouchStartPosition; // D�nd�rme dokunma ba�lang�� konumu

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position; // �lk dokunma noktas�n� al
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        // E�er dokunulan noktada bir AR d�zlemi varsa
        if (arrayman.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose; // D�zlemdeki noktan�n konumu ve rotasyonu

            if (InstantiatedFurniture == null)
            {
                // E�er hen�z mobilya nesnesi olu�turulmam��sa, mobilyay� olu�tur
                InstantiatedFurniture = Instantiate(_colorManager.furniturePrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                // E�er mobilya nesnesi zaten olu�turulmu�sa, �nceki nesneyi yok et ve yeni nesneyi olu�tur
                Destroy(InstantiatedFurniture);
                InstantiatedFurniture = Instantiate(_colorManager.furniturePrefab, hitPose.position, hitPose.rotation);
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunma ba�lad���nda ilk dokunma noktas�n� kaydedin
                rotationTouchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Dokunma hareket ederken mobilyay� y ekseni etraf�nda d�nd�r�n
                float rotationAmount = (rotationTouchStartPosition.x - touch.position.x) * rotationSpeed * Time.deltaTime;
                _colorManager.furniturePrefab.transform.Rotate(0, rotationAmount, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Dokunma bitti�inde d�nme durdurun (Bu k�s�mda bir �ey yap�lmam��)
            }
        }
    }
}
