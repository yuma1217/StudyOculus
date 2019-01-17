using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
public class OculusPlatformTest : MonoBehaviour {

	protected OculusPlatformTest s_instance = null;

	protected RoomTest roomTest;

	protected VoipTest voipTest;
	void Awake(){
		if(s_instance != null){
			Destroy(gameObject);
			return;
		}

		s_instance = this;
		DontDestroyOnLoad(gameObject);

		TransitionToState(State.INITIALIZING);
		Debug.Log("test");
		Core.Initialize();

		roomTest = new RoomTest();
		voipTest = new VoipTest();

	}

	// Use this for initialization
    void Start () {
		
	}

    private void TransitionToState(State newState)
    {

    }

	public enum State{
		INITIALIZING,
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
