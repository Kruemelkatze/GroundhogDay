using UnityEngine;
using System.Collections;

public class DJButton : FaceCam {
	public Sprite First;
	public Sprite Second;
	public AudioClip AudioClipOnClick;

	public bool ChangeOnce = true;
	public bool playSuperGlitch = false;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	void OnMouseDown() {
		if (AudioClipOnClick != null) {
			Grid.SoundManager.PlaySingle (AudioClipOnClick);
		}
		if (!ChangeOnce || ChangeOnce && !playSuperGlitch) {
			playSuperGlitch = !playSuperGlitch;
			if (playSuperGlitch) {
				spriteRenderer.sprite = Second;
				Grid.SoundManager.OfficeTheme = Grid.SoundManager.SuperGlitchMusic;
				Grid.SoundManager.PlayMusic (Grid.SoundManager.SuperGlitchMusic);
			} else {
				spriteRenderer.sprite = First;
				Grid.SoundManager.PlayMusic (Grid.SoundManager.OfficeTheme);
			}
		}
	}
}
