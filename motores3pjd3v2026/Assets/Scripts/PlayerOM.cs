using System;

// Classe estática: não precisa ser anexada a nenhum GameObject na cena
public static class PlayerOM
{
    // Este é o "Canal" de moedas. 
    // Ele transmite um número inteiro (int) que representa o total de moedas.
    public static Action<int> OnCoinCountChanged;
}