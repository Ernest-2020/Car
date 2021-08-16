using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;

public class NotificationView : MonoBehaviour
{
    private const string AndroidNotificationId = "android_notification_id";

    [SerializeField]
    private Button _showNotificationButton;

    private void Start()
    {
        _showNotificationButton.onClick.AddListener(CreateNotification);
    }

    private void OnDestroy()
    {
        _showNotificationButton.onClick.RemoveAllListeners();
    }

    private void CreateNotification()
    {
#if UNITY_ANDROID
        CreateNotificationAndroid();
#elif UNITY_IOS
        CreateNotificationIOS();
#endif
    }

    private void CreateNotificationAndroid()
    {
        var androidNotificationChannel = new AndroidNotificationChannel
        {
            Id = AndroidNotificationId,
            Name = "Улучшение замка",
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);

        var androidNotification = new AndroidNotification
        {
            Color = Color.white,
            RepeatInterval = TimeSpan.FromSeconds(86400)
        };

        AndroidNotificationCenter.SendNotification(androidNotification, AndroidNotificationId);
    }

    private void CreateNotificationIOS()
    {
        var iosNotification = new iOSNotification
        {
            Identifier = "ios_notification_id",
            Title = "Награда",
            Body = "Заберите Награду",
            ForegroundPresentationOption = PresentationOption.Sound | PresentationOption.Badge,
            Data = "12/08/2021"
        };

        iOSNotificationCenter.ScheduleNotification(iosNotification);
    }
}
