using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameTimer : MonoBehaviour {
	
	public int levelSeconds = 100;
	public float secondsLeft; //todo make it private later
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		//secondsLeft = levelSeconds;
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("YouWin");
		if (!winLabel) {
			Debug.LogWarning ("please create you win object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel);
		if(timeIsUp)
        {
            HandleWinCondition();
        }
    }

    void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    //destroys all objects with DestroyOnWin tag
    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
