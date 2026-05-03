using UnityEngine;

public class ControladorMenuBotoes : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.Instance.MudarEstado(GameManager.EstadoJogo.Gameplay);
        GameManager.Instance.CarregarCena("GetStarted_Scene");
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }
}