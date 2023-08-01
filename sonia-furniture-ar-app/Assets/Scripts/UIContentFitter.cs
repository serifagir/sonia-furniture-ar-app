using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    private HorizontalLayoutGroup _horizontalLayoutGroup;
    void Start()
    {
        _horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1;
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = _horizontalLayoutGroup.spacing * childCount + childCount * childWidth + _horizontalLayoutGroup.padding.left;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 256);
    }
}