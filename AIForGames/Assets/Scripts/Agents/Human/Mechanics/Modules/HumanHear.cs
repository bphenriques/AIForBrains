using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanHear : MonoBehaviour
{
	IList<MessageLogEntry> MessageLog;
	Human humanState;

	public struct MessageLogEntry{
		GameObject human;
		float timeHeard;
		HumanSpeak.Message message;

		public HumanSpeak.Message getMessage(){
			return message;
		}

		public float getMessageTime(){
			return timeHeard;
		}

		public GameObject getHuman(){
			return human;
		}

		public MessageLogEntry(GameObject human, float timeHeard, HumanSpeak.Message message){
			this.human = human;
			this.timeHeard = timeHeard;
			this.message = message;
		}
	}


	// Use this for initialization
	void Start ()
	{
		humanState = transform.root.GetComponent <Human> ();
		MessageLog = new List<MessageLogEntry> ();
	}


	public void HearMessage(GameObject human, HumanSpeak.Message m){
		Debug.Log ("HEARD FROM " + human + " " + m.ToString ());
        humanState.memory.RememberHuman(human);
		MessageLog.Add (new MessageLogEntry (human, humanState.getHumanTime(), m));

	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}