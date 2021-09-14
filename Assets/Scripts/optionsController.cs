using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class optionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;
	private MusicManager musicManager;
	public Slider difficultySlider;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.setVolume(volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
	
}
