using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button spawnButton;
    [SerializeField] private RawImage buttonImage;
    private int _itemId;
    [SerializeField] private Sprite _buttonImage;
    
    /*
     ---SET VE GET NE İŞE YARAR---
         Set ve Get metotlarını birer kontrol mekanizması olarak düşünebiliriz. Olası problemleri önlemek, işlemleri güvenilir ve kontrollü bir şekilde gerçekleştirmek için Set ve Get metotlarını kullanırız.
        Basit bir senaryo üzerinden konumuzu açıklamaya devam edelim. Otel otomasyonu için müşteri bilgilerini tutan bir sınıf tasarladığımızı düşünelim. Müşterinin ad-soyad, TC kimlik numarası ve oda numarası bilgilerini tutmak istiyorsak aşağıdaki gibi bir tasarım yapabiliriz.
        Musteri sınıfının üyeleri public olarak bildirildiği için bu üyelere doğrudan erişilip değerler atanabilir. İşte bu noktada kontrolü elimize almamız lazım aksi taktirde TC kimlik numarası eksik/fazla girilebilir veya 120 odalı bir otelde oda numarası negatif veya 120’den büyük girilebilir. Amacımız dikkatsizlik sonucu yaşanabilecek olası sorunların önüne geçmek. Bu yüzden üyelere doğrudan erişimi engelleyip (Private), Get ve Set metotları ile kontrollü bir erişim sağlayacağız.
     */
    
    public int ItemId //itemId bir değişken, başka script dosyalarında itemId değişkenini kullanabilmek için set keywordunu kullandık. value değeri c# ın bir özelliği oraya başka bir  scriptte furniture id değeri gelecek
    {
        set // _itemdId değişkeni bir global değişken (diğer bir adıyla public)
        {
            _itemId = value;
        }
    }
    
    public Sprite ButtonTexture //buttonlarda ürün fotoğrafını göstermek için tanımladığımız sprite değişkeni,
    {
        set
        {
            _buttonImage = value;
            buttonImage.texture = _buttonImage.texture;
        }
    }
    
    void Start()
    {
        spawnButton = GetComponent<Button>();  // yerleştirme butonu değişkeni button komponentini okuyacak.
        spawnButton.onClick.AddListener(SelectObject); // spawnbutton a tıklandığında SelectObject fonksiyonu dinlenecek, eğer obje seçilmişse yerleştirilecek.
    }


    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))  //SelectionPoint (kaydırmalı ui de mobilya seçmemizi sağlayan nokta, bir mobilya fotoğrafı selection pointin içine girerse fotoğraf 1.3 katına büyüyecek. )
        {
            transform.localScale = Vector3.one * 1.3f;
        }
        else
        {
            transform.localScale = Vector3.one; //eğer alanda değilse büyüklüğü 1 katına çıkacak yani bir değişme olmayacak
        }
    }

    void SelectObject()
    {
        DataManager.Instance.SetFurniture(_itemId); //Data manager den mobilya verisi alma fonksiyonu. detaylı bilgi DataManager scriptinde
    }
}