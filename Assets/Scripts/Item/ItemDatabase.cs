using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEditor;

[CreateAssetMenu(fileName = "ItemDatabase.asset", menuName = "Databases/Item Database")]
public class ItemDatabase : ScriptableObject
{
    #region singleton
    private static ItemDatabase m_Instance;
    public static ItemDatabase Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = Resources.Load("Database/ItemDatabase") as ItemDatabase;
            return m_Instance;
        }
    }
    #endregion
    public List<ItemInfo> ItemList;
}