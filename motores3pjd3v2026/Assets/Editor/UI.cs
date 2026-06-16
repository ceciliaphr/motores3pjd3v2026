using UnityEngine;
using TMPro;

public class UI_Moedas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textoMoedas;

    private void Start()
    {
        textoMoedas.text = "Moedas: 0";
    }

    private void OnEnable()
    {
        ObservadorMoedas.Instance.AoMudarMoedas += AtualizarUI;
    }

    private void OnDisable()
    {
        if (ObservadorMoedas.Instance != null)
        {
            ObservadorMoedas.Instance.AoMudarMoedas -= AtualizarUI;
        }
    }

    private void AtualizarUI(int quantidade)
    {
        textoMoedas.text = "Moedas: " + quantidade;
    }
}