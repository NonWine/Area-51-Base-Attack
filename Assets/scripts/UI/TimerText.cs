using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    [SerializeField] TMP_Text _timerText,timerText2;
    [SerializeField] TMP_Text best;
    private bool timerOn;
    private float timer;
    private float recordTimer;

    private void Awake()
    {
        timer = PlayerPrefs.GetFloat("currentTime", timer);
    }

    private void Start()
    {
        recordTimer = PlayerPrefs.GetFloat("timer");
        timerOn = true;
    }

    private void Update()
    {
        if (!Player.Instance.isDead())
        {
            timer += Time.deltaTime;
            PlayerPrefs.SetFloat("currentTime", timer);
        }
            
    }

    public void UpdateTimer()
    {
        //if (timer > recordTimer)
        //    best.gameObject.SetActive(true);
        timer += 1f;
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60f);
        _timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
        timerText2.text = string.Format("{0}:{1:00}", minutes, seconds);
        enabled = false;
    }

    public float GetTime()
    {
        return timer;
    }
}
