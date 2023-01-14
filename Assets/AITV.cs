
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITV : MonoBehaviour
{

    private NavMeshAgent _agent;
    public List<Transform> point;
    private int currentIndex;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        currentIndex = 0;
    }

    private void Update()
    {
        Debug.Log(currentIndex);
        if (Vector3.Distance(this.transform.position, point[currentIndex].position) < 1f)
        {
            currentIndex = Random.Range(0, point.Count - 1);
        }
        else
        {
            _agent.SetDestination(point[currentIndex].position);
        }

    }
}
