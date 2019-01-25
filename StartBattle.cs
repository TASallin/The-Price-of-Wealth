using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour {
    
	static System.Random rng = new System.Random();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Battle () {
		int n = rng.Next(32);
		if (n == 0) {
		    Party.AddEnemy(new FootballPlayer());
		} else if (n == 1) {
		    Party.AddEnemy(new CSMajor());
		} else if (n == 2) {
			Party.AddEnemy(new ShuttleDriver());
		} else if (n == 3) {
			Party.AddEnemy(new TeachingAssistant());
		} else if (n == 4) {
			Party.AddEnemy(new MusicMajor());
		} else if (n == 5) {
			Party.AddEnemy(new HistoryMajor());
		} else if (n == 6) {
			Party.AddEnemy(new PizzaCultist());
		} else if (n == 7) {
			Party.AddEnemy(new CulinaryMajor());
        } else if (n == 8) {
			Party.AddEnemy(new AerospaceEngineer());	
        } else if (n == 9) {
			Party.AddEnemy(new MathMajor());
		} else if (n == 10) {
			Party.AddEnemy(new Chef());
		} else if (n == 11) {
			Party.AddEnemy(new Slime());
		} else if (n == 12) {
			Party.AddEnemy(new LabRobot());	
		} else if (n == 13) {
			Party.AddEnemy(new Researcher());
		} else if (n == 14) {
			Party.AddEnemy(new ChemistryMajor());
		} else if (n == 15) {
			Party.AddEnemy(new MechanicalEngineer());
        } else if (n == 16) {
			Party.AddEnemy(new DanceMajor());			
		} else if (n == 17) {
			Party.AddEnemy(new CJMajor());
		} else if (n == 18) {
			Party.AddEnemy(new PreMed());
		} else if (n == 19) {
			Party.AddEnemy(new EnglishMajor());
		} else if (n == 20) {
			Party.AddEnemy(new BusinessMajor());
		} else if (n == 21) {
			Party.AddEnemy(new PsychMajor());
		} else if (n == 22) {
			Party.AddEnemy(new PoliticalScientist());
        } else if (n == 23) {
			Party.AddEnemy(new Cop());
		} else if (n == 24) {
			Party.AddEnemy(new SecurityHologram());
		} else if (n == 25) {
			Party.AddEnemy(new Doctor());
		} else if (n == 26) {
			Party.AddEnemy(new Representative());
		} else if (n == 27) {
			Party.AddEnemy(new Criminal());
		} else if (n == 28) {
			Party.AddEnemy(new Administrator());
		} else if (n == 29) {
			Party.AddEnemy(new Coach());	
		} else if (n == 30) {
			Party.AddEnemy(new Conductor());
		} else {
			Party.AddEnemy(new Instructor());
		}
		Party.area = "Overworld";
		Time.Increment();
		SceneManager.LoadScene("Battle");
		return;
	}
}
