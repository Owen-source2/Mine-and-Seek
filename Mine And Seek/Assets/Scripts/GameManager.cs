using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int timerCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = timerCount.ToString();
        //Call Count Down Timer after 1 second and then every second after that
        InvokeRepeating("CountDownTimer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CountDownTimer()
    {
        timerCount--;
        if (timerCount == 0)
        {
            print("Time Out");
            CancelInvoke();
        }
        timerText.text = timerCount.ToString();
    }
}
