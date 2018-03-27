using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenFinished : MonoBehaviour {

	void Update () {
		if (GameManager.instance.levelCompleted)
        {
            Destroy(gameObject);
        }
	}
}
