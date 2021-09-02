using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other) {
        if(isTransitioning)
            return;
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You hit a friendly object");
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void SuccessSequence(){
        //todo add particle effect on Success
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }

    void CrashSequence(){
        //todo add particle effect on crash
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        GetComponent<Movement>().enabled = false;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
