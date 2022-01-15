using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

	private Explodable _explodable;
	[SerializeField] ExplosionForce explosionForcePrefab;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}
	void OnMouseDown()
	{
		_explodable.explode();

		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); pos.z = 0f;
		ExplosionForce ef = Instantiate(explosionForcePrefab, pos, Quaternion.identity);
		ef.doExplosion(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
