using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Option : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainMenu";
    [SerializeField] private UI_FadeScreen fadeScreen;

    public void SaveAndExit()
    {
        GameManager.instance.PauseGame(false);
        SaveGame();
        ExitGame();
    }

    private void SaveGame() => SaveManager.instance.SaveGame();

    private void ExitGame() => StartCoroutine(LoadSceneWithFadeEffect(1.5f));

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSecondsRealtime(_delay);

        SceneManager.LoadScene(sceneName);
    }
}
