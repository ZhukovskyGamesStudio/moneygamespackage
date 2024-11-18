using System;
using UnityEngine;

public static class RealTimeTools {
    public static long GetIntervalIndex(TimeSpan interval) {
        return YGWrapper.GetServerTime() / GetTimeSpanMilliseconds(interval);
    }

    public static long GetIntervalIndex(TimeSpan interval, TimeSpan pauseBetweenIntervals) {
        return YGWrapper.GetServerTime() / GetTimeSpanMilliseconds(interval + pauseBetweenIntervals);
    }

    public static bool IsIntervalActiveHours(float interval, float startTime, float endTime) {
        return IsIntervalActive(TimeSpan.FromHours(interval), TimeSpan.FromHours(startTime), TimeSpan.FromHours(endTime));
    }

    public static long GetCurrentIntervalStart(TimeSpan interval) {
        return GetIntervalIndex(interval) * GetTimeSpanMilliseconds(interval);
    }

    public static bool IsIntervalActive(TimeSpan interval, TimeSpan startTime, TimeSpan endTime) {
        var timeInInterval = YGWrapper.GetServerTime() % GetTimeSpanMilliseconds(interval);
        return GetTimeSpanMilliseconds(startTime) <= timeInInterval && timeInInterval <= GetTimeSpanMilliseconds(endTime);
    }

    public static long GetTimeSpanMilliseconds(TimeSpan span) {
        return Convert.ToInt64(span.TotalMilliseconds);
    }

    public static string GetTimeStr(long milliseconds) {
        if (milliseconds < 0) {
            Debug.LogWarning("time is less than zero");
            return "0";
        }

        var span = TimeSpan.FromMilliseconds(milliseconds);
        if (span.Days > 0) {
            return $"{span.Days}д {span.Hours}ч";
        } else if (span.Hours > 0) {
            return $"{span.Hours}ч {span.Minutes}m ";
        } else if (span.Minutes > 0) {
            return $"{span.Minutes}м {span.Seconds}с";
        } else if (span.Seconds > 0) {
            return $"{span.Seconds}с";
        }

        return "0";
    }
}