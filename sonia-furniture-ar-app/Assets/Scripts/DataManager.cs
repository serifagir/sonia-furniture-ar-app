using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Collections;
using UnityEngine.UI;


/*
 * ---Instance---
 * Instance, obje tabanlı programlama dillerinde karşımıza çıkan bir kavram. Programın içinde bir obje oluşturma işlemi instance olarak tanımlanır.
 * örnek
 *
 * ____________________
 * | Mobilya id= 0     |
 * | ürün fotosu       |    soldaki gibi mobilya id= 1, 2, 3 diye programlama nesneleri oluşturmaya instance denir.
 * | ürün modeli       |
 * | ürün fiyatı       |  
 * |___________________|
 */
public class DataManager : MonoBehaviour
{
    private GameObject furniture; //yerleştirilecek mobilya 

    [SerializeField] public ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] public List<Item> items;
    
    private int selectedItemId = -1;

    private string selectedMessage = "Secili Mobilya Yok"; // Başlangıçta seçili bir mobilya mesajı olmadığını belirtmek için boş bir string.

    
    private int current_id = 0; //her bir mobilyanın (instance) başlama idsi, mobilyalara 0 dan başlanılarak idler verilecek.

    private static DataManager instance;// instance kavramı yukarıda
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();   // bahsettiğimiz kavram, burada data managerden yeni objeler oluşturuluyor.
            }

            return instance;
        }
    }

    private void Start()
    { 
        LoadItems();
        CreateButton();
        
        SetSelectedMessage(selectedMessage);

        GetSelectedMessage(); 
    }

    void LoadItems() //itemleri yüklemeye yarayan fonksiyon, şu anda resources klasöründen çekiyor, daha sonra web serverdan veya clouddan çekecek bknz. Addressables
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
    }

    void CreateButton() //çekilen mobilyalar için her birine uygun fotoğraflı buttonlar hazırlayan fonksiyon
    {
        foreach (Item i  in items)
        {
            ButtonManager button = Instantiate(buttonPrefab, buttonContainer.transform); // buton oluşturma
            button.ItemId = current_id;
            button.ButtonTexture = i.itemImage; // ürün görseli
            current_id++; //id ler arta arta gidiyor.
        }
    }

    public void SetFurniture(int id) //mobilyanın idsine göre ürün prefabı çekmeye yarayan fonksiyon
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture() // mobilya değerleri okuma yapabilmek ve yerleştirme yapabilmek için furniture game objectini döndüren fonksiyon
    {
        return furniture;
    }
    
    
    public string GetSelectedMessage()
    {
        return selectedMessage;
    }

    public void SetSelectedMessage(string message)
    {
        selectedMessage = message;
    }


}