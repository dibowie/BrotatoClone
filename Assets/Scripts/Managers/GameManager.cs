using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Button _restartButton;


    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    public void GameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
    public void Win()
    {
        _winPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
