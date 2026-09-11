using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string GameplaySceneName = "Gameplay";
    public string GUISceneName = "GUI";

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
        CarregarJogo();
    }

    public void CarregarJogo()
    {
        PlayerOM.ResetScores();
        SceneManager.LoadScene(GameplaySceneName, LoadSceneMode.Single);
        SceneManager.LoadScene(GUISceneName, LoadSceneMode.Additive);
    }

    public void ReiniciarPartida()
    {
        Time.timeScale = 1f;
        CarregarJogo();
    }
}