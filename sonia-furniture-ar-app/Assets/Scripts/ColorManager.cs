using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{

    //DataManagerdeki items listi public yapt�m.


    [SerializeField] private Material FurnitureColor; // Mobilyan�n rengini tutacak Material de�i�keni
    [SerializeField] private Button color_1Button; // Renk d��meleri
    [SerializeField] private Button color_2Button;
    [SerializeField] private Button color_3Button;
    [SerializeField] public ButtonManager buttonPrefab; // ButtonManager scriptini i�eren ButtonManager �rne�i
    public GameObject furniturePrefab; // Mobilya prefabini tutacak GameObject de�i�keni

    void Start()
    {
        // Herhangi bir ba�lang�� i�lemi yok
    }

    void Update()
    {
        ColorChange(); // Her g�ncellemede mobilyan�n rengini de�i�tiren fonksiyonu �a��r
    }

    private void ColorChange()
    {
        furniturePrefab = DataManager.Instance.GetFurniture(); // DataManager.Instance.GetFurniture() ile mobilya prefabini al
        // E�er mobilya prefab� bulunduysa, mobilyan�n rengini de�i�tir, yoksa renk d��melerini gizle
        if (furniturePrefab != null)
        {
            FurnitureColor = furniturePrefab.GetComponent<Material>();
            SelectFurniture(); // Mobilyan�n rengini de�i�tir
        }
        else
        {
            HideButtons(); // Renk d��melerini gizle
        }
    }

    void HideButtons()
    {
        // Renk d��melerini etkile�im d��� b�rak ve g�r�nmez yap
        color_1Button.interactable = false;
        color_1Button.gameObject.SetActive(false);

        color_2Button.interactable = false;
        color_2Button.gameObject.SetActive(false);

        color_3Button.interactable = false;
        color_3Button.gameObject.SetActive(false);
    }

    void SelectFurniture()
    {
        // DataManager.Instance.items listesindeki mobilyalar� kontrol et ve mobilyan�n rengini de�i�tir
        foreach (Item item in DataManager.Instance.items)
        {
            if (item.itemPrefab.name == furniturePrefab.name)
            {
                color_1Button.image.color = item.Color_1;
                color_2Button.image.color = item.Color_2;
                color_3Button.image.color = item.Color_3;

                FurnitureColor.color = item.Color_1; // Mobilyan�n rengini "Color_1" rengiyle de�i�tir

                // Renk d��melerini etkile�ime a� ve g�r�n�r yap
                color_1Button.interactable = true;
                color_1Button.gameObject.SetActive(true);

                color_2Button.interactable = true;
                color_2Button.gameObject.SetActive(true);

                color_3Button.interactable = true;
                color_3Button.gameObject.SetActive(true);
            }
        }
    }

    // Renk d��melerine bas�ld���nda mobilyan�n rengini de�i�tiren fonksiyonlar
    public void PressButton1()
    {
        FurnitureColor.color = color_1Button.image.color;
    }
    public void PressButton2()
    {
        FurnitureColor.color = color_2Button.image.color;
    }
    public void PressButton3()
    {
        FurnitureColor.color = color_3Button.image.color;
    }
}
