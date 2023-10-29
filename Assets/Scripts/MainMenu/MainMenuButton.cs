using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnClickInGameplaye()
    {
        SceneManager.LoadScene("GamePlaye");
    }
}
