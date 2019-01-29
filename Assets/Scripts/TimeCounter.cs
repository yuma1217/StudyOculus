using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class TimeCounter : MonoBehaviour {

	private Subject<int> timerSubject = new Subject<int>();

	public IOptimizedObservable<int> OnTimeChanged{
		get{return timerSubject;}
	}
	// Use this for initialization
	void Start () {
        StartCoroutine(TimerCoroutine());
	}

    IEnumerator TimerCoroutine(){
        var time = 100;
        while (time > 0){
            time--;

            timerSubject.OnNext(time);

            yield return new WaitForSeconds(1);
        }
    }
}
