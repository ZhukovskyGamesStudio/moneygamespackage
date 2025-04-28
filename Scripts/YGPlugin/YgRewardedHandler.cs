using System;
#if UNITY_WEBGL && YG_WEBGL
using YG;
#endif
using Random = UnityEngine.Random;

public class YgRewardedHandler {
    private Action _onShown;
    private int _id;

    public void ShowRewarded(Action onShown) {
        _onShown = onShown;
        _id = Random.Range(0, 10000000);
#if UNITY_WEBGL && YG_WEBGL
        YandexGame.RewVideoShow(_id);
        YandexGame.RewardVideoEvent += CheckRewardedAndProceed;
#endif
    }

    private void CheckRewardedAndProceed(int id) {
        if (id == _id) {
            _onShown?.Invoke();
#if UNITY_WEBGL && YG_WEBGL
        YandexGame.RewardVideoEvent -= CheckRewardedAndProceed;
#endif
        }
    }
}