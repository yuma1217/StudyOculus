using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;

public class OculusPlatformTest : MonoBehaviour {

	protected OculusPlatformTest s_instance = null;

	protected RoomTest roomTest;

	protected VoipTest voipTest;

	protected ulong myID;
	protected string myOculusID;
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
		Entitlements.IsUserEntitledToApplication().OnComplete(IsEntitledCallback);
		Oculus.Platform.Request.RunCallbacks();
	}

	void IsEntitledCallback(Message msg){
		if(msg.IsError){
			Debug.Log("IsEntitledCallback is error");
			return;
		}
		Debug.Log("Entitlement check success");
		Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
		Oculus.Platform.Request.RunCallbacks();
	}

    private void GetLoggedInUserCallback(Message<User> message)
    {
		if(message.IsError){
			Debug.Log("GetLoggedInUser is error");
			return;
		}
		myID = message.Data.ID;
		myOculusID = message.Data.OculusID;

		Debug.Log("myID:" + myID);
		Debug.Log("oculusID:" + myOculusID);

		// avatar作ったり、transformいじったり

		/*
		localAvatar = Instantiate(localAvatarPrefab);
        localTrackingSpace = this.transform.Find("OVRCameraRig/TrackingSpace").gameObject;

        localAvatar.transform.SetParent(localTrackingSpace.transform, false);
        localAvatar.transform.localPosition = new Vector3(0, 0, 0);
        localAvatar.transform.localRotation = Quaternion.identity;

        if (UnityEngine.Application.platform == RuntimePlatform.Android)
        {
            helpPanel.transform.SetParent(localAvatar.transform.Find("body"), false);
            helpPanel.transform.localPosition = new Vector3(0, 1.0f, 1.0f);
            helpMesh.material = gearMaterial;
        }
        else
        {
            helpPanel.transform.SetParent(localAvatar.transform.Find("hand_left"), false);
            helpPanel.transform.localPosition = new Vector3(0, 0.2f, 0.2f);
            helpMesh.material = riftMaterial;
        }
        
        localAvatar.oculusUserID = myID.ToString();
        localAvatar.RecordPackets = true;
        localAvatar.PacketRecorded += OnLocalAvatarPacketRecorded;
        localAvatar.EnableMouthVertexAnimation = true;

        Quaternion rotation = Quaternion.identity;

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                rotation.eulerAngles = START_ROTATION_ONE;
                this.transform.localPosition = START_POSITION_ONE;
                this.transform.localRotation = rotation;
                break;

            case 1:
                rotation.eulerAngles = START_ROTATION_TWO;
                this.transform.localPosition = START_POSITION_TWO;
                this.transform.localRotation = rotation;
                break;

            case 2:
                rotation.eulerAngles = START_ROTATION_THREE;
                this.transform.localPosition = START_POSITION_THREE;
                this.transform.localRotation = rotation;
                break;

            case 3:
            default:
                rotation.eulerAngles = START_ROTATION_FOUR;
                this.transform.localPosition = START_POSITION_FOUR;
                this.transform.localRotation = rotation;
                break;
        }

        TransitionToState(State.CHECKING_LAUNCH_STATE);

        // If the user launched the app by accepting the notification, then we want to
        // join that room.  If not, try to find a friend's room to join
        if (!roomManager.CheckForInvite())
        {
            SocialPlatformManager.LogOutput("No invite on launch, looking for a friend to join.");
            Users.GetLoggedInUserFriendsAndRooms()
                .OnComplete(GetLoggedInUserFriendsAndRoomsCallback);
        }
        Voip.SetMicrophoneFilterCallback(micFilterDelegate);
		 */


    }

    private void TransitionToState(State newState)
    {

    }

	public enum State{
		INITIALIZING,
	}
	
	// Update is called once per frame
	void Update () {
		/* 
		// Look for updates from remote users
        p2pManager.GetRemotePackets();

        // update avatar mouths to match voip volume
        foreach (KeyValuePair<ulong, RemotePlayer> kvp in remoteUsers)
        {
            float remoteVoiceCurrent = Mathf.Clamp(kvp.Value.voipSource.peakAmplitude * VOIP_SCALE, 0f, 1f);
            kvp.Value.RemoteAvatar.VoiceAmplitude = remoteVoiceCurrent;
        }

        if (localAvatar != null)
        {
            localAvatar.VoiceAmplitude = Mathf.Clamp(voiceCurrent * VOIP_SCALE, 0f, 1f);
        }
		*/
	}
}
