using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    public GameObject mainMenu, HUD, pauseScreen, endGame;
    public Button pauseBtn, playBtn, replayBtn, nextBtn, quitBtn;
    public Text levelTxt;
    private bool started;

    private int level;
    public static GUI instance;

    void Awake ()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(this);

        mainMenu.SetActive(true);
        HUD.SetActive(false);
        pauseScreen.SetActive(false);
        endGame.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(Pause);
        playBtn.onClick.AddListener(Resume);
        quitBtn.onClick.AddListener(Quit);
        replayBtn.onClick.AddListener(PlayAgain);
        nextBtn.onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Input.anyKey) StartGame();
    }

    void StartGame ()
    {
        mainMenu.SetActive(false);
        HUD.SetActive(true);
    }

    void Pause ()
    {
        HUD.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void Resume ()
    {
        HUD.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    void PlayAgain ()
    {
        HUD.SetActive(true);
        endGame.SetActive(false);
        SceneManager.LoadScene(level);
    }

    void NextLevel ()
    {
        level++;
        int currentLevel = level + 1;
        levelTxt.text = "LEVEL: "+currentLevel;
        HUD.SetActive(true);
        endGame.SetActive(false);
        SceneManager.LoadScene(level);
    }

    public void EndGame ()
    {
        HUD.SetActive(false);
        endGame.SetActive(true);
    }

    void Quit ()
    {
        #if UNITY_EDITOR
        if(UnityEditor.EditorApplication.isPlaying)
            UnityEditor.EditorApplication.isPlaying = false;
        #endif 
        Application.Quit();
    }
}
