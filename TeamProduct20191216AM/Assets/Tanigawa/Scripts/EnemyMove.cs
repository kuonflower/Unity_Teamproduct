using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{

  //  [SerializeField] private PlayerController playerController;

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void OnDetectObject(Collider collider)
    {
        //検知したオブジェクトに「Player」tagが付いてたらそのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            _agent.destination = collider.transform.position;
        }
    }

   /* // Update is called once per frame
    void Update()
    {
        _agent.destination = playerController.transform.position;
    }*/
}
