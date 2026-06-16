using UnityEngine;
using System;

public class ObservadorMoedas : MonoBehaviour
{
    public static ObservadorMoedas Instance;

    public event Action<int> AoMudarMoedas;

    private int moedas;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AdicionarMoedas(int quantidade)
    {
        moedas += quantidade;

        Debug.Log("Moedas: " + moedas);

        AoMudarMoedas?.Invoke(moedas);
    }

    public int GetMoedas()
    {
        return moedas;
    }
}