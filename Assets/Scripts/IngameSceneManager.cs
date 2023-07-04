using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IngameSceneManager : MonoBehaviour
{
    public static int artifact = 0;
    public GameObject WinScreen;

    public TextMeshProUGUI txt;

    void Update()
    {
        txt.text = "Artifact Found " + artifact;

        if(artifact >= 3)
        {
            artifact = 0;
            StartCoroutine("Winning");
        }
    }

    IEnumerator Winning()
    {
        Debug.Log("Yey Menang!!");
        yield return new WaitForSeconds(1f);
        // WinScreen.SetActive(true);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
