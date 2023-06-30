using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeckaController : MonoBehaviour
{
    [SerializeField] private BasePanel[] upgrades;
    [SerializeField] private Image[] images;

    private void Start()
    {
        int j = 0;
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i].isSetDekca())
            {
                images[j].enabled = true;
                images[j].sprite = upgrades[i].GetImage().sprite;
                j++;
            }
        }
    }

    public void SetImage(BasePanel basePanel, int index)
    {
        images[index].enabled = true;
        images[index].sprite = basePanel.GetImage().sprite;
        //Debug.Log(basePanel.GetImage().)
    }
}
