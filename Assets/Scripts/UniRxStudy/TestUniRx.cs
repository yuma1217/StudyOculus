using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class TestUniRx : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		
		this.UpdateAsObservable()
			.Subscribe(_ => {
				cube.transform.Translate(Vector3.right * Time.deltaTime);
			});
	}
	
}
