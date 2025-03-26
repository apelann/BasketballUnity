using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballLauncher : MonoBehaviour
{
	[SerializeField] private Projection _projection;
	private void Update()
	{
		HandleControls();
		_projection.SimulateTrajectory(basketballPrefab, handPoint.position, (transform.forward + Vector3.up) * currentForce);
	}

	public float minForce;
    public float maxForce;
	public float forceBoosterValue;
	public Ball basketballPrefab;
	public Ball currentBasketball;
	public float ballCreationTime;
	public Transform handPoint;
	public float rotationSpeed;
	public LineRenderer lineRenderer;

	public float currentForce;

	private void HandleControls()
	{
		if (currentBasketball && Input.GetKeyDown(KeyCode.Space))
		{
			lineRenderer.enabled = true;
		}

		if (lineRenderer.enabled)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				currentForce += forceBoosterValue * Time.deltaTime;
				currentForce = Mathf.Clamp(currentForce, minForce, maxForce);
			}

			if (Input.GetKeyUp(KeyCode.Space))
			{
				lineRenderer.enabled = false;

				currentBasketball.Init((transform.forward + Vector3.up) * currentForce, false);
				currentForce = 0f;

				StartCoroutine(CreateNewBall());
			}
		}

		transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime);
	}

	private IEnumerator CreateNewBall()
	{
		currentBasketball = null;
		yield return new WaitForSeconds(ballCreationTime);
		currentBasketball = Instantiate(basketballPrefab.gameObject, handPoint).GetComponent<Ball>();
	}
}
