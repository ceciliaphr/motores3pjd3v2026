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

    private void Awake()
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

    private void Start()
    {
        MudarEstado(EstadoJogo.Iniciando);
        CarregarCena("Splash");
    }

    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += QuandoCenaCarregada;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= QuandoCenaCarregada;
    }

    void QuandoCenaCarregada(Scene scene, LoadSceneMode mode)
    {
        if (estadoAtual == EstadoJogo.Gameplay)
        {
            PlayerInput player = FindObjectOfType<PlayerInput>();

            if (player != null)
            {
                player.ActivateInput();
                Debug.Log("Input ativado para o jogador");
            }
        }
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual: " + estadoAtual);
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}