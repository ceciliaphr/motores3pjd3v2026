using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinUIController : MonoBehaviour
{
    [Header("Contadores de Pontuação (Estrelas)")]
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;

    [Header("Painel de Vitória")]
    public GameObject winnerPanel;
    public TextMeshProUGUI winnerText;
    public Button restartButton;

    [Header("Regras do Jogo")]
    public int targetScore = 5;

    private void Awake()
    {
        if (winnerPanel != null) winnerPanel.SetActive(false);
        if (restartButton != null) restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnEnable()
    {
        PlayerOM.OnStarCountChanged += AtualizarTextoEstrelas;
        PlayerOM.OnPlayerWon += ExibirVencedor;
    }

    private void OnDisable()
    {
        PlayerOM.OnStarCountChanged -= AtualizarTextoEstrelas;
        PlayerOM.OnPlayerWon -= ExibirVencedor;
    }

    private void Start()
    {
        PlayerOM.ResetScores();
        AtualizarTextoEstrelas(1, PlayerOM.GetStars(1));
        AtualizarTextoEstrelas(2, PlayerOM.GetStars(2));
    }

    private void AtualizarTextoEstrelas(int playerID, int totalEstrelas)
    {
        if (playerID == 1 && p1ScoreText != null) p1ScoreText.text = $"P1 Estrelas: {totalEstrelas}";
        if (playerID == 2 && p2ScoreText != null) p2ScoreText.text = $"P2 Estrelas: {totalEstrelas}";

        if (targetScore > 0 && totalEstrelas >= targetScore)
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