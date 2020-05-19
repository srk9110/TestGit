using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    public Button btn;
    public Image icon;
    public Text btnName;
    //public UnityAction<int> OnClick;
    //private int idx;


    private void Awake()
    {
        //this.btn.onClick.AddListener(() =>
        //{
        //    this.OnClick(this.idx);
        //});
    }

    //public void Init(int idx, Sprite icon, string btnName)
    //{
    //    this.idx = idx;
    //    this.icon.sprite = icon;
    //    this.btnName.text = btnName;
    //}

    public void Init( Sprite icon, string btnName)
    {
        
        this.icon.sprite = icon;
        this.btnName.text = btnName;
    }
}
