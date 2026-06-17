using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configurações de Cena")]
    [Tooltip("Nome da cena principal de Gameplay")]
    public string GameplaySceneName = "Gameplay";
    
    [Tooltip("Nome da cena de interface (GUI)")]
    public string GUISceneName = "GUI";

    private void Awake()
    {
        // Garante que o GameManager não seja destruído ao carregar novas cenas
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // Ao iniciar a cena _Boot, carregamos o jogo
        CarregarJogo();
    }

    public void CarregarJogo()
    {
        // 1. Carrega a cena de Gameplay como a cena principal (limpa tudo antes)
        SceneManager.LoadScene(GameplaySceneName, LoadSceneMode.Single);

        // 2. Carrega a cena de GUI de forma aditiva (sobrepondo a Gameplay)
        SceneManager.LoadScene(GUISceneName, LoadSceneMode.Additive);
        
        Debug.Log("Cenas carregadas com sucesso!");
    }
}