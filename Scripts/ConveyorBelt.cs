using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	public GameObject conveyorBelt;
	public Transform endPoint;
	public float speed;

	void OnTriggerStay(Collider other)//Parametre trigger icindeki objeleri temsil ediyor.
	{
		other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
	}
}
