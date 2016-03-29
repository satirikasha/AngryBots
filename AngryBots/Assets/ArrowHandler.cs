using UnityEngine;
using System.Collections;

public class ArrowHandler : MonoBehaviour {

    public MeshRenderer Arrow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawArrow() {
        Arrow.enabled = true;
    }

    public void Fire() {
        Arrow.enabled = false;
        var controller = transform.root.GetComponent<PlayerController>();
        if (controller.isLocalPlayer) {
            controller.CmdFire(Arrow.transform.forward, Arrow.transform.position);
        }
    }
}
