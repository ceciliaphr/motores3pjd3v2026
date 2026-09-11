using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinUIController : MonoBehaviour
{
    [Header("Contadores de Moedas")]
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;

    [Header("Painel de Vitória")]
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;
    public Button restartButton;

    [Header("Regras do Jogo")]
    public int targetScore = 10;

    private void Awake()
    {
        if (winnerPanel != null) winnerPanel.SetActive(false);
        if (restartButton != null) restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnEnable()
    {
        PlayerOM.OnCoinCountChanged += AtualizarTextoMoedas;
        PlayerOM.OnPlayerWon += ExibirVencedor;
    }

    private void OnDisable()
    {
        PlayerOM.OnCoinCountChanged -= AtualizarTextoMoedas;
        PlayerOM.OnPlayerWon -= ExibirVencedor;
    }

    private void Start()
    {
        AtualizarTextoMoedas(1, PlayerOM.GetCoins(1));
        AtualizarTextoMoedas(2, PlayerOM.GetCoins(2));
    }

    private void AtualizarTextoMoedas(int playerID, int totalMoedas)
    {
        if (playerID == 1 && p1ScoreText != null) p1ScoreText.text = $"P1 Moedas: {totalMoedas}";
        if (playerID == 2 && p2ScoreText != null) p2ScoreText.text = $"P2 Moedas: {totalMoedas}";

        if (targetScore > 0 && totalMoedas >= targetScore)
        {
            PlayerOM.TriggerWin(playerID);
        }
    }

    public void ExibirVencedor(int winnerPlayerID)
    {
        if (winnerPanel != null) winnerPanel.SetActive(true);
        if (winnerText != null) winnerText.text = $"JOGADOR {winnerPlayerID} VENCEU!";
        Time.timeScale = 0f;
    }

    private void OnRestartButtonClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ReiniciarPartida();
        }
    }
}