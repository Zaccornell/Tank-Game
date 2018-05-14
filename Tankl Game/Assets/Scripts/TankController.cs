using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	public float forwardSpeed = 0.1f;
	public float backwardSpeed = 0.08f;
	public float rotationalSpeed = 2f;

	public float turretRotationalSpeed = 3f;

	public GameObject turret;

    public float shellSpeed = 20;

    public GameObject shellPrefab;

    public Transform shellSpawnPoint;

    public KeyCode forwardsKey = KeyCode.W;
    public KeyCode backwardsKey = KeyCode.S;
    public KeyCode rotateLeftKey = KeyCode.A;
    public KeyCode rotateRightKey = KeyCode.D;
    public KeyCode rotateTurretLeftKey = KeyCode.Q;
    public KeyCode rotateTurretRightKey = KeyCode.E;
    public KeyCode fireKey = KeyCode.Space;

    public int health = 100;

    public void TakeDamage(int damageToTake)
    {
        health = health - damageToTake;
    }

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (rotateTurretLeftKey)) 
		{
			turret.transform.Rotate (0, -turretRotationalSpeed, 0, Space.Self);
		}

		if (Input.GetKey (rotateTurretRightKey))
		{
			turret.transform.Rotate (0, turretRotationalSpeed, 0, Space.Self);
		}
		
		if (Input.GetKey (forwardsKey)) {
			transform.position = transform.position + transform.forward * forwardSpeed;
		}

		if (Input.GetKey (backwardsKey)) {
			transform.position = transform.position + transform.forward * -backwardSpeed;
		}

		if (Input.GetKey (rotateLeftKey)) {
			transform.Rotate (transform.up * -rotationalSpeed);
		}

		if (Input.GetKey (rotateRightKey)) {
			transform.Rotate (transform.up * rotationalSpeed);
		}

        if (Input.GetKey (fireKey))
        {
            GameObject Go = Instantiate(shellPrefab, shellSpawnPoint.position, Quaternion.identity) as GameObject;
            Go.GetComponent<Rigidbody>().AddForce(turret.transform.forward * shellSpeed, ForceMode.Impulse);
        }
        if (health <= 0)
        {
            return;
        }

	}
}