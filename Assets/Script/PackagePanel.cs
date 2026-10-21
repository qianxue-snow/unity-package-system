using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackagePanel : BasePanel
{
    private Transform UIMenu;
    private Transform UIMenuWeapon;
    private Transform UIMenuFood;
    private Transform UITabName;
    private Transform UICloseBtn;
    private Transform UICenter;
    private Transform UIScrollView;
    private Transform UIDetailPanel;
    private Transform UILeftBtn;
    private Transform UIRightBtn;
    private Transform UIDeletePanel;
    private Transform UIDeleteBackBtn;
    private Transform UIDeleteInfoText;
    private Transform UIDeleteConfirmBtn;
    private Transform UIBottomMenus;
    private Transform UIDeleteBtn;
    private Transform UIDetailBtn;

    public GameObject PackageUIItemPrefab;

    private string _chooseUid;
    public string chooseUid
    {
        set
        {
            _chooseUid = value;
            RefreshDetail();
        }
        get
        {
            return _chooseUid;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void Start()
    {
        RefreshUI();
    }
    private void InitUI()
    {
        InitUIName();
        InitClick();
    }

    private void RefreshUI()
    {
        RefreshScroll();
    }
    
    private void RefreshDetail()
    {
        // 找到uid对应的动态数据
        PackageLocalItem localItem = GameManager.Instance.GetPackageLocalItemByUId(chooseUid);
        // 刷新详情界面
        UIDetailPanel.GetComponent<PackageDetail>().Refresh(localItem, this);
    }
    private void RefreshScroll()
    {
 
        // 清除滚动容器中原有的物品
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        for (int i = 0; i < scrollContent.childCount; i++)
        {
            Destroy(scrollContent.GetChild(i).gameObject);
        }
        // 加载现有的物品
        foreach (PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
        {
            Transform PackageUIItem = Instantiate<Transform>(PackageUIItemPrefab.transform, scrollContent);
            PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            if (packageCell == null)
            {
                packageCell = PackageUIItem.gameObject.AddComponent<PackageCell>();
            }
            packageCell.Refresh(localData, this);
        }
    }

    private void InitUIName()
    {
        

        UIMenu = transform.Find("TopCenter/Menu");
        UIMenuWeapon = transform.Find("TopCenter/Menu/Weapon");
        UIMenuFood = transform.Find("TopCenter/Menu/Food");
        UITabName = transform.Find("LeftTop/Tab/TabName");
        UICloseBtn = transform.Find("RightTop/CloseBtn");
        UICenter = transform.Find("Center");
        UIScrollView = transform.Find("Center/Scroll View");
        UIDetailPanel = transform.Find("Center/DetailPanel");
        UILeftBtn = transform.Find("Left/LeftBtn");
        UIRightBtn = transform.Find("Right/RightBtn");

        UIDeletePanel = transform.Find("Bottom/DeletePanel");
        UIDeleteBackBtn = transform.Find("Bottom/DeletePanel/Back");
        UIDeleteInfoText = transform.Find("Bottom/DeletePanel/InfoText");
        UIDeleteConfirmBtn = transform.Find("Bottom/DeletePanel/ConfirmBtn");
        UIBottomMenus = transform.Find("Bottom/BottomMenu");
        UIDeleteBtn = transform.Find("Bottom/BottomMenu/DeleteBtn");
        UIDetailBtn = transform.Find("Bottom/BottomMenu/DetailBtn");
        
        UIDeletePanel.gameObject.SetActive(false);
        UIBottomMenus.gameObject.SetActive(true);
    }

    private void InitClick()
    {
        UIMenuWeapon.GetComponent<Button>().onClick.AddListener(OnClickWeapon);
        UIMenuFood.GetComponent<Button>().onClick.AddListener(OnClickFood);
        UICloseBtn.GetComponent<Button>().onClick.AddListener(OnClickClose);
        UILeftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
        UIRightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);
        UIDeleteBackBtn.GetComponent<Button>().onClick.AddListener(OnDeleteBack);
        UIDeleteConfirmBtn.GetComponent<Button>().onClick.AddListener(OnDeleteConfirm);
        UIDeleteBtn.GetComponent<Button>().onClick.AddListener(OnDelete);
        UIDetailBtn.GetComponent<Button>().onClick.AddListener(OnDetail);
    }

    /// <summary>
/// 显示物品详细信息面板
/// </summary>
private void OnDetail()
    {
        throw new NotImplementedException();
    }

    private void OnDelete()
    {
        throw new NotImplementedException();
    }

    private void OnDeleteConfirm()
    {
        throw new NotImplementedException();
    }

    private void OnDeleteBack()
    {
        throw new NotImplementedException();
    }

    private void OnClickRight()
    {
        throw new NotImplementedException();
    }

    private void OnClickLeft()
    {
        throw new NotImplementedException();
    }

    private void OnClickClose()
    {
        print(">>>> OnClickClose");
        UIManager.Instance.ClosePanel(UIConst.PackagePanel);
    }

    private void OnClickFood()
    {
        throw new NotImplementedException();
    }

    private void OnClickWeapon()
    {
        throw new NotImplementedException();
    }
}
