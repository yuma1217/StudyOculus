using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimerView : MonoBehaviour{

    [SerializeField] private TimeCounter timeCounter;
    [SerializeField] private Text counterText;

    void Start(){
        timeCounter.OnTimeChanged.Subscribe(time =>
        {
            Debug.Log(time.ToString());
            counterText.text = time.ToString();
        });
    }
}
