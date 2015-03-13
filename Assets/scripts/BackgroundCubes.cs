using UnityEngine;
using System.Collections;

public class BackgroundCubes : MonoBehaviour
{
	void Start()
	{
		//Random Color 
		//renderer.material.color = new Color(0, 255, 0);
		Vector3 color = new Vector3(Random.Range(0.0F, 0.5F), Random.Range(0.0F, 0.5F), Random.Range(0.0F, 0.5F));
		GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z);
		//Random Size
		transform.localScale += new Vector3(Random.Range(1.0F, 3.0F), Random.Range(1.0F, 3.0F), Random.Range(1.0F, 3.0F));
		//Random Rotation
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
	}
}
