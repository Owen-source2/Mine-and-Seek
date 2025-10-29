using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text plantCooldown;
    public float currentPlantCooldown;
    public enum eventType
    {
        StartGame,
        Test
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plantCooldown.text = currentPlantCooldown.ToString();
        //Call Count Down Timer after 1 second and then every second after that
        InvokeRepeating("ShowCooldown", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowCooldown(float cooldown)
    {
        currentPlantCooldown--;
        if (currentPlantCooldown == 0)
        {
            print("Time Out");
            CancelInvoke();
        }
        plantCooldown.text = currentPlantCooldown.ToString();
    }
    public void clickEvent(eventType whenClicked)
    {
        switch(whenClicked)
        {
            case eventType.StartGame:
                SceneManager.LoadScene(1);
                break;
        }
    }
}
