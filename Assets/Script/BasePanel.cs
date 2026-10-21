using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{

    protected new string name;
    protected bool isRemove = false;

    protected virtual void Awake()
    {
        
    }

    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public virtual void OpenPanel(string name)
    {
        this.name = name;
        gameObject.SetActive(true);
    }

    public virtual void ClosePanel()
    {
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
