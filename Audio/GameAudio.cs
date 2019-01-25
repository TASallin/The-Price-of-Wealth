using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour {
	
	
	
	public void Play(string name) {
		gameObject.transform.Find(name).gameObject.GetComponent<AudioSource>().Play();
	}
	
	public void PlayRandom(string[] names) {
		System.Random rng = new System.Random();
		int num = rng.Next(names.Length);
		Play(names[num]);
	}
	
	public void PlayNumbered(string name, int lower, int upper) {
		string[] names = new string[upper - lower + 1];
		int j = 0;
		for (int i = lower; i <= upper; i++) {
			names[j] = name + i.ToString();
			j++;
		}
		PlayRandom(names);
	}
	
	public void PlayAmount(string name, int amount) {
		PlayNumbered(name, 1, amount);
	}
	
	public void InitiateMusic() {
		string track = "BattleTheme1";
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetChampion()) {
				track = "MiniBoss";
			}
		}
		Play(track);
	}
}