using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItem : MonoBehaviour
{
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private TextMeshProUGUI m_NameText;
    [SerializeField]
    private TextMeshProUGUI m_ColorText;
    [SerializeField]
    private Button m_PurchaseButton;
    public Button PurchaseButton
    {
        get
        {
            return m_PurchaseButton;
        }
    }
    private GameObject m_Object;
    public GameObject ItemObject
    {
        get
        {
            return m_Object;
        }
    }

}
