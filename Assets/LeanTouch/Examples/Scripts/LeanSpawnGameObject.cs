using UnityEngine;

namespace Lean.Touch
{
	// This script can be used to spawn a GameObject via an event
	public class LeanSpawnGameObject : MonoBehaviour
	{
		[Tooltip("The prefab that gets spawned")]
		public GameObject Prefab;

		[Tooltip("The distance from the finger the prefab will be spawned in world space")]
		public float FingerDistance = 10.0f;
		
		public void Spawn()
		{
			if (Prefab != null)
			{
				Instantiate(Prefab, transform.position, transform.rotation);
			}
		}

		public void Spawn(LeanFinger finger)
		{
			if (finger != null && Prefab != null)
			{
				Instantiate(Prefab, finger.GetWorldPosition(FingerDistance), transform.rotation);
			}
		}
	}
}