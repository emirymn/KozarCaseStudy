using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variable
    public List<Transform> Items;
    public static GameManager instance;
    [SerializeField] private int totalPoint;

    [SerializeField] GameObject EndGamePanel;
    [SerializeField] TextMeshProUGUI pointText;
    #endregion
    
    private void Awake()
    {
        instance = this;
    }

    public void UpdatePoint(int point)
    {
        totalPoint += point;
    }

    private void Update()
    {
        FinishTheGame();
    }

    void FinishTheGame()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3.5f))
        {
            if (hit.transform.CompareTag("Exit") && Input.GetKey(KeyCode.E))
            {
                pointText.text = "Puanınız: " + totalPoint;
                CameraSystem.instance.enabled = false;
                Movement.instance.enabled = false;
                EndGamePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
