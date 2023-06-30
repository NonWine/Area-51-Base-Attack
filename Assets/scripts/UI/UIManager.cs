using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject coldPanel;
    [SerializeField] private GameObject _upgradePanel;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenUpgradePanel()
    {
        _upgradePanel.SetActive(true);
        DOTween.Sequence()
            .Append(DOTween.To(() => Vector3.zero, x => _upgradePanel.transform.localScale = x, new Vector3(1f, 1f, 1f), 0.2f)).SetUpdate(UpdateType.Normal, true);
    }

    public void CloseUpgradePanek()
    {
        _upgradePanel.SetActive(false);
            
    }

    public void ActiveColdPanel() => coldPanel.SetActive(true);

    public void DeActiveColdPanel() => coldPanel.SetActive(false);
}
