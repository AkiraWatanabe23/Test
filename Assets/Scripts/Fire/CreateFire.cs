using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{

    [Header("��������I�u�W�F�N�g"),SerializeField] private GameObject _createObject;
    public float _minTime;
    public float _maxTime;
    public float _xMinPosition;
    public float _xMaxPosition;
    private float _interval; //�������ԊԊu
    private float _time; //�o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        _interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if(_time > _interval)
        {
            GameObject fire = Instantiate(_createObject);
            fire.transform.position = GetRandomPosition();
            _time = 0;
            _interval = GetRandomTime();
        }
    }

    private float GetRandomTime()
    {
        return Random.Range(_minTime, _maxTime);
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(_xMinPosition, _xMaxPosition);

        return new Vector2(x, 15f);
    }
}
