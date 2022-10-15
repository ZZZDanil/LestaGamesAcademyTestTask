using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWindow : MonoBehaviour
{
    public GameObject child;
    private void Awake()
    {
        GameRuleMiniGame.endWindow = this;
        child?.SetActive(false);
    }

    public void ShowResultWindow()
    {
        child?.SetActive(true);
    }

    public void ReloadWindow()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
