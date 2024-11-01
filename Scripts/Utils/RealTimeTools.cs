using System;

public static class RealTimeTools {
    public static long GetIntervalIndex(TimeSpan interval) {
        return YGWrapper.GetServerTime() / GetTimeSpanMilliseconds(interval);
    }

    public static long GetTimeSpanMilliseconds(TimeSpan span) {
        return Convert.ToInt64(span.TotalMilliseconds);
    }
}