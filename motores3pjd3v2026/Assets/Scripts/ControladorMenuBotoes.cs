using UnityEngine;

public class ControladorMenuBotoes : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.Instance.IniciarJogo();
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }
}