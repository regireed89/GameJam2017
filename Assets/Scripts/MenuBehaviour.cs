using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("0.Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("1.MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("2.Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume(GameObject panel)
    {
        panel.GetComponent<Image>().enabled = false;
        panel.GetComponentInChildren<Text>().enabled = false;
        foreach (var button in panel.GetComponentsInChildren<Button>())
        {
            button.gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }
}
