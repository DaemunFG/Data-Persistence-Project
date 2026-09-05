using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    public Text BestScore;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        BestScore.text = $"Best Score : {MyManager.Instance.BestName} Scored : {MyManager.Instance.BestScore}";
    }

    public Text ActivePlayerEntry;

    public void PlayGame()
    {
        GameObject.Find("BestScoreText").transform.position = new Vector3(1275, 1500);
        GameObject.Find("TitleText").SetActive(false);
        GameObject.Find("PlayButton").SetActive(false);
        GameObject.Find("NameEntry").SetActive(false);

        Debug.Log("Game has started");
        SceneManager.LoadScene(1);
    }

    public void SetActivePlayerName()
    {
        MyManager.Instance.ActivePlayerName = ActivePlayerEntry;
        Debug.Log($"Active player name set to {ActivePlayerEntry.text}");
    }
}
