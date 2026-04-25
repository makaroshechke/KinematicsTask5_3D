using UnityEngine;

public class Task5PanelController : MonoBehaviour
{
    public GameObject panelTask1;
    public GameObject panelTask2;
    public GameObject panelTask3;

    public Task5Physics physicsController;

    void Start()
    {
        OpenTask1();
    }

    public void OpenTask1()
    {
        panelTask1.SetActive(true);
        panelTask2.SetActive(false);
        panelTask3.SetActive(false);

        if (physicsController != null)
            physicsController.ResetMotion();
    }

    public void OpenTask2()
    {
        panelTask1.SetActive(false);
        panelTask2.SetActive(true);
        panelTask3.SetActive(false);

        if (physicsController != null)
            physicsController.ResetMotion();
    }

    public void OpenTask3()
    {
        panelTask1.SetActive(false);
        panelTask2.SetActive(false);
        panelTask3.SetActive(true);

        if (physicsController != null)
            physicsController.ResetMotion();
    }
}
