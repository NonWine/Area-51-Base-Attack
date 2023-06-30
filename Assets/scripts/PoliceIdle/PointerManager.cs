using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerManager : MonoBehaviour {

    [SerializeField] PointerIcon _pointerPrefab;
    private Dictionary<EnemyPointer, PointerIcon> _dictionary = new Dictionary<EnemyPointer, PointerIcon>();
    [SerializeField] Transform _playerTransform;
    [SerializeField] Camera _camera;
    [SerializeField] private GameObject[] arrows;
    public static PointerManager Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void AddToList(EnemyPointer enemyPointer) {
        PointerIcon newPointer = Instantiate(_pointerPrefab, transform);
        _dictionary.Add(enemyPointer, newPointer);
    }

    public void RemoveFromList(EnemyPointer enemyPointer) {
        Destroy(_dictionary[enemyPointer].gameObject);
        _dictionary.Remove(enemyPointer);
    }

    void LateUpdate() {

        // Left, Right, Down, Up
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        
        foreach (var kvp in _dictionary) {

            EnemyPointer enemyPointer = kvp.Key;
            PointerIcon pointerIcon = kvp.Value;

            Vector3 toEnemy = enemyPointer.transform.position - _playerTransform.position;
            Ray ray = new Ray(_playerTransform.position, toEnemy);
            Debug.DrawRay(_playerTransform.position, toEnemy);


            float rayMinDistance = Mathf.Infinity;
            int index = 0;

            for (int p = 0; p < 5; p++) {
                if (planes[p].Raycast(ray, out float distance)) {
                    if (distance < rayMinDistance + 300f) {
                        rayMinDistance = distance;
                        index = p;
                    }
                }
            }

            rayMinDistance = Mathf.Clamp(rayMinDistance, 0, toEnemy.magnitude);
            Vector3 worldPosition = ray.GetPoint(rayMinDistance);
            Vector3 position = _camera.WorldToScreenPoint(worldPosition);
            GetIconRotation(index);
            // Quaternion rotation = GetIconRotation(ind);

            //if (toEnemy.magnitude > rayMinDistance) {
            //    pointerIcon.Show();
            //} else {
            //    pointerIcon.Hide();
            //}

            //pointerIcon.SetIconPosition(position, rotation);
        }

    }

    public void OffManager()
    {
        foreach (var item in arrows)
        {
            item.gameObject.SetActive(false);
        }
        enabled = false;
    }

    void GetIconRotation(int planeIndex)
    {
        if(planeIndex == 3)
        {
            arrows[0].SetActive(false);
            arrows[1].SetActive(false);
            arrows[2].SetActive(false);

        }
       else  if (planeIndex == 0)
        {
            arrows[0].SetActive(true);
            arrows[1].SetActive(false);
            arrows[2].SetActive(false);
            Debug.Log("0"); // right
        }
        else if (planeIndex == 1)
        {
            Debug.Log("1");// left
            arrows[1].SetActive(true);
            arrows[2].SetActive(false);
            arrows[0].SetActive(false);
        }
        else if (planeIndex == 2)
        {
            arrows[2].SetActive(true);
            arrows[1].SetActive(false);
            arrows[0].SetActive(false);
        }


        //if (planeIndex == 0)
        //{
        //    return Quaternion.Euler(0f, 0f, 90f);
        //}
        //else if (planeIndex == 1)
        //{
        //    return Quaternion.Euler(0f, 0f, -90f);
        //}
        //else if (planeIndex == 2)
        //{
        //    return Quaternion.Euler(0f, 0f, 180);
        //}
        //else if (planeIndex == 3)
        //{
        //    return Quaternion.Euler(0f, 0f, 0f);
        //}
        //return Quaternion.identity;


    }

}
