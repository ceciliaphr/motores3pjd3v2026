using UnityEngine;
using TMPro; // Necessário se estiver usando TextMeshPro

public class CoinUIController : MonoBehaviour
{
    private TextMeshProUGUI textoMoedas;

    private void Awake()
    {
        textoMoedas = GetComponent<TextMeshProUGUI>();
    }

    // Quando a interface é ativada, ela se INSCREVE no canal
    private void OnEnable()
    {
        PlayerOM.OnCoinCountChanged += AtualizarTextoMoedas;
    }

    // Quando a interface é desativada, ela se DESINSCREVE (Evita memory leaks/erros)
    private void OnDisable()
    {
        PlayerOM.OnCoinCountChanged -= AtualizarTextoMoedas;
    }

    // Método que processa a notificação recebida do PlayerOM
    private void AtualizarTextoMoedas(int totalAtual)
    {
        textoMoedas.text = "Moedas: " + totalAtual;
    }
}