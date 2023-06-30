using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
public class Unlocking : MonoBehaviour
{
    [SerializeField] private float slowLerp;
    [SerializeField] private Image _images;
    private int allUnlock;
    private float value,speed;

    private void Awake()
    {
        value = PlayerPrefs.GetFloat("value");
        _images.fillAmount = value;
    }

    public async void Fill(int percent)
    {

         value = (percent / 100f)  + _images.fillAmount;
        PlayerPrefs.SetFloat("value", value);
        speed =0;
        Debug.Log(value);
        while(_images.fillAmount != value) 
        {
            speed += Time.deltaTime;
           _images.fillAmount = Mathf.Lerp(_images.fillAmount, value, speed / slowLerp );
            await UniTask.Yield();
        }
        
    }

    public int IsAllUnlock()
    {
        return allUnlock;
    }

    public float Value()
    {
        return value;
    }
}
