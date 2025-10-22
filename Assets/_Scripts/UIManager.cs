using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI pointText;
    public GameObject GameoverScene;
    
    private float _point;
    private float _soundpoint;

    private void Awake()
    {
        Instance = this;
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
        GameoverScene.SetActive(true);
        Time.timeScale = 0f;
    }  
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
