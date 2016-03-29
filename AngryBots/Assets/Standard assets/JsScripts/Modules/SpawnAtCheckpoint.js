#pragma strict
#pragma downcast

private var pos : Vector3;
private var rot : Quaternion;

function Start () {
    pos = transform.position;
    rot = transform.rotation;
}

function OnSignal () {
	transform.position = pos;
	transform.rotation = rot;
	
	ResetHealthOnAll ();
}

static function ResetHealthOnAll () {
	var healthObjects : Health[] = FindObjectsOfType (Health);
	for (var health : Health in healthObjects) {
		health.dead = false;
		health.health = health.maxHealth;
	}
}
