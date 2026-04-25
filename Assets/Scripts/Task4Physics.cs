using UnityEngine;
using TMPro;

public class Task4Physics3D : MonoBehaviour
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
    [Header("Task 4.1 UI")]
    public TMP_InputField inputVx1;
    public TMP_InputField inputVy1;
    public TMP_Text outputTime1;
    public TMP_Text outputDistance1;
    public TMP_Text outputCoordX1;
    public TMP_Text outputCoordY1;

    // Task2
    [Header("Task 4.2 UI")]
    public TMP_InputField inputX0_2;
    public TMP_InputField inputY0_2;
    public TMP_InputField inputVx2;
    public TMP_InputField inputVy2;
    public TMP_Text outputTime2;
    public TMP_Text outputDistance2;
    public TMP_Text outputCoordX2;
    public TMP_Text outputCoordY2;

    // Task3
    [Header("Task 4.3 UI")]
    public TMP_InputField inputX0_3;
    public TMP_InputField inputY0_3;
    public TMP_InputField inputVx0_3;
    public TMP_InputField inputVy0_3;
    public TMP_InputField inputAx3;
    public TMP_InputField inputAy3;
    public TMP_Text outputTime3;
    public TMP_Text outputDistance3;
    public TMP_Text outputCoordX3;
    public TMP_Text outputCoordY3;
    public TMP_Text outputSpeed3;

    private Vector3 baseBallPosition;

    private bool isMoving = false;
    private int currentTask = 0;
    private float currentTime = 0f;

    // Task1
    private float vx1, vy1;

    // Task2
    private float x0_2, y0_2, vx2, vy2;

    // Task3
    private float x0_3, y0_3, vx0_3, vy0_3, ax3, ay3;

    // Накопленный путь для Task3
    private float accumulatedDistance3;

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
                bool ok1 = float.TryParse(inputVx1.text, out vx1);
                bool ok2 = float.TryParse(inputVy1.text, out vy1);
                if (!ok1 || !ok2) return;

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
                bool ok1 = float.TryParse(inputX0_2.text, out x0_2);
                bool ok2 = float.TryParse(inputY0_2.text, out y0_2);
                bool ok3 = float.TryParse(inputVx2.text, out vx2);
                bool ok4 = float.TryParse(inputVy2.text, out vy2);
                if (!ok1 || !ok2 || !ok3 || !ok4) return;

                currentTask = 2;
                currentTime = 0f;
                ball.position = new Vector3(
                    baseBallPosition.x + x0_2 * scaleFactor,
                    baseBallPosition.y,
                    baseBallPosition.z + y0_2 * scaleFactor
                );
            }

            isMoving = true;
        }
        else if (panelTask3.activeSelf)
        {
            if (currentTask != 3)
            {
                bool ok1 = float.TryParse(inputX0_3.text, out x0_3);
                bool ok2 = float.TryParse(inputY0_3.text, out y0_3);
                bool ok3 = float.TryParse(inputVx0_3.text, out vx0_3);
                bool ok4 = float.TryParse(inputVy0_3.text, out vy0_3);
                bool ok5 = float.TryParse(inputAx3.text, out ax3);
                bool ok6 = float.TryParse(inputAy3.text, out ay3);
                if (!ok1 || !ok2 || !ok3 || !ok4 || !ok5 || !ok6) return;

                currentTask = 3;
                currentTime = 0f;
                accumulatedDistance3 = 0f;
                ball.position = new Vector3(
                    baseBallPosition.x + x0_3 * scaleFactor,
                    baseBallPosition.y,
                    baseBallPosition.z + y0_3 * scaleFactor
                );
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
        accumulatedDistance3 = 0f;

        if (outputTime1 != null) outputTime1.text = "0.00";
        if (outputDistance1 != null) outputDistance1.text = "0.00";
        if (outputCoordX1 != null) outputCoordX1.text = "0.00";
        if (outputCoordY1 != null) outputCoordY1.text = "0.00";

        if (outputTime2 != null) outputTime2.text = "0.00";
        if (outputDistance2 != null) outputDistance2.text = "0.00";
        if (outputCoordX2 != null) outputCoordX2.text = "0.00";
        if (outputCoordY2 != null) outputCoordY2.text = "0.00";

        if (outputTime3 != null) outputTime3.text = "0.00";
        if (outputDistance3 != null) outputDistance3.text = "0.00";
        if (outputCoordX3 != null) outputCoordX3.text = "0.00";
        if (outputCoordY3 != null) outputCoordY3.text = "0.00";
        if (outputSpeed3 != null) outputSpeed3.text = "0.00";
    }

    private void UpdateTask1()
    {
        float x = vx1 * currentTime;
        float y = vy1 * currentTime;

        float s = Mathf.Sqrt(x * x + y * y);

        ball.position = new Vector3(
            baseBallPosition.x + x * scaleFactor,
            baseBallPosition.y,
            baseBallPosition.z + y * scaleFactor
        );

        if (outputTime1 != null) outputTime1.text = currentTime.ToString("F2");
        if (outputDistance1 != null) outputDistance1.text = s.ToString("F2");
        if (outputCoordX1 != null) outputCoordX1.text = x.ToString("F2");
        if (outputCoordY1 != null) outputCoordY1.text = y.ToString("F2");
    }

    private void UpdateTask2()
    {
        float x = x0_2 + vx2 * currentTime;
        float y = y0_2 + vy2 * currentTime;

        float dx = vx2 * currentTime;
        float dy = vy2 * currentTime;

        float s = Mathf.Sqrt(dx * dx + dy * dy);

        ball.position = new Vector3(
            baseBallPosition.x + x * scaleFactor,
            baseBallPosition.y,
            baseBallPosition.z + y * scaleFactor
        );

        if (outputTime2 != null) outputTime2.text = currentTime.ToString("F2");
        if (outputDistance2 != null) outputDistance2.text = s.ToString("F2");
        if (outputCoordX2 != null) outputCoordX2.text = x.ToString("F2");
        if (outputCoordY2 != null) outputCoordY2.text = y.ToString("F2");
    }

    private void UpdateTask3()
    {
        float x = x0_3 + vx0_3 * currentTime + (ax3 * currentTime * currentTime) / 2f;
        float y = y0_3 + vy0_3 * currentTime + (ay3 * currentTime * currentTime) / 2f;

        float vx = vx0_3 + ax3 * currentTime;
        float vy = vy0_3 + ay3 * currentTime;

        float v = Mathf.Sqrt(vx * vx + vy * vy);

        accumulatedDistance3 += v * Time.deltaTime;

        ball.position = new Vector3(
            baseBallPosition.x + x * scaleFactor,
            baseBallPosition.y,
            baseBallPosition.z + y * scaleFactor
        );

        if (outputTime3 != null) outputTime3.text = currentTime.ToString("F2");
        if (outputDistance3 != null) outputDistance3.text = accumulatedDistance3.ToString("F2");
        if (outputCoordX3 != null) outputCoordX3.text = x.ToString("F2");
        if (outputCoordY3 != null) outputCoordY3.text = y.ToString("F2");
        if (outputSpeed3 != null) outputSpeed3.text = v.ToString("F2");
    }
}
