using UnityEngine;
using TMPro;

public class Task5Physics : MonoBehaviour
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
    public TMP_InputField inputVx1;
    public TMP_InputField inputVy1;
    public TMP_InputField inputVz1;

    public TMP_Text outputTime1;
    public TMP_Text outputDistance1;
    public TMP_Text outputX1;
    public TMP_Text outputY1;
    public TMP_Text outputZ1;

    // Task2
    [Header("Task 2 UI")]
    public TMP_InputField inputVx2;
    public TMP_InputField inputVy2;
    public TMP_InputField inputVz2;
    public TMP_InputField inputX0_2;
    public TMP_InputField inputY0_2;
    public TMP_InputField inputZ0_2;

    public TMP_Text outputTime2;
    public TMP_Text outputDistance2;
    public TMP_Text outputX2;
    public TMP_Text outputY2;
    public TMP_Text outputZ2;

    // Task3
    [Header("Task 3 UI")]
    public TMP_InputField inputVx0_3;
    public TMP_InputField inputVy0_3;
    public TMP_InputField inputVz0_3;
    public TMP_InputField inputX0_3;
    public TMP_InputField inputY0_3;
    public TMP_InputField inputZ0_3;
    public TMP_InputField inputAx3;
    public TMP_InputField inputAy3;
    public TMP_InputField inputAz3;

    public TMP_Text outputTime3;
    public TMP_Text outputDistance3;
    public TMP_Text outputSpeed3;
    public TMP_Text outputX3;
    public TMP_Text outputY3;
    public TMP_Text outputZ3;

    private Vector3 baseBallPosition;

    private bool isMoving = false;
    private int currentTask = 0;
    private float currentTime = 0f;

    // Параметры Task1
    private float vx1, vy1, vz1;

    // Параметры Task2
    private float vx2, vy2, vz2;
    private float x0_2, y0_2, z0_2;

    // Параметры Task3
    private float vx0_3, vy0_3, vz0_3;
    private float x0_3, y0_3, z0_3;
    private float ax3, ay3, az3;

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
            StartTask1();
        }
        else if (panelTask2.activeSelf)
        {
            StartTask2();
        }
        else if (panelTask3.activeSelf)
        {
            StartTask3();
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
        if (outputX1 != null) outputX1.text = "0.00";
        if (outputY1 != null) outputY1.text = "0.00";
        if (outputZ1 != null) outputZ1.text = "0.00";

        if (outputTime2 != null) outputTime2.text = "0.00";
        if (outputDistance2 != null) outputDistance2.text = "0.00";
        if (outputX2 != null) outputX2.text = "0.00";
        if (outputY2 != null) outputY2.text = "0.00";
        if (outputZ2 != null) outputZ2.text = "0.00";

        if (outputTime3 != null) outputTime3.text = "0.00";
        if (outputDistance3 != null) outputDistance3.text = "0.00";
        if (outputSpeed3 != null) outputSpeed3.text = "0.00";
        if (outputX3 != null) outputX3.text = "0.00";
        if (outputY3 != null) outputY3.text = "0.00";
        if (outputZ3 != null) outputZ3.text = "0.00";
    }

    private void StartTask1()
    {
        if (currentTask != 1)
        {
            bool ok1 = float.TryParse(inputVx1.text, out vx1);
            bool ok2 = float.TryParse(inputVy1.text, out vy1);
            bool ok3 = float.TryParse(inputVz1.text, out vz1);

            if (!ok1 || !ok2 || !ok3) return;

            currentTask = 1;
            currentTime = 0f;
            ball.position = baseBallPosition;
        }

        isMoving = true;
    }

    private void StartTask2()
    {
        if (currentTask != 2)
        {
            bool ok1 = float.TryParse(inputVx2.text, out vx2);
            bool ok2 = float.TryParse(inputVy2.text, out vy2);
            bool ok3 = float.TryParse(inputVz2.text, out vz2);
            bool ok4 = float.TryParse(inputX0_2.text, out x0_2);
            bool ok5 = float.TryParse(inputY0_2.text, out y0_2);
            bool ok6 = float.TryParse(inputZ0_2.text, out z0_2);

            if (!ok1 || !ok2 || !ok3 || !ok4 || !ok5 || !ok6) return;

            currentTask = 2;
            currentTime = 0f;

            ball.position = baseBallPosition + new Vector3(
                x0_2 * scaleFactor,
                y0_2 * scaleFactor,
                z0_2 * scaleFactor
            );
        }

        isMoving = true;
    }

    private void StartTask3()
    {
        if (currentTask != 3)
        {
            bool ok1 = float.TryParse(inputVx0_3.text, out vx0_3);
            bool ok2 = float.TryParse(inputVy0_3.text, out vy0_3);
            bool ok3 = float.TryParse(inputVz0_3.text, out vz0_3);

            bool ok4 = float.TryParse(inputX0_3.text, out x0_3);
            bool ok5 = float.TryParse(inputY0_3.text, out y0_3);
            bool ok6 = float.TryParse(inputZ0_3.text, out z0_3);

            bool ok7 = float.TryParse(inputAx3.text, out ax3);
            bool ok8 = float.TryParse(inputAy3.text, out ay3);
            bool ok9 = float.TryParse(inputAz3.text, out az3);

            if (!ok1 || !ok2 || !ok3 || !ok4 || !ok5 || !ok6 || !ok7 || !ok8 || !ok9) return;

            currentTask = 3;
            currentTime = 0f;
            accumulatedDistance3 = 0f;

            ball.position = baseBallPosition + new Vector3(
                x0_3 * scaleFactor,
                y0_3 * scaleFactor,
                z0_3 * scaleFactor
            );
        }

        isMoving = true;
    }

    private void UpdateTask1()
    {
        float x = vx1 * currentTime;
        float y = vy1 * currentTime;
        float z = vz1 * currentTime;

        float s = Mathf.Sqrt(x * x + y * y + z * z);

        ball.position = baseBallPosition + new Vector3(
            x * scaleFactor,
            y * scaleFactor,
            z * scaleFactor
        );

        if (outputTime1 != null) outputTime1.text = currentTime.ToString("F2");
        if (outputDistance1 != null) outputDistance1.text = s.ToString("F2");
        if (outputX1 != null) outputX1.text = x.ToString("F2");
        if (outputY1 != null) outputY1.text = y.ToString("F2");
        if (outputZ1 != null) outputZ1.text = z.ToString("F2");
    }

    private void UpdateTask2()
    {
        float x = x0_2 + vx2 * currentTime;
        float y = y0_2 + vy2 * currentTime;
        float z = z0_2 + vz2 * currentTime;

        float dx = vx2 * currentTime;
        float dy = vy2 * currentTime;
        float dz = vz2 * currentTime;

        float s = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);

        ball.position = baseBallPosition + new Vector3(
            x * scaleFactor,
            y * scaleFactor,
            z * scaleFactor
        );

        if (outputTime2 != null) outputTime2.text = currentTime.ToString("F2");
        if (outputDistance2 != null) outputDistance2.text = s.ToString("F2");
        if (outputX2 != null) outputX2.text = x.ToString("F2");
        if (outputY2 != null) outputY2.text = y.ToString("F2");
        if (outputZ2 != null) outputZ2.text = z.ToString("F2");
    }

    private void UpdateTask3()
    {
        float x = x0_3 + vx0_3 * currentTime + (ax3 * currentTime * currentTime) / 2f;
        float y = y0_3 + vy0_3 * currentTime + (ay3 * currentTime * currentTime) / 2f;
        float z = z0_3 + vz0_3 * currentTime + (az3 * currentTime * currentTime) / 2f;

        float vx = vx0_3 + ax3 * currentTime;
        float vy = vy0_3 + ay3 * currentTime;
        float vz = vz0_3 + az3 * currentTime;

        float v = Mathf.Sqrt(vx * vx + vy * vy + vz * vz);

        accumulatedDistance3 += v * Time.deltaTime;

        ball.position = baseBallPosition + new Vector3(
            x * scaleFactor,
            y * scaleFactor,
            z * scaleFactor
        );

        if (outputTime3 != null) outputTime3.text = currentTime.ToString("F2");
        if (outputDistance3 != null) outputDistance3.text = accumulatedDistance3.ToString("F2");
        if (outputSpeed3 != null) outputSpeed3.text = v.ToString("F2");
        if (outputX3 != null) outputX3.text = x.ToString("F2");
        if (outputY3 != null) outputY3.text = y.ToString("F2");
        if (outputZ3 != null) outputZ3.text = z.ToString("F2");
    }
}
