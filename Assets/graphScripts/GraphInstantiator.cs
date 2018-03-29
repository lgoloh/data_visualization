using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class GraphInstantiator : MonoBehaviour
{

    public GameObject Cube;
    private Vector3 cubeLoc = new Vector3(0f, 0f, 0.5f);

    public float initGrowSpeed = 5f;

    private float growSpeed;

    public float growAcceleration = 0.2f;
    public float growDecellerationPoint = 0.4f;
    public float allowError = 0.001f;

    float[] values = {11, 5, 9, 15, 60 };
    float[] initGrowSpeeds;// = { 10, 20, 40 };

    void Start()
    {
        DisplayGraph(values);
        initGrowSpeeds = values;
    }

    //called every frame
    void Update()
    {
        for (int i = 0; i < values.Length; i++)
        {
            string cubeName = "Cube " + i.ToString();
            GameObject GO = GameObject.Find(cubeName);

            //if the height of the cube is less than the value
            if (GO.transform.localScale.y <= (values[i] - allowError))
            {
                //set height of the frame 
                float cubeHeight = GO.transform.localScale.y;
                float growSpeed = initGrowSpeeds[i];

                if (cubeHeight >= (growDecellerationPoint * values[i]))
                {
                    growSpeed = initGrowSpeeds[i] - initGrowSpeeds[i] * (1 - ((cubeHeight - values[i]) /
                        (growDecellerationPoint * values[i] - values[i])));
                }

                float prevCubeHeight = GO.transform.localScale.y;
                GO.transform.localScale += new Vector3(0f, growSpeed, 0f) * Time.deltaTime;
                float newCubeHeight = GO.transform.localScale.y;
                GO.transform.position += Vector3.up * (newCubeHeight - prevCubeHeight) / 2;
            }
        }
    }

    void DisplayGraph(float[] values)
    {
        //sets the original location of each cube.
        Vector3 cubeLocInitPos = cubeLoc;
        for (int i = 0; i < values.Length; i++)  //for each cube given the dataset 
        {
            cubeLoc = cubeLocInitPos + Vector3.right * 2 * i;  //set the position of the cube 
            GameObject newBar = Instantiate(Cube, cubeLoc, Quaternion.identity) as GameObject; //creates the cube at that location
            Transform tf = newBar.GetComponent<Transform>();
            Debug.Log(cubeLoc.ToString());
            Debug.Log("{0}");

            newBar.name = "Cube " + i.ToString();
        }
    }
}



