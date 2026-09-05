using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;

    public string BestName;
    public int BestScore;

    public Text ActivePlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
        LoadBestScore();
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class BSData
    {
        public int BestScore;
        public string BestName;
    }

    public void SaveBestScore()
    {
        BSData data = new BSData();
        data.BestScore = BestScore;
        data.BestName = BestName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BSData data = JsonUtility.FromJson<BSData>(json);

            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }
}
