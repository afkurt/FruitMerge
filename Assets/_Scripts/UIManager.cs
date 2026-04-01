using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI endpointText;
    public TextMeshProUGUI highscoreText;

    public GameObject GameoverScene;
    
    private float _point;
    private float _soundpoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int savedHighscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Best: " + savedHighscore.ToString();
    }

    private void OnEnable()
    {
        MergeManager.OnMergeRequest += UpdatePoint;
    }

    private void OnDisable()
    {
        MergeManager.OnMergeRequest -= UpdatePoint;

    }

    void UpdatePoint(Fruit a, Fruit b) //Update Point
    {
        _point += a.data.point;
        pointText.text = _point.ToString();
        endpointText.text = _point.ToString();

        _soundpoint += a.data.point;
        if(_soundpoint >= 10)
        {
            SoundManager.Instance.PlayTada();
            _soundpoint -= 10;
        }

        //animation
        pointText.transform.DOScale(1.2f, 0.1f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                pointText.transform.DOScale(1f, 0.1f);
            });
    }  

    public void ShowGameover()
    {
        SaveHighscore();
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = highscore.ToString();
        GameoverScene.SetActive(true);
        Time.timeScale = 0f;
    }  
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    private void SaveHighscore()
    {
        int currentScore = (int)_point;
        int savedHighscore = PlayerPrefs.GetInt("Highscore", 0);

        if (currentScore > savedHighscore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            PlayerPrefs.Save();
        }
    }
}
