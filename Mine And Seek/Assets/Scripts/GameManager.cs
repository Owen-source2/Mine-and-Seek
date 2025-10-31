using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TMP_Text winner;
    public int timerCount = 0;
    public GameObject resetButton;
    GameObject trapper;
    GameObject gunner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winner.SetText("");
        trapper=GameObject.Find("Trapper");
        gunner=GameObject.Find("Gunner");

    }

    // Update is called once per frame
    void Update()
    {
        if(!trapper||!gunner)
        {
            if(!trapper)
            {
                winner.SetText("Gunner Wins!");
            }
            else
            {
                winner.SetText("Trapper Wins!");
            }
            resetButton.SetActive(true);
        }
    }


    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
