using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkPrivacy : MonoBehaviour
{
    public void Link(string link)
    {
        Application.OpenURL(link);
    }
}
