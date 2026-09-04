using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Text ActivePlayerEntry;

    public void PlayGame()
    {

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
