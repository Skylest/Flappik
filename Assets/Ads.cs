using UnityEngine;

public class Ads : MonoBehaviour
{
    /*private int restartCnt = 0;
    private string appKey = "5356658";
    public menu_controller menuController;

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }

    void Start()
    {
        menuController.restartEvent += Restart;
        IronSource.Agent.init(appKey, IronSourceAdUnits.INTERSTITIAL);
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
    }

    private void SdkInitializationCompletedEvent() {
        IronSource.Agent.loadInterstitial();
        Debug.Log("interstisial load");
    }

    public  void Restart()
    {
        if (restartCnt > 8 && IronSource.Agent.isInterstitialReady())
        {

           IronSource.Agent.showInterstitial();
           restartCnt = 0;
        }
        else
        {
            restartCnt++;
        }
    }*/
}
