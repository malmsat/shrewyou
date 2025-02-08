using System.Collections; // Capital "S" in "System"
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(16f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
