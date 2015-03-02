using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

	public Transform prefabCube1;
	private float[] numList = {.2F,.4F,.6F,.8F};
	bool spawnedCubes;
	// Use this for initialization
//	void Start () {
//
//	}
	// Update is called once per frame 
	void Update () {
		if (spawnedCubes == false & Network.isServer) {
			//int counter = 1;
			int am = 5;
			int xo = -2;
			int yo = 1;
			int zo = -2;
			for (int y = 0; y < am; y++) {
				for (int x = 0; x < am; x++) {
					for (int z = 0; z < am; z++) {
						//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
						//cube.AddComponent<Rigidbody>(); 
						//cube.transform.position = new Vector3(x+xo, y+yo, z+zo);    
						//cube.tag = "cube1";
						Network.Instantiate(prefabCube1, new Vector3 (x + xo, y + yo, z + zo), Quaternion.identity, 0);
						//prefabCube1.tag = "cube" + counter.ToString(); 
						//counter++;
						//Debug.Log("x: " + (x+xo)); 
					}
				}
			}
			spawnedCubes = true;
		}
	}

	private Color randomColor () {

		//int x = Random.Range (0, 3);
		int min = 0; int max = 3 + 1;
		//GUIText gui; gui.text += Random.Range (min, max).ToString;
		return new Color(
			numList[Random.Range (min, max)],
			numList[Random.Range (min, max)],
			numList[Random.Range (min, max)]
		                 );

	}
}
