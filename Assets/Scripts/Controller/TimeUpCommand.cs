using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        //得到数据代理 完成后通知别人 更新数据
        PlayerProxy playerProxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;

        if( playerProxy != null )
        {
            //时间更新
            playerProxy.TimeUp();
            playerProxy.SaveData();
            //通知更新
            SendNotification(PureNotification.TIME_UP, playerProxy.Data);
        }


    }
}
