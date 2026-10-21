using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    private static UIManager _instance;

    private static Transform _uiRoot;
    
    private Dictionary<string, string> pathDict;
    
    private Dictionary<string, GameObject> prefabDict;
    
    private Dictionary<string, BasePanel> panelDict;

    public static UIManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    public static Transform UIRoot
    {
        get
        {
            if(null == _uiRoot)
            {
                GameObject canvasObject = GameObject.Find("Canvas");
                if (null != canvasObject)
                {
                    _uiRoot = canvasObject.transform;
                }
                else
                {
                    canvasObject = new GameObject("Canvas");
                    
                    Canvas canvas = canvasObject.AddComponent<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                    
                    canvasObject.AddComponent<GraphicRaycaster>();
                    

                    _uiRoot = canvas.transform;
                }
            }
            return _uiRoot;
        }
    }
    private UIManager()
    {
        InitDicts();
    }

    private void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        pathDict = new Dictionary<string, string>()
        {
            {UIConst.PackagePanel, "Package/PackagePanel"},
        };
    }

    // 
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // 
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("�����Ѵ�" + name);
            return null;
        }

        // 
        string path = "";
        if (!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("�������ƴ���,����δ����:" + name);
            return null;
        }

        // 
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realPath = "Prefabs/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath);
            prefabDict.Add(name, panelPrefab);
        }

        // 
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        return panel;
    }
     
    /// <summary>
    /// 关闭界面 删除缓存
    /// </summary>
    /// <param name="name">界面名称</param>
    /// <returns></returns>
    public bool ClosePanel(string name)
    {
        // 检查是否打开
        BasePanel panel = null;
        if(!panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("未找到: " + name);
            return false;
        }

        panel.ClosePanel();

        // 去除缓存 (类似去除空指针)
        if (panelDict.ContainsKey(name))
        {
            panelDict.Remove(name);
        }
        return true;
    }
}

public class UIConst
{
    // 
    public const string PackagePanel = "PackagePanel";
}
