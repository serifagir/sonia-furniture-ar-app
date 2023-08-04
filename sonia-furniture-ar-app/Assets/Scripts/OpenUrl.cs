using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public void Openurl(string UrlName)
    {
        Application.OpenURL(UrlName);
    }


}
