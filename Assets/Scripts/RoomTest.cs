using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTest {

	// 自分がサーバーかどうか
	private bool amIserver;

	// スタートアップが終わったかどうか
	private bool startupDone;
	public RoomTest(){
		amIserver = false;
		startupDone = false;
		// todo : rooms.setなどのコールバック設定
	}
}
