using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    private int m_CurSelectedIdx;
    private ItemInfo m_CurSelectedItem;
    [SerializeField]  private Button m_PurchaseButton;
    [SerializeField]  private Image m_ItemIcon;
    [SerializeField]  private TextMeshProUGUI m_ItemName;
    [SerializeField]  private TextMeshProUGUI m_ItemDetails;
    [SerializeField] private Transform m_Parent;

    private void Start()
    {
        UpdateItemDetails();
    }

    public void NextItem()
    {
        m_CurSelectedIdx ++;
        UpdateItemDetails();
    }

    public void PrevItem()
    {
        m_CurSelectedIdx--;
        UpdateItemDetails();
    }

    public void UpdateItemDetails()
    {
        var itemList = ItemDatabase.Instance.ItemList;
        if (m_CurSelectedIdx < 0)
            m_CurSelectedIdx = itemList.Count - 1;
        else if (m_CurSelectedIdx == itemList.Count)
            m_CurSelectedIdx = 0;

        m_CurSelectedItem = itemList[m_CurSelectedIdx];

        m_ItemIcon.sprite = m_CurSelectedItem.m_Thumbnail;
        m_ItemName.text = m_CurSelectedItem.m_Name;
        m_ItemDetails.text = "Quality : \n" + m_CurSelectedItem.m_Qaulity.ToString() + "\n\n" + 
            "Interactable : \n" + (m_CurSelectedItem.m_Interactable?"Yes":"No") + "\n\n" + 
            "Price : \n" + "$ " + m_CurSelectedItem.m_Price;

        m_PurchaseButton.interactable = m_CurSelectedItem.m_Object != null;
        //if(m_CurSelectedItem.m_Object !)
    }

    public void OnPurchaseButtonClicked()
    {
        // send purchasing id to server simulatr
        ServerSimulator.Instance.OnPurchase(m_CurSelectedIdx, gameObject, "OnPurchase");
        m_PurchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = ". . .";
    }

    void OnPurchase(string json)
    {
        var purchasedData = JsonUtility.FromJson<PurchaseData>(json);
        if (purchasedData.statusCode == 200)
        {
            var iteminfo = ItemDatabase.Instance.ItemList[purchasedData.purchasedId];

            if (iteminfo.m_Object)
            {
                Vector3 vRandomPos = new Vector3(Random.Range(-2, 2), 0, Random.Range(-0.5f, 0.5f));
                GameObject go = Instantiate(iteminfo.m_Object, vRandomPos, Quaternion.identity);
                go.GetComponent<VRMover>()._ParentObject = m_Parent;
            }
        }
        m_PurchaseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchase";
    }

    public void ToggleView()
    {
       gameObject.SetActive(!gameObject.activeSelf);
    }

}
