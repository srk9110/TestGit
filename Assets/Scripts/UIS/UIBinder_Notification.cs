using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIBinder_Notification : MonoBehaviour
{
    private int mailCount;   //0보다 커야 보여줌
    public GameObject mailCountGo;
    public Text txtMailCount;


    public void Init(int mailCount)
    {
        this.mailCount = mailCount;

        if(this.mailCount==0)
        {
            this.Hide();
        }

        else
        {
            this.Show();
        }

    }

    public void Show()
    {
        this.mailCountGo.SetActive(true);
        this.txtMailCount.gameObject.SetActive(true);
        this.txtMailCount.text = this.mailCount.ToString();
    }

    public void Hide()
    {
        this.mailCountGo.SetActive(false);
        this.txtMailCount.gameObject.SetActive(false);
    }

}
