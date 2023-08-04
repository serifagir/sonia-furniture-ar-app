using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Data Manager ve kayd�rmal� men�de se�ili objenin a��klamas�n� metin kutusuna atamaya dayal� bir sistem. Kayd�rmal� men�y�
//kullanamad���m i�in test edemedim.



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
            
            string selectedMessage = DataManager.Instance.GetSelectedMessage(); // Se�ilen mobilyan�n mesaj�n� al
            displayText.text = selectedMessage; // Mesaj� metin kutusuna yazd�r
        }
        else
        {
            displayText.text = "DataManager not found!";
        }
    }
}
