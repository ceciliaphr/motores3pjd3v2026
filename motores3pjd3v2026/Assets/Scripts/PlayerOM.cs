using System;
using System.Collections.Generic;

public static class PlayerOM
{
    private static Dictionary<int, int> coinCounts = new Dictionary<int, int>();

    public static event Action<int, int> OnCoinCountChanged;
    public static event Action<int> OnPlayerWon;

    public static void ResetScores()
    {
        coinCounts[1] = 0;
        coinCounts[2] = 0;
    }

    public static void AddCoin(int playerID, int amount = 1)
    {
        if (!coinCounts.ContainsKey(playerID))
        {
            coinCounts[playerID] = 0;
        }

        coinCounts[playerID] += amount;
        OnCoinCountChanged?.Invoke(playerID, coinCounts[playerID]);
    }

    public static int GetCoins(int playerID)
    {
        return coinCounts.ContainsKey(playerID) ? coinCounts[playerID] : 0;
    }

    public static void TriggerWin(int playerID)
    {
        OnPlayerWon?.Invoke(playerID);
    }
}