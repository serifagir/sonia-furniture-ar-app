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
    
    public int ItemId
    {
        set
        {
            _itemId = value;
        }
    }
    
    public Sprite ButtonTexture
    {
        set
        {
            _buttonImage = value;
            buttonImage.texture = _buttonImage.texture;
        }
    }
    
    void Start()
    {
        spawnButton = GetComponent<Button>();
        spawnButton.onClick.AddListener(SelectObject);
    }


    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.localScale = Vector3.one * 1.3f;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
        DataManager.Instance.SetFurniture(_itemId);
    }
}