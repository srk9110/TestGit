using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIBinder_Mission : MonoBehaviour
{


    public int id;
    public Button btn;
    public Text textDone;
    public Text textGoal;
    public Text txtBtnName;
    public UnityAction<int> OnClick;

    public void Init(int id, string btnName, int goal, int done)
    {

        this.id = id;
        this.txtBtnName.text = btnName;
        this.textGoal.text = goal.ToString();
        this.textDone.text = done.ToString();

        this.btn.onClick.AddListener(() =>
        {
            this.OnClick(this.id);
        });
    }

    public void UpdateUI(int done)
    {
        this.textDone.text = done.ToString();
    }
}
