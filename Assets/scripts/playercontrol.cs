using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {

	public float speed = 10.0F;
	public Color color = new Color (.5f, 0, 0);
	public int score = 0;

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
			
			syncPosition = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}

	public string playerName = "Nothing";
	// Use this for initialization
	void Start () {
		//Rigidbody r = GetComponent<Rigidbody>();
		//r.mass = 10f;
		//transform.position = Vector3.zero;  
		if (networkView.isMine) {
			color = getColor (1);
		} else {
			color = getColor (1);
		}
		renderer.material.color = color;
	}

	public Color getColor(int players){

		//if (!networkView.isMine){players++;}

		switch (players) {
		case 1:
			return new Color (0, .5f, 0);
			//break;
		case 2:
			return new Color (0, 0, 5f);
			//break; 
		default:
			return color;
			//break;
		}
	}

	void Awake()
	{
		lastSynchronizationTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void FixedUpdate(){
		if (networkView.isMine) {
			float horz = Input.GetAxis ("Horizontal") * speed * Time.deltaTime; 	//Input
			float vert = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			transform.Translate (horz, 0, vert);
		}else
		{
			SyncedMovement();
		}
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		
		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "cube1")
		{
			other.gameObject.renderer.material.color = color;
		}
	}
}
