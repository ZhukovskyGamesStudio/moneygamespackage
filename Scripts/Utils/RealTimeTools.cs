using System;
using UnityEngine;

public static class RealTimeTools {
    public static long GetIntervalIndex(TimeSpan interval) {
        return YGWrapper.GetServerTime() / GetTimeSpanMilliseconds(interval);
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