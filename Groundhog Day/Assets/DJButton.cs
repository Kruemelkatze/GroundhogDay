using UnityEngine;
using System.Collections;

public class DJButton : FaceCam {
	public Sprite First;
	public Sprite Second;
	public AudioClip AudioClipOnClick;

	public bool playSuperGlitch = false;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (AudioClipOnClick != null) {
			Grid.SoundManager.PlaySingle (AudioClipOnClick);
		}
		playSuperGlitch = !playSuperGlitch;

		if (playSuperGlitch) {
			spriteRenderer.sprite = Second;
			Grid.SoundManager.PlayMusic (Grid.SoundManager.SuperGlitchMusic);
		} else {
			spriteRenderer.sprite = First;
			Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
		}
	}
}
