using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    MeshRenderer mesh;
    Vector3 startPosition;
    Vector3 endPosition = new Vector3(10f,0f,0f);
    public Text textSpeed;
    public Text textDistance;
    public Text textTime;
    public float time = 0;
    public float distance = 0;
    public float speed = 0;
    float progress;

    private void Start()
    {
        startPosition = transform.position;
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
    void FixedUpdate()
    {
        // ���� �������� ������� != ��������� ����, �� ��� ��������. 
        if (endPosition.x != transform.position.x)
            Move(speed, distance);
        // ����� ������ ��� ��������� � ��������� ������, �� �������� �������� �������� ��� ����������
        else
        {
            mesh.enabled = false;
            time -= Time.deltaTime;
            if (time == 0f || time < 0f)
            {
                time = 0f;
                speed = 0f;
                distance = 0f;
                progress = 0;
                transform.position = startPosition;
                endPosition = new Vector3(10f, 0f, 0f);
                mesh.enabled = true;
            }
        }
    }

    // ����� �������� ���� (�� 1 ������� ��� �������� ����������, ������ ���������� speed)
    void Move(float speed,float distance)
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, progress);
        // ��� ���������� ������ ���� progress ���������� ��������� �� ���������� ����� ��������� � �������� ����������.
        progress += speed*Time.deltaTime  / (endPosition.x-startPosition.x);
    }
    // ����� ����� ������� (string->float) � ������������ ���������� � ��������� �����.
    public void setValues()
    {
        this.speed = float.Parse(textSpeed.text);
        this.distance = float.Parse(textDistance.text);
        this.time = float.Parse(textTime.text);
        endPosition.x = startPosition.x + distance;
    }
}
