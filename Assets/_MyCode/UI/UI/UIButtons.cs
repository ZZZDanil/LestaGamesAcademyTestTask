using UnityEngine;

public class UIButtons : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            GameQuit();
        }
    }
    public void Cheat()
    {
        GameRuleMiniGame.miniGameField?.EasyGenerate();
    }
    public void GameQuit()
    {
        Application.Quit();
    }

}
