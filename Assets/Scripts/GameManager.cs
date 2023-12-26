using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private TMP_Text scoreText;

    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }
}
