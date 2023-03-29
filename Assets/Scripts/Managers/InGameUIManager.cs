using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] RectTransform healthBar;
    
    public void UpdateHealth(float healthPercent)
    {
        healthBar.localScale = new Vector3(healthPercent / 100, healthBar.localScale.y, healthBar.localScale.z);
    }

}
