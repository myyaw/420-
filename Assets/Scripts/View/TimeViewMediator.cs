using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeViewMediator : Mediator
{
    public static new string NAME = "TimeViewMediator";
    //套路写法
    //1.继承PureMVC中的Mediator脚本 
    //2.写构造函数
    public TimeViewMediator():base(NAME)
    {

    }

    public void SetView(Panela view)
    {
        ViewComponent = view;
        //更新按钮 事件监听
        view.btn.onClick.AddListener(() =>
        {
            SendNotification(PureNotification.TIME_UP);
        });

       
    }

    //3.重写监听通知的方法
    public override string[] ListNotificationInterests()
    {
        return new string[] {
            PureNotification.TIME_UP,
            //以后你还关心别的通知 就在这后面通过逗号连接 加起来就行了
        };
    }


    //4.重写处理通知的方法
    public override void HandleNotification(INotification notification)
    {
        //INotification 对象 里面包含两个队我们来说 重要的参数
        //1.通知名 我们根据这个名字 来做对应的处理
        //2.通知包含的信息 
        switch (notification.Name)
        {
            case PureNotification.TIME_UP:
                //玩家数据更新 逻辑处理
                if(ViewComponent != null)
                {
                    (ViewComponent as Panela).UpdateInfo(notification.Body as PlayerData);
                }
                break;
        }
    }
}
