using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private AudioClip _clip;
    private bool _isGhost;

    public void Init(Vector3 velocity, bool isGhost) {
        transform.parent = null;

        _isGhost = isGhost;
        _rb.isKinematic = false;
		_rb.AddForce(velocity, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision col) {
        if (_isGhost) return;

		AudioSource.PlayClipAtPoint(_clip, transform.position, 5f);

        if (col.gameObject.CompareTag("Ground")) Destroy(this);
	}
}