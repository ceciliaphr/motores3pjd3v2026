using UnityEngine;
using System.Collections;

public class SplashControlador : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TempoSplash());
    }

    IEnumerator TempoSplash()
    {
        yield return new WaitForSeconds(2f);

        GameManager.Instance.MudarEstado(GameManager.EstadoJogo.MenuPrincipal);
        GameManager.Instance.CarregarCena("MenuPrincipal");
    }
}