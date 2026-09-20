using System;
using System.Collections.Generic;

public static class PlayerOM
{
    private static Dictionary<int, int> starCounts = new Dictionary<int, int>();
    private static Dictionary<int, int> coinCounts = new Dictionary<int, int>();

    public static event Action<int, int> OnStarCountChanged;
    public static event Action<int, int> OnCoinCountChanged;
    public static event Action<int> OnPlayerWon;

    public static void ResetScores()
    {
        starCounts[1] = 0;
        starCounts[2] = 0;
        coinCounts[1] = 0;
        coinCounts[2] = 0;
    }

    #region Estrelas (Pontuação Principal de Vitória)

    public static void AddStar(int playerID, int amount = 1)
    {
        if (!starCounts.ContainsKey(playerID))
        {
            starCounts[playerID] = 0;
        }

        starCounts[playerID] += amount;
        OnStarCountChanged?.Invoke(playerID, starCounts[playerID]);
    }

    public static int GetStars(int playerID)
    {
        return starCounts.ContainsKey(playerID) ? starCounts[playerID] : 0;
    }

    #endregion

    #region Moedas (Aceleração / Estatísticas)

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

    #endregion

    public static void TriggerWin(int playerID)
    {
        OnPlayerWon?.Invoke(playerID);
    }
}