using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManageLogic : MonoBehaviour
{
    public int voids = 0;
    public float leftSpeed = .2f;
    public static ManageLogic instance;
    public int time = 0;

    // These no longer need to be assigned in the Inspector
    private Text voidScore;
    private Text timeScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Always unsubscribe when destroyed to avoid memory leaks
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    // This runs automatically EVERY time a scene changes
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainGameScene")
        {
            // Dynamically find the new UI elements by their GameObject names
            GameObject voidObj = GameObject.Find("VoidScore");
            GameObject timeObj = GameObject.Find("TimeScore");

            if (voidObj != null) voidScore = voidObj.GetComponent<Text>();
            if (timeObj != null) timeScore = timeObj.GetComponent<Text>();

            voids = 0;
            time = 0;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")
        {
            // Add safe checks to prevent errors if the UI isn't found yet
            if (voidScore != null) voidScore.text = "Chips: " + voids.ToString();

            time = (int)Time.timeSinceLevelLoad;
            if (timeScore != null) timeScore.text = "Time: " + time.ToString();
        }
    }
}
