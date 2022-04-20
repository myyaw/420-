using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panela : MonoBehaviour
{
    public Button btn;
    public Text text;

    
    void Start()
    {
        text.text =System.DateTime.Now.ToString();
        btn.onClick.AddListener(()=>{
            text.text =System.DateTime.Now.ToString();
        });
    }
    
    public void UpdateInfo(PlayerData data)
    {
       
        text.text = data.ToString();
         Debug.Log(2);
    }
}
