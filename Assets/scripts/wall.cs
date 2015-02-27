using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

	public Transform prefabCube1;
	private float[] numList = {.2f,.4f,.6f,.8f};
    public GUIText gui; 
	// Use this for initialization
	void Start () {
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
                    GameObject c = (GameObject)Instantiate(prefabCube1, new Vector3(x + xo, y + yo, z + zo), Quaternion.identity);
					//prefabCube1.tag = "cube" + counter.ToString(); 
					//counter++;
					c.renderer.material.color = randomColor();
					//Debug.Log("x: " + (x+xo)); 
				}
			}
		}


	}
	// Update is called once per frame 
	void Update () {

	}

	private Color randomColor () {

		//int x = Random.Range (0, 3);
		int min = 0; int max = 3 + 1;
        int x = Random.Range(min, max), y = Random.Range(min, max), z = Random.Range(min, max);
        gui.text += x.ToString() + y.ToString() + z.ToString() + ",";
		return new Color(
			numList[x],
			numList[y],
			numList[z]
		                 );

	}
}
