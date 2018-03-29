using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangGraph : MonoBehaviour {

    public GameObject Cube;
    private Vector3 startLocation = new Vector3(5, 0, 0);
    float radius = 2f;
    int[] values = { 12, 5, 5, 3, 3, 3, 3, 2, 2, 62 };
    private Vector3 barLocation;


	// Use this for initialization
	void Awake () {

        Vector3 initbarLocation = startLocation;

        for (int i = 0; i < values.Length; i++)
        {
            barLocation = startLocation; 
            GameObject newBar = Instantiate(Cube);
            newBar.transform.localPosition = Vector3.up * i;
            newBar.transform.localScale = Vector3.one / 5f;
            transform.Rotate(Vector3.right, Time.deltaTime);


        }

    }


}
