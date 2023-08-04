using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Data Manager ve kaydýrmalý menüde seçili objenin açýklamasýný metin kutusuna atamaya dayalý bir sistem. Kaydýrmalý menüyü
//kullanamadýðým için test edemedim.



public class TextManager : MonoBehaviour
{
    [SerializeField] private Text displayText;

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (DataManager.Instance != null)
        {
            
            string selectedMessage = DataManager.Instance.GetSelectedMessage(); // Seçilen mobilyanýn mesajýný al
            displayText.text = selectedMessage; // Mesajý metin kutusuna yazdýr
        }
        else
        {
            displayText.text = "DataManager not found!";
        }
    }
}
