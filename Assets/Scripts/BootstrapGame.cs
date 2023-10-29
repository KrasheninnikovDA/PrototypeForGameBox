
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapGame : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
