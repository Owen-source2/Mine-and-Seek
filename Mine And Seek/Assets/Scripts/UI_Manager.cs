using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    TMP_Text plantCooldown;
    public float currentPlantCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowCooldown(float cooldown)
    {
        //plantCooldown.SetText(plantCooldown);
        Debug.Log("showing");
    }
}
