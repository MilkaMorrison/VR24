
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRTest : MonoBehaviour
{
    public GameObject cube; // ������ �� ���
    public GameObject sphere; // ������ �� �����
    public Button toggleButton; // ������ �� ������

    private Renderer cubeRenderer;
    private Color targetColor;
    private bool isCubeVisible = true;
    private float jumpHeight = 1.5f; // ������ ������ (3 ������� �����)
    private float jumpSpeed = 5.0f; // �������� ������
    private Vector3 initialPosition; // �������� ������� �����

    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        targetColor = Random.ColorHSV();

        // ������������� ��������� ������� �����
        initialPosition = sphere.transform.position;

        toggleButton.onClick.AddListener(ToggleCubeVisibility);
    }

    void Update()
    {
        // ������ ���� ����
        if (isCubeVisible)
        {
            cubeRenderer.material.color = Color.Lerp(cubeRenderer.material.color, targetColor, Time.deltaTime);
            if (Mathf.Abs(cubeRenderer.material.color.r - targetColor.r) < 0.1f &&
                Mathf.Abs(cubeRenderer.material.color.g - targetColor.g) < 0.1f &&
                Mathf.Abs(cubeRenderer.material.color.b - targetColor.b) < 0.1f)
            {
                targetColor = Random.ColorHSV();
            }

            // ���������� �������� �����
            JumpSphere();
        }
    }

    void JumpSphere()
    {
        // ��������� ����� ������ ��� ������
        float newY = initialPosition.y + Mathf.Sin(Time.time * jumpSpeed) * jumpHeight;
        newY = Mathf.Max(newY, 0);
        sphere.transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    void ToggleCubeVisibility()
    {
        isCubeVisible = !isCubeVisible;
        cube.SetActive(isCubeVisible);

        if (isCubeVisible)
        {
            sphere.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            sphere.GetComponent<Renderer>().material.color = Color.red;
            // �������� �� �����
            sphere.transform.position = initialPosition; // �������� �� �������� �������
        }
    }
}