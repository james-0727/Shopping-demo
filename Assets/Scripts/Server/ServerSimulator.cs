
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class ServerSimulator : MonoBehaviour
{
    private static ServerSimulator m_Instance;
    public static ServerSimulator Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        m_Instance = GetComponent<ServerSimulator>();
    }

    public void OnPurchase( int idx, GameObject callback, string sendto )
    {
        StartCoroutine(Respond(idx, callback, sendto));
    }

    IEnumerator Respond(int idx, GameObject callback, string sendto)
    {
        yield return new WaitForSeconds(1); 
        PurchaseData purchaseData = new PurchaseData();
        purchaseData.statusCode = 200;
        purchaseData.purchasedId = idx;
        callback.SendMessage(sendto, JsonUtility.ToJson(purchaseData));
    }
}
