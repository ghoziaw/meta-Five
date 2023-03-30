using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneTransition : MonoBehaviour
{
    public GameObject loadingScreen;
    string TargetScene;

    public void LoadScene(string sceneName)
    {
        TargetScene = sceneName;
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Menampilkan loading screen
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1);

        // Membuat operation untuk memuat scene secara asynchronous
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(TargetScene);

        // Memproses operasi secara asynchronous
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}