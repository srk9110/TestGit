using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class InGame : MonoBehaviour
{
    public UIInGame uiInGame;

    public void Init()
    {
        this.uiInGame = GameObject.FindObjectOfType<UIInGame>();

        Debug.Log("InGame: Init");
        this.uiInGame.Init();
        for (int i = 0; i < this.uiInGame.arrUiBinderMission.Length; i++)
        {
            var uiBinderMission = this.uiInGame.arrUiBinderMission[i];
            var idx = i;


            uiBinderMission.OnClick = (id) =>
            {
                InfoManager.GetInstance().DoMission(id, 1);

                //info변경이 없으면 ui업데이트를 안함
                this.uiInGame.UpdateUI();

            };

        }
        this.uiInGame.btnSave.onClick.AddListener(() =>
        {
            GameInfo gameInfo = InfoManager.GetInstance().gameInfo;
            string json = JsonConvert.SerializeObject(gameInfo);
            File.WriteAllText(Application.persistentDataPath + "/gameInfo.json", json);
            Debug.Log(json);
            Debug.Log("save");
        });
    }

}
