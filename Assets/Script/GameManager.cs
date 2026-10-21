using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private PackageTable packageTable;

    public static GameManager Instance
    {
        get
        {
            if (null == _instance)
            {
                GameObject obj = new GameObject("GameManager");
                _instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
    }

    // 获取背包表格
    public PackageTable GetPackageTable()
    {
        if (null == packageTable)
        {
            packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        }
        return packageTable;
    }

    // 获取背包本地数据
    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();
    }

    /// <summary>
    /// 获取背包静态数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PackageTableItem GetPackageItemById(int id)
    {
        List<PackageTableItem> packageDataList = GetPackageTable().DataList;
        foreach (PackageTableItem item in packageDataList)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取背包动态数据
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public PackageLocalItem GetPackageLocalItemByUId(string uid)
    {
        List<PackageLocalItem> packageDataList = GetPackageLocalData();
        foreach (PackageLocalItem item in packageDataList)
        {
            if (item.uid == uid)
            {
                return item;
            }
        }
        return null;
    }
     public List<PackageLocalItem> GetSortPackageLocalData()
    {
        // 获取原始数据
        List<PackageLocalItem> originalData = GetPackageLocalData();
        
        // 创建排序后的列表
        List<PackageLocalItem> sortedData = new List<PackageLocalItem>(originalData);

        // 引用自定义比较器
        sortedData.Sort(new PackageItemComparer());

        return sortedData;
    }
}

// 背包物品比较器
public class PackageItemComparer : IComparer<PackageLocalItem>
{
    public int Compare(PackageLocalItem a, PackageLocalItem b)
    {
        PackageTableItem x = GameManager.Instance.GetPackageItemById(a.id);
        PackageTableItem y = GameManager.Instance.GetPackageItemById(b.id);
        // 先按 star 从大到小排序
        int starComparison = y.star.CompareTo(x.star);

        // 如果 star 相同, 则按id从大到小排序
        if (0 == starComparison)
        {
            int idComparison = y.id.CompareTo(x.id);
            // 同种物品按等级排序
            if (idComparison == 0)
            {
                return b.level.CompareTo(a.level);
            }
            return idComparison;
        }
        return starComparison;
    }

}