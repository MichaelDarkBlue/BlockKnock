using UnityEngine;
using System.Collections;

public class ScriptPlanBottom : MonoBehaviour {

	public playercontrol p;
	public GUIText gui;

	// Use this for initialization
	void Start () {
		//GameObject go = GameObject.FindWithTag ("player1");
		//p = go.GetComponent<playercontrol>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag == "cube1")
		{
			if (other.gameObject.GetComponent<Renderer>().material.color == p.color) {
				p.score += 1;
				//Debug.Log(p.score);
				gui.text = "Player 1: " + p.score;
			}
			Destroy(other.gameObject);
		}
	}
}
