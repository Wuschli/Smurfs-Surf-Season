using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour {

	public string Format = "Your final Score is {0}";

	void Start () {
		GetComponent<Text>().text = string.Format(Format, World.Score);
	}
}
