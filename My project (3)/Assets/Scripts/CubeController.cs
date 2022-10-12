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
        // если конечная позиция != положению куба, то куб движется. 
        if (endPosition.x != transform.position.x)
            Move(speed, distance);
        // иначе делаем куб невидимым и запускаем таймер, по истеченю которого обнуляем все переменные
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

    // метод движения куба (за 1 секунду куб проходит расстояние, равное переменной speed)
    void Move(float speed,float distance)
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, progress);
        // для корректной работы шага progress необходимо учитывать всё расстояние между начальним и конечным положением.
        progress += speed*Time.deltaTime  / (endPosition.x-startPosition.x);
    }
    // метод смены формата (string->float) и назначанения переменных с текстовых полей.
    public void setValues()
    {
        this.speed = float.Parse(textSpeed.text);
        this.distance = float.Parse(textDistance.text);
        this.time = float.Parse(textTime.text);
        endPosition.x = startPosition.x + distance;
    }
}
