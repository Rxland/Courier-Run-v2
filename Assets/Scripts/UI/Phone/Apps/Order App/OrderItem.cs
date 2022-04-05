using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderItem : MonoBehaviour
{
    [SerializeField] public Image ProductImage;
    [SerializeField] public TextMeshProUGUI PriductText;

    [SerializeField] private Image _checkMark;

    public GlobalVaribales.ProductNames ProductType;

    public void ShowCheckMark()
    {
        _checkMark.gameObject.SetActive(true);
    }



}
