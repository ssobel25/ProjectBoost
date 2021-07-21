using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("At home");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke ("LoadNextLevel", loadDelay);
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }
}
