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
    
    [SerializeField] Animator inGameUIController;

    public void UpdateHealth(float healthPercent)
    {
        healthBar.localScale = new Vector3(healthPercent / 100, healthBar.localScale.y, healthBar.localScale.z);
    }

    public void PlayDanger()
    {
        inGameUIController.Play("DangerFade");
    }
}
