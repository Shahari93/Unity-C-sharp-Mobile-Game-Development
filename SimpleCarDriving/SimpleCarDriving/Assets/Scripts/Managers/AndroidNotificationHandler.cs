using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string channelId = "ChannelID";

    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel androidNotificationChannel = new AndroidNotificationChannel
        {
            Id = channelId,
            Name = "notification channel",
            Description = "notification description",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);


        AndroidNotification androidNotification = new AndroidNotification
        {
            Title = "Energy Recharged!",
            Text = "Your energy has recharged",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime
        };

        AndroidNotificationCenter.SendNotification(androidNotification, channelId);
    }
#endif
}
