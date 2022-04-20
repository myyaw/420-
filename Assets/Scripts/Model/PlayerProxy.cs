using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;

public class PlayerProxy : Proxy
{
    public new const string NAME = "PlayerProxy";
    //1.继承Proxy父类
    //2.写我们的构造函数

    //写构造函数
    //重要点
    //1.代理的名字！！！！
    //2.代理相关的数据！！！！！

    public PlayerProxy():base(PlayerProxy.NAME)
    {
        //在构造函数中 初始化一个数据 进行关联
        PlayerData data = new PlayerData();

        //初始化
        data.nowtime = PlayerPrefs.GetString("nowtime", DateTime.Now.ToString());
        

        //赋值给自己的Data进行关联
        Data = data;
    }

    public void TimeUp()
    {
        PlayerData data = Data as PlayerData;

        //时间更新
        data.nowtime =DateTime.Now.ToString();
        
        
    }

    public void SaveData()
    {
        PlayerData data = Data as PlayerData;
        //把这些数据内容 存储到本地
        PlayerPrefs.SetString("nowtime", data.nowtime);
       
    }
}
