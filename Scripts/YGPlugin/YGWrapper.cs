using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_WEBGL && YG_WEBGL
using YG;
#endif

public static class YGWrapper {
    private static bool _isYgGameReady;

    public static void GameReady() {
#if UNITY_WEBGL && YG_WEBGL
        if (!_isYgGameReady) {
                YandexGame.GameReadyAPI();
                _isYgGameReady = true;
        }
#else
        Debug.Log($"Disabled on current platform: Yandex game ready.");
#endif
    }

    public static void ReviewShow() {
#if UNITY_WEBGL && YG_WEBGL
        YandexGame.ReviewShow(true);
#else
        Debug.Log($"Disabled on current platform: Yandex game review show.");
#endif
    }

    public static void SendYandexMetrica(string eventName, string parameter) {
#if UNITY_WEBGL && YG_WEBGL
        YandexMetrica.Send(eventName, new Dictionary<string, string>() { { eventName, parameter } });
#else
        Debug.Log($"Disabled on current platform: Yandex metrica event: {eventName} amount: {parameter}");
#endif
    }

    public static void SendLeaderboardScore(string leaderboardId, int amount) {
#if UNITY_WEBGL && YG_WEBGL
        YandexGame.NewLeaderboardScores(leaderboardId, amount);
#else
        Debug.Log($"Disabled on current platform: Leaderboard id: {leaderboardId} amount: {amount}");
#endif
    }

    public static long GetServerTime() {
#if UNITY_WEBGL && YG_WEBGL
        return YandexGame.ServerTime();
#else
        long res = RealTimeTools.GetTimeSpanMilliseconds(DateTime.Now - DateTime.UnixEpoch);
        long addedAdminTime = RealTimeTools.GetTimeSpanMilliseconds(TimeSpan.FromHours(PlayerPrefs.GetFloat("AdminAddedHours")));
        // Debug.Log($"Disabled on current platform: return DateTime.now: {res}, fixed Yandex time: {YandexGame.ServerTime()}");
        return res + addedAdminTime;
#endif
    }
}