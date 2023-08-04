using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{

    //DataManagerdeki items listi public yaptým.


    [SerializeField] private Material FurnitureColor; // Mobilyanýn rengini tutacak Material deðiþkeni
    [SerializeField] private Button color_1Button; // Renk düðmeleri
    [SerializeField] private Button color_2Button;
    [SerializeField] private Button color_3Button;
    [SerializeField] public ButtonManager buttonPrefab; // ButtonManager scriptini içeren ButtonManager örneði
    public GameObject furniturePrefab; // Mobilya prefabini tutacak GameObject deðiþkeni

    void Start()
    {
        // Herhangi bir baþlangýç iþlemi yok
    }

    void Update()
    {
        ColorChange(); // Her güncellemede mobilyanýn rengini deðiþtiren fonksiyonu çaðýr
    }

    private void ColorChange()
    {
        furniturePrefab = DataManager.Instance.GetFurniture(); // DataManager.Instance.GetFurniture() ile mobilya prefabini al
        // Eðer mobilya prefabý bulunduysa, mobilyanýn rengini deðiþtir, yoksa renk düðmelerini gizle
        if (furniturePrefab != null)
        {
            FurnitureColor = furniturePrefab.GetComponent<Material>();
            SelectFurniture(); // Mobilyanýn rengini deðiþtir
        }
        else
        {
            HideButtons(); // Renk düðmelerini gizle
        }
    }

    void HideButtons()
    {
        // Renk düðmelerini etkileþim dýþý býrak ve görünmez yap
        color_1Button.interactable = false;
        color_1Button.gameObject.SetActive(false);

        color_2Button.interactable = false;
        color_2Button.gameObject.SetActive(false);

        color_3Button.interactable = false;
        color_3Button.gameObject.SetActive(false);
    }

    void SelectFurniture()
    {
        // DataManager.Instance.items listesindeki mobilyalarý kontrol et ve mobilyanýn rengini deðiþtir
        foreach (Item item in DataManager.Instance.items)
        {
            if (item.itemPrefab.name == furniturePrefab.name)
            {
                color_1Button.image.color = item.Color_1;
                color_2Button.image.color = item.Color_2;
                color_3Button.image.color = item.Color_3;

                FurnitureColor.color = item.Color_1; // Mobilyanýn rengini "Color_1" rengiyle deðiþtir

                // Renk düðmelerini etkileþime aç ve görünür yap
                color_1Button.interactable = true;
                color_1Button.gameObject.SetActive(true);

                color_2Button.interactable = true;
                color_2Button.gameObject.SetActive(true);

                color_3Button.interactable = true;
                color_3Button.gameObject.SetActive(true);
            }
        }
    }

    // Renk düðmelerine basýldýðýnda mobilyanýn rengini deðiþtiren fonksiyonlar
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
