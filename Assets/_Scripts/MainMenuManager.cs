using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private GameObject _inGamePanel;

    private void Start()
    {
        _loadingPanel.SetActive(false);
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        _soundSlider.value = savedVolume;
        _soundSlider.onValueChanged.AddListener(OnVolumeChanged);

        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        _highscoreText.text = "Best: " + highscore.ToString();
    }

    private void OnVolumeChanged(float value)
    {
        SoundManager.Instance.SetVolume(value);
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
        _loadingPanel.SetActive(true);
        _inGamePanel.SetActive(false);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        operation.allowSceneActivation = true;
    }
}