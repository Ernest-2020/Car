using Profile;
using Tools;
using UnityEngine.Advertisements;

public class ProfilePlayer
{
    public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        AnaliticsTools = new UnityAnaliticsTools();
        AdsShower = unityAdsTools;
        AdsListener = unityAdsTools;
    }

    public SubscriptionProperty<GameState> CurrentState { get; }

    public Car CurrentCar { get; }

    public IAnaliticsTools AnaliticsTools { get; }

    public IAdsShower AdsShower { get; }

    public IUnityAdsListener AdsListener { get; }
}

