using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScene;
    public Slider slider;
    public TMPro.TextMeshProUGUI progressText;

    private void Start()
    {
        loadingScene.SetActive(false);
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine( LoadAsynchronously(sceneName) );
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScene.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
