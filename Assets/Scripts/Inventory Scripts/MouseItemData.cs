using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI ItemCount;

    private void Awake()
    {
        itemSprite.color = Color.clear;
        ItemCount.text = "";
    }
}
