using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum EstadoJogo
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public EstadoJogo estadoAtual;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += QuandoCenaCarregada;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= QuandoCenaCarregada;
    }

    void Start()
    {
        MudarEstado(EstadoJogo.Iniciando);
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual: " + estadoAtual);

        switch (estadoAtual)
        {
            case EstadoJogo.Iniciando:
                SceneManager.LoadScene("Splash");
                break;

            case EstadoJogo.MenuPrincipal:
                SceneManager.LoadScene("MenuPrincipal");
                break;

            case EstadoJogo.Gameplay:
                SceneManager.LoadScene("GetStarted_Scene");
                break;
        }
    }

    void QuandoCenaCarregada(Scene scene, LoadSceneMode mode)
    {
        if (estadoAtual == EstadoJogo.Gameplay)
        {
            PlayerInput player = FindFirstObjectByType<PlayerInput>();

            if (player != null)
            {
                player.ActivateInput();
                
            }
        }
    }

    public void IniciarJogo()
    {
        MudarEstado(EstadoJogo.Gameplay);
    }

    public void IrParaMenu()
    {
        MudarEstado(EstadoJogo.MenuPrincipal);
    }
}