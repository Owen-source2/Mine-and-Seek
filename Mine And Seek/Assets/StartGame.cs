using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public int sceneToLoad=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex!=0)
        {
            gameObject.SetActive(false);
        } 
        else
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
