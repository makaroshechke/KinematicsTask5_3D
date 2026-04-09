using UnityEngine;
using TMPro;

public class Task123Physics3D : MonoBehaviour
{
    [Header("Объект движения")]
    public Transform ball;

    [Header("Панели")]
    public GameObject panelTask1;
    public GameObject panelTask2;
    public GameObject panelTask3;

    [Header("Масштаб движения")]
    public float scaleFactor = 0.5f;

    // Task1
    [Header("Task 1 UI")]
    public TMP_InputField inputSpeed1;
    public TMP_Text outputTime1;
    public TMP_Text outputDistance1;

    // Task2
    [Header("Task 2 UI")]
    public TMP_InputField inputStartCoord2;
    public TMP_InputField inputSpeed2;
    public TMP_Text outputTime2;
    public TMP_Text outputCoord2;
    public TMP_Text outputDistance2;

    // Task3
    [Header("Task 3 UI")]
    public TMP_InputField inputStartCoord3;
    public TMP_InputField inputAcceleration3;
    public TMP_InputField inputStartSpeed3;
    public TMP_Text outputTime3;
    public TMP_Text outputCoord3;
    public TMP_Text outputSpeed3;
    public TMP_Text outputDistance3;

    private Vector3 baseBallPosition;

    private bool isMoving = false;
    private int currentTask = 0;
    private float currentTime = 0f;

    private float speed1;

    private float startCoord2;
    private float speed2;

    private float startCoord3;
    private float acceleration3;
    private float startSpeed3;

    void Start()
    {
        baseBallPosition = ball.position;
        ResetMotion();
    }

    void Update()
    {
        if (!isMoving) return;

        currentTime += Time.deltaTime;

        if (currentTask == 1)
            UpdateTask1();
        else if (currentTask == 2)
            UpdateTask2();
        else if (currentTask == 3)
            UpdateTask3();
    }

    public void StartMotion()
    {
        if (panelTask1.activeSelf)
        {
            if (currentTask != 1)
            {
                bool ok = float.TryParse(inputSpeed1.text, out speed1);
                if (!ok) return;

                currentTask = 1;
                currentTime = 0f;
                ball.position = baseBallPosition;
            }

            isMoving = true;
        }
        else if (panelTask2.activeSelf)
        {
            if (currentTask != 2)
            {
                bool ok1 = float.TryParse(inputStartCoord2.text, out startCoord2);
                bool ok2 = float.TryParse(inputSpeed2.text, out speed2);
                if (!ok1 || !ok2) return;

                currentTask = 2;
                currentTime = 0f;
                ball.position = baseBallPosition + new Vector3(startCoord2 * scaleFactor, 0f, 0f);
            }

            isMoving = true;
        }
        else if (panelTask3.activeSelf)
        {
            if (currentTask != 3)
            {
                bool ok1 = float.TryParse(inputStartCoord3.text, out startCoord3);
                bool ok2 = float.TryParse(inputAcceleration3.text, out acceleration3);
                bool ok3 = float.TryParse(inputStartSpeed3.text, out startSpeed3);
                if (!ok1 || !ok2 || !ok3) return;

                currentTask = 3;
                currentTime = 0f;
                ball.position = baseBallPosition + new Vector3(startCoord3 * scaleFactor, 0f, 0f);
            }

            isMoving = true;
        }
    }

    public void PauseMotion()
    {
        isMoving = false;
    }

    public void ResetMotion()
    {
        isMoving = false;
        currentTime = 0f;
        currentTask = 0;
        ball.position = baseBallPosition;

        if (outputTime1 != null) outputTime1.text = "0.00";
        if (outputDistance1 != null) outputDistance1.text = "0.00";

        if (outputTime2 != null) outputTime2.text = "0.00";
        if (outputCoord2 != null) outputCoord2.text = "0.00";
        if (outputDistance2 != null) outputDistance2.text = "0.00";

        if (outputTime3 != null) outputTime3.text = "0.00";
        if (outputCoord3 != null) outputCoord3.text = "0.00";
        if (outputSpeed3 != null) outputSpeed3.text = "0.00";
        if (outputDistance3 != null) outputDistance3.text = "0.00";
    }

    private void UpdateTask1()
    {
        float s = Mathf.Abs(speed1 * currentTime);
        float xVisual = speed1 * currentTime;

        ball.position = baseBallPosition + new Vector3(xVisual * scaleFactor, 0f, 0f);

        if (outputTime1 != null) outputTime1.text = currentTime.ToString("F2");
        if (outputDistance1 != null) outputDistance1.text = s.ToString("F2");
    }

    private void UpdateTask2()
    {
        float x = startCoord2 + speed2 * currentTime;
        float s = Mathf.Abs(speed2 * currentTime);

        ball.position = baseBallPosition + new Vector3(x * scaleFactor, 0f, 0f);

        if (outputTime2 != null) outputTime2.text = currentTime.ToString("F2");
        if (outputCoord2 != null) outputCoord2.text = x.ToString("F2");
        if (outputDistance2 != null) outputDistance2.text = s.ToString("F2");
    }

    private void UpdateTask3()
    {
        float x = startCoord3 + startSpeed3 * currentTime + (acceleration3 * currentTime * currentTime) / 2f;
        float v = startSpeed3 + acceleration3 * currentTime;
        float s = Mathf.Abs(startSpeed3 * currentTime + (acceleration3 * currentTime * currentTime) / 2f);

        ball.position = baseBallPosition + new Vector3(x * scaleFactor, 0f, 0f);

        if (outputTime3 != null) outputTime3.text = currentTime.ToString("F2");
        if (outputCoord3 != null) outputCoord3.text = x.ToString("F2");
        if (outputSpeed3 != null) outputSpeed3.text = v.ToString("F2");
        if (outputDistance3 != null) outputDistance3.text = s.ToString("F2");
    }
}