using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MadPixelAnalytics;
public class Tutorial : MonoBehaviour 
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject[] images;
    [SerializeField] private PointerManager pointerManager;
    private bool Tutor;
    private bool startTutor;
    private void Awake()
    {
        EventManager.onTutorial += SpawnInTutor;
        tutorialPanel.SetActive(true);
        Tutor = PlayerPrefsExtra.GetBool("tutora", false);
        startTutor = PlayerPrefsExtra.GetBool("startTutor", startTutor);
    }

    private void Start()
    {
        if (Tutor)
        {
            foreach (var item in images)
            {
                item.gameObject.SetActive(false);
            }
            GameManager.Instance.StartLevel();
            pointerManager.enabled = false;
            // Destroy(pointerManager);
           // spawnManager.Spawn();
            tutorialPanel.SetActive(false);
            enabled = false;
        }
    }

    public void EndTutor()
    {
        if (!Tutor)
        {
            Tutor = true;
          
            PlayerPrefsExtra.SetBool("tutora", true);
            tutorialPanel.SetActive(false);
           // spawnManager.Spawn();
            enabled = false;
            AnalyticsManager.CustomEvent("tutorial", new Dictionary<string, object> { { "step_name", "01_dragJoystick" } },true);
        }
        
    }
     public void SetTutor() {  Tutor = true;  }

    public void SpawnInTutor()
    {
        if (!startTutor)
        {
            startTutor = true;
            PlayerPrefsExtra.SetBool("startTutor", startTutor);
            foreach (var item in images)
            {
                item.gameObject.SetActive(false);
            }
            GameManager.Instance.StartLevel();
            //   Destroy(pointerManager);
            pointerManager.enabled = false;
            AnalyticsManager.CustomEvent("tutorial", new Dictionary<string, object> { { "step_name", "01_dragJoystick, 02_buyItem" } }, true);
            //   spawnManager.Spawn();

        }
    }

    private void OnDestroy()
    {
        EventManager.onTutorial -= SpawnInTutor;
    }
}
