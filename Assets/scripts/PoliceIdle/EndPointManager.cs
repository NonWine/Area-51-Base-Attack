using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _routes;
    private int id;
    private List<Transform> _points = new List<Transform>();

    public Transform GetStartRoute(int id)
    {
        for (int i = 0; i < _routes[id].transform.childCount; i++)
        {
            _points.Add(_routes[id].transform.GetChild(i));
            Debug.Log(_points[i]);
        }
        return _points[this.id];
    }

    public Transform ChangeEndPoint()
    {
        return _points[id];
    }

    public bool isEndPoint()
    {
        id++;
        if (id >= _points.Count)
            return true;
        else
            return false;
    }
}
