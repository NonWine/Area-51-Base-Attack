using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDPR : MonoBehaviour
{
    public void TurnMainScen()
    {
        PlayerPrefs.SetInt("GDPR", 1);
    }
}
