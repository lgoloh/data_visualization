using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public GameObject Cube;
    private Vector3 target = new Vector3(0f, 0f, 0f);
    private Vector3 pos = new Vector3(-1.33f, -0.73f, 50f);
    private Vector3 relativePos;
    float radius = 4f;
    float[] data_set = {12, 5, 5, 3, 3, 3, 3, 2, 2, 62};
    float[] initGrowSpeeds;
    public float growAcceleration = 0.2f;
    public float growDecellerationPoint = 0.4f;

    void Start()
    {
        DrawGraph();
        initGrowSpeeds = data_set;
        //pos = Vector3.right * 2;
        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);
        //GameObject newPoint = Instantiate(Cube, pos, transform.rotation) as GameObject;  
    }


    void Update()

    {
        for (int i = 0; i < data_set.Length; i++)
        {
            string cubeName = "Cube " + i.ToString();
            GameObject GO = GameObject.Find(cubeName);

            //if the height of the cube is less than its value in the data set
            if (GO.transform.localScale.y <= (data_set[i]))
            {
                //set height of the frame 
                float cubeHeight = GO.transform.localScale.y;
                Debug.Log("Height of this cube " + cubeHeight.ToString());
                float growSpeed = initGrowSpeeds[i];
                Debug.Log("Growth Speed " + growSpeed.ToString());

                if (cubeHeight >= (growDecellerationPoint * data_set[i]))
                {
                    growSpeed = initGrowSpeeds[i] - initGrowSpeeds[i] * (1 - ((cubeHeight - data_set[i]) /
                        (growDecellerationPoint * data_set[i] - data_set[i])));
                }

                //set the previous height of the bar to the original height (1.0 in the beginning)
                float prevCubeHeight = GO.transform.localScale.y;
                Debug.Log(prevCubeHeight.ToString());
                Debug.Log("Prev Scale " + (GO.transform.localScale).ToString());
                //increment the scale by the (size of the data * Time.delta) each second   
                GO.transform.localScale += new Vector3(0f, growSpeed, 0f) * Time.deltaTime;
                Debug.Log("New Scale " + (GO.transform.localScale).ToString());
                //set the new height of the bar to the new value of the y value of the scale
                float newCubeHeight = GO.transform.localScale.y;
                Debug.Log(newCubeHeight.ToString());
                //set the new position, taking the new height into consideration
                GO.transform.position += Vector3.up * (newCubeHeight - prevCubeHeight) / 2;
                Debug.Log((GO.transform.position).ToString());

            }
        }
    }

    void DrawGraph()
    {
        for (int i = 0; i < data_set.Length; i++)
        {
            float angle = i*Mathf.PI * 2f / 10;
            //Debug.Log((angle*Mathf.Rad2Deg).ToString());
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius) + pos;
            GameObject newBar = Instantiate(Cube, newPos, Quaternion.identity);  //Quaternion.identity means no rotation
            //Debug.Log(newPos.ToString());
            //Debug.Log("{0}");

            newBar.name = "Cube " + i.ToString();
        }
        

    }

}
