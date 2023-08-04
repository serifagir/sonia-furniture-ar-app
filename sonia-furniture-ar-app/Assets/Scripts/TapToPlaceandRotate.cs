using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceandRotate : MonoBehaviour
{
    [SerializeField] private ColorManager _colorManager; // ColorManager scriptini içeren örnek deðiþken
    [SerializeField] private ARRaycastManager arrayman; // AR Raycast Manager bileþeni
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject InstantiatedFurniture; // Oluþturulan mobilya nesnesi

    private float rotationSpeed = 5f; // Mobilyayý döndürme hýzý
    private Vector2 rotationTouchStartPosition; // Döndürme dokunma baþlangýç konumu

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position; // Ýlk dokunma noktasýný al
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        // Eðer dokunulan noktada bir AR düzlemi varsa
        if (arrayman.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose; // Düzlemdeki noktanýn konumu ve rotasyonu

            if (InstantiatedFurniture == null)
            {
                // Eðer henüz mobilya nesnesi oluþturulmamýþsa, mobilyayý oluþtur
                InstantiatedFurniture = Instantiate(_colorManager.furniturePrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                // Eðer mobilya nesnesi zaten oluþturulmuþsa, önceki nesneyi yok et ve yeni nesneyi oluþtur
                Destroy(InstantiatedFurniture);
                InstantiatedFurniture = Instantiate(_colorManager.furniturePrefab, hitPose.position, hitPose.rotation);
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunma baþladýðýnda ilk dokunma noktasýný kaydedin
                rotationTouchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Dokunma hareket ederken mobilyayý y ekseni etrafýnda döndürün
                float rotationAmount = (rotationTouchStartPosition.x - touch.position.x) * rotationSpeed * Time.deltaTime;
                _colorManager.furniturePrefab.transform.Rotate(0, rotationAmount, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Dokunma bittiðinde dönme durdurun (Bu kýsýmda bir þey yapýlmamýþ)
            }
        }
    }
}
