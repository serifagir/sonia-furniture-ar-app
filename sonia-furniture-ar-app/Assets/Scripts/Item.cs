using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(fileName = "Item1", menuName = "AddItem/Item")]

// mobilya nesnesinin içinde saklanan değerler
// her bir instance oluşturulurken buna göre oluşturulur.
public class Item : ScriptableObject
{
    public float price;
    public GameObject itemPrefab;
    public Sprite itemImage;
    public string message;
}