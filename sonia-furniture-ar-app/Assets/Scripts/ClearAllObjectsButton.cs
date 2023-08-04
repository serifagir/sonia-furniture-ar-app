using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllObjectsButton : MonoBehaviour
{
    public void ClearAllObjects()
    {
        // Sahnedeki b�t�n objeleri bul ve sil
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
           
            Destroy(obj);
        }
    }
}
