using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteBtnScript : MonoBehaviour
{
    public Button btn;
    public Text reportLarge;
    public Text reportSmall;
    public Text timeLapsedSmall;
    public Text velocitySmall;
    public Text velocityLarge;
    private GameObject theBall, secondBall;

    private List<float> timersSmall, timersLarge;
    private List<float> positionsSmall, positionsLarge;

    private float lastClickTimeSmall = -1;


    void Start()
    {
        timersLarge = new List<float>();
        positionsLarge = new List<float>();

        timersSmall = new List<float>();
        positionsSmall = new List<float>();

        theBall = GameObject.Find("Ball1");
        secondBall = GameObject.Find("Ball2");


        btn.onClick.AddListener(TaskOnClick);

        reportLarge.text = "Large X = ...";
        reportSmall.text = "Small X = ...";
        velocityLarge.text = "Large V = ...";
        velocitySmall.text = "Small V = ...";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timersSmall.Add(lastClickTimeSmall > 0 ? Time.time - lastClickTimeSmall : Time.time);

            positionsSmall.Add(secondBall.GetComponent<Transform>().position.x);
            positionsLarge.Add(theBall.GetComponent<Transform>().position.x);
  
        }
    }

    void TaskOnClick()
    {
        Debug.Log("CLICKED BUTTON");
        reportLarge.text = "Large X = " + positionsLarge[positionsLarge.Count - 1].ToString();
        reportSmall.text = "Small X = " + positionsSmall[positionsSmall.Count - 1].ToString();
        timeLapsedSmall.text = "Small t = " + timersSmall[timersSmall.Count - 1].ToString();
        velocityLarge.text = "Large V = " + Velocity(positionsLarge, timersSmall).ToString();
        velocitySmall.text = "Small V = " + Velocity(positionsSmall, timersSmall).ToString();
        Debug.Log("Time lapsed: " + timersSmall[timersSmall.Count - 1]);
    }

    float Velocity(List<float> position, List<float> timer)
    {
        // Calculate velocity based on the collected data
        int lastIndex = timer.Count - 1;
        if (lastIndex > 0)
        {
            float X0 = position[0];
            float X = position[lastIndex];
            float t = timer[lastIndex] - timer[0];
            return (X - X0) / t;
        }
        else
        {
            return 0f; // No data collected yet
        }
    }
}
