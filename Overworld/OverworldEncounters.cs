using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEncounters : MonoBehaviour {
	
	static System.Random rng = new System.Random();
	
	public void Battle () {
		Character[] enemies;
	    if (Time.timeUnit < 10) {
			enemies = Easy();
		} else if (Time.timeUnit < 20) {
			if (rng.Next(10) < 5) {
				enemies = Easy();
			} else {
				enemies = Medium();
			}
		} else if (Time.timeUnit < 30) {
			int seed = rng.Next(10);
			if (seed < 2) {
				enemies = Easy();
			} else if (seed < 7) {
				enemies = Medium();
			} else {
				enemies = Hard();
			}
		} else if (Time.timeUnit < 40) {
			int seed = rng.Next(10);
			if (seed < 2) {
				enemies = Medium();
			} else if (seed < 7) {
				enemies = Hard();
			} else {
				enemies = Deadly();
			}
		} else if (Time.timeUnit < 50) {
			if (rng.Next(10) < 5) {
				enemies = Hard();
			} else {
				enemies = Deadly();
			}
		} else {
			enemies = Deadly();
		}
		foreach (Character c in enemies) {
			Party.AddEnemy(c);
		}
		Party.area = "Overworld";
		Time.Increment();
		SceneManager.LoadScene("Battle");
	}
	
	public Character[] Easy() {
		int n = rng.Next(28);
		if (n == 0) {
		    return new Character[] {new FootballPlayer()};
		} else if (n == 1) {
		    return new Character[] {new CSMajor()};
		} else if (n == 2) {
			return new Character[] {new ShuttleDriver()};
		} else if (n == 3) {
			return new Character[] {new TeachingAssistant()};
		} else if (n == 4) {
			return new Character[] {new MusicMajor()};
		} else if (n == 5) {
			return new Character[] {new HistoryMajor()};
		} else if (n == 6) {
			return new Character[] {new PizzaCultist()};
		} else if (n == 7) {
			return new Character[] {new CulinaryMajor()};
        } else if (n == 8) {
			return new Character[] {new AerospaceEngineer()};	
        } else if (n == 9) {
			return new Character[] {new MathMajor()};
		} else if (n == 10) {
			return new Character[] {new Chef()};
		} else if (n == 13) {
			return new Character[] {new Researcher()};
		} else if (n == 14) {
			return new Character[] {new ChemistryMajor()};
		} else if (n == 15) {
			return new Character[] {new MechanicalEngineer()};
        } else if (n == 16) {
			return new Character[] {new DanceMajor()};			
		} else if (n == 17) {
			return new Character[] {new CJMajor()};
		} else if (n == 18) {
			return new Character[] {new PreMed()};
		} else if (n == 19) {
			return new Character[] {new EnglishMajor()};
		} else if (n == 20) {
			return new Character[] {new BusinessMajor()};
		} else if (n == 21) {
			return new Character[] {new PsychMajor()};
		} else if (n == 22) {
			return new Character[] {new PoliticalScientist()};
        } else if (n == 23) {
			return new Character[] {new Cop()};
		} else if (n == 25) {
			return new Character[] {new Doctor()};
		} else if (n == 26) {
			return new Character[] {new Representative()};
		} else if (n == 24) {
			return new Character[] {new Criminal()};
		} else if (n == 11) {
			return new Character[] {new Coach()};	
		} else if (n == 12) {
			return new Character[] {new Conductor()};
		} else {
			return new Character[] {new Instructor()};
		}
	}
	
	public Character[] Medium() {
		int n = rng.Next(29);
		if (n == 0) {
			return new Character[] {new FootballPlayer(), new DanceMajor()};
		} else if (n == 1) {
			return new Character[] {new CSMajor(), new PsychMajor()};
		} else if (n == 2) {
			return new Character[] {new ShuttleDriver(), new Janitor()};
		} else if (n == 3) {
			return new Character[] {new TeachingAssistant(), new MathMajor()};
		} else if (n == 4) {
			return new Character[] {new MusicMajor(), new MusicMajor()};
		} else if (n == 5) {
			return new Character[] {new HistoryMajor(), new EnglishMajor()};
		} else if (n == 6) {
			return new Character[] {new PizzaCultist(), new PizzaCultist()};
		} else if (n == 7) {
			return new Character[] {new CulinaryMajor(), new PreMed()};
		} else if (n == 8) {
			return new Character[] {new AerospaceEngineer(), new MechanicalEngineer()};
		} else if (n == 9) {
			return new Character[] {new Chef(), new CulinaryMajor()};
		} else if (n == 10) {
			return new Character[] {new MathMajor(), new EnglishMajor()};
		} else if (n == 11) {
			return new Character[] {new Researcher(), new Instructor()};
		} else if (n == 12) {
			return new Character[] {new ChemistryMajor(), new CSMajor()};
		} else if (n == 13) {
			return new Character[] {new MechanicalEngineer(), new ShuttleDriver()};
		} else if (n == 14) {
			return new Character[] {new DanceMajor(), new BusinessMajor()};
		} else if (n == 15) {
			return new Character[] {new CJMajor(), new CJMajor()};
		} else if (n == 16) {
			return new Character[] {new PreMed(), new ChemistryMajor()};
		} else if (n == 17) {
			return new Character[] {new EnglishMajor(), new PoliticalScientist()};
		} else if (n == 18) {
			return new Character[] {new BusinessMajor(), new FootballPlayer()};
		} else if (n == 19) {
			return new Character[] {new PsychMajor(), new Criminal()};
		} else if (n == 20) {
			return new Character[] {new PoliticalScientist(), new BusinessMajor()};
		} else if (n == 21) {
			return new Character[] {new Cop(), new ShuttleDriver()};
		} else if (n == 22) {
			return new Character[] {new Doctor(), new Instructor()};
		} else if (n == 23) {
			return new Character[] {new Representative(), new Administrator()};
		} else if (n == 24) {
			return new Character[] {new Criminal(), new Criminal()};
		} else if (n == 25) {
			return new Character[] {new Administrator()};
		} else if (n == 26) {
			return new Character[] {new Coach(), new Chef()};
		} else if (n == 27) {
			return new Character[] {new Conductor(), new DanceMajor()};
		} else {
			return new Character[] {new Instructor(), new Instructor()};
		}
	}
	
	public Character[] Hard() {
		int n = rng.Next(29);
		if (n == 0) {
			return new Character[] {new FootballPlayer(), new Chef(), new Chef()};
		} else if (n == 1) {
			return new Character[] {new CSMajor(), new LabRobot(), new SecurityHologram()};
		} else if (n == 2) {
			return new Character[] {new ShuttleDriver(), new TeachingAssistant(), new TeachingAssistant()};
		} else if (n == 3) {
			return new Character[] {new TeachingAssistant(), new ChemistryMajor(), new Slime()};
		} else if (n == 4) {
			return new Character[] {new MusicMajor(), new FootballPlayer(), new DanceMajor()};
		} else if (n == 5) {
			return new Character[] {new HistoryMajor(), new HistoryMajor(), new AerospaceEngineer()};
		} else if (n == 6) {
			return new Character[] {new PizzaCultist(), new Criminal(), new Chef()};
		} else if (n == 7) {
			return new Character[] {new CulinaryMajor(), new BusinessMajor(), new ChemistryMajor()};
		} else if (n == 8) {
			return new Character[] {new AerospaceEngineer(), new CJMajor(), new PsychMajor()};
		} else if (n == 9) {
			return new Character[] {new Chef(), new Slime(), new Slime()};
		} else if (n == 10) {
			return new Character[] {new MathMajor(), new CSMajor(), new MechanicalEngineer()};
		} else if (n == 11) {
			return new Character[] {new Researcher(), new TeachingAssistant(), new LabRobot()};
		} else if (n == 12) {
			return new Character[] {new ChemistryMajor(), new PsychMajor(), new PoliticalScientist()};
		} else if (n == 13) {
			return new Character[] {new MechanicalEngineer(), new MechanicalEngineer(), new MechanicalEngineer()};
		} else if (n == 14) {
			return new Character[] {new DanceMajor(), new MusicMajor(), new BusinessMajor()};
		} else if (n == 15) {
			return new Character[] {new CJMajor(), new Cop(), new LabRobot()};
		} else if (n == 16) {
			return new Character[] {new PreMed(), new Janitor(), new Slime()};
		} else if (n == 17) {
			return new Character[] {new EnglishMajor(), new EnglishMajor(), new EnglishMajor()};
		} else if (n == 18) {
			return new Character[] {new BusinessMajor(), new CSMajor(), new AerospaceEngineer()};
		} else if (n == 19) {
			return new Character[] {new PsychMajor(), new PizzaCultist(), new PizzaCultist()};
		} else if (n == 20) {
			return new Character[] {new PoliticalScientist(), new PoliticalScientist(), new PoliticalScientist()};
		} else if (n == 21) {
			return new Character[] {new Cop(), new Cop(), new CJMajor()};
		} else if (n == 22) {
			return new Character[] {new Doctor(), new Researcher(), new PreMed()};
		} else if (n == 23) {
			return new Character[] {new Representative(), new TeachingAssistant(), new Instructor()};
		} else if (n == 24) {
			return new Character[] {new Criminal(), new Janitor(), new ShuttleDriver()};
		} else if (n == 25) {
			return new Character[] {new Administrator(), new Cop()};
		} else if (n == 26) {
			return new Character[] {new Coach(), new FootballPlayer(), new FootballPlayer()};
		} else if (n == 27) {
			return new Character[] {new Conductor(), new MusicMajor(), new MusicMajor()};
		} else {
			return new Character[] {new Instructor(), new TeachingAssistant(), new TeachingAssistant()};
		}
	}
	
	public Character[] Deadly() {
		int n = rng.Next(29);
		if (n == 0) {
			return new Character[] {new FootballPlayer(), new FootballPlayer(), new FootballPlayer(), new FootballPlayer()};
		} else if (n == 1) {
			return new Character[] {new CSMajor(), new BusinessMajor(), new CSMajor(), new MechanicalEngineer()};
		} else if (n == 2) {
			return new Character[] {new ShuttleDriver(), new Representative(), new Cop(), new Representative()};
		} else if (n == 3) {
			return new Character[] {new TeachingAssistant(), new PsychMajor(), new EnglishMajor(), new HistoryMajor()};
		} else if (n == 4) {
			return new Character[] {new MusicMajor(), new MusicMajor(), new CulinaryMajor(), new PoliticalScientist()};
		} else if (n == 5) {
			return new Character[] {new HistoryMajor(), new EnglishMajor(), new PsychMajor(), new HistoryMajor()};
		} else if (n == 6) {
			return new Character[] {new PizzaCultist(), new PizzaCultist(), new PizzaCultist(), new PizzaCultist()};
		} else if (n == 7) {
			return new Character[] {new CulinaryMajor(), new CulinaryMajor(), new Chef(), new MusicMajor()};
		} else if (n == 8) {
			return new Character[] {new AerospaceEngineer(), new AerospaceEngineer(), new AerospaceEngineer(), new AerospaceEngineer()};
		} else if (n == 9) {
			return new Character[] {new Chef(), new Doctor(), new Janitor(), new Cop()};
		} else if (n == 10) {
			return new Character[] {new MathMajor(), new Instructor(), new TeachingAssistant(), new SecurityHologram()};
		} else if (n == 11) {
			return new Character[] {new Researcher(), new Researcher(), new LabRobot(), new Slime()};
		} else if (n == 12) {
			return new Character[] {new ChemistryMajor(), new Slime(), new Slime(), new ChemistryMajor()};
		} else if (n == 13) {
			return new Character[] {new MechanicalEngineer(), new CSMajor(), new ShuttleDriver(), new MechanicalEngineer()};
		} else if (n == 14) {
			return new Character[] {new DanceMajor(), new DanceMajor(), new CulinaryMajor(), new CulinaryMajor()};
		} else if (n == 15) {
			return new Character[] {new CJMajor(), new Criminal(), new Cop(), new CJMajor()};
		} else if (n == 16) {
			return new Character[] {new PreMed(), new Doctor(), new Instructor(), new Researcher()};
		} else if (n == 17) {
			return new Character[] {new EnglishMajor(), new MathMajor(), new EnglishMajor(), new MathMajor()};
		} else if (n == 18) {
			return new Character[] {new BusinessMajor(), new Representative(), new ShuttleDriver(), new SecurityHologram()};
		} else if (n == 19) {
			return new Character[] {new PsychMajor(), new HistoryMajor(), new EnglishMajor(), new PoliticalScientist()};
		} else if (n == 20) {
			return new Character[] {new PoliticalScientist(), new Representative(), new CJMajor(), new ShuttleDriver()};
		} else if (n == 21) {
			return new Character[] {new Cop(), new Doctor(), new Cop(), new Doctor()};
		} else if (n == 22) {
			return new Character[] {new Doctor(), new Doctor(), new PizzaCultist(), new Criminal()};
		} else if (n == 23) {
			return new Character[] {new Representative(), new Administrator(), new PoliticalScientist(), new BusinessMajor()};
		} else if (n == 24) {
			return new Character[] {new Criminal(), new HistoryMajor(), new CulinaryMajor(), new PreMed()};
		} else if (n == 25) {
			return new Character[] {new Administrator(), new Administrator()};
		} else if (n == 26) {
			return new Character[] {new Coach(), new FootballPlayer(), new Coach(), new FootballPlayer()};
		} else if (n == 27) {
			return new Character[] {new Conductor(), new DanceMajor(), new DanceMajor(), new CulinaryMajor()};
		} else {
			return new Character[] {new Instructor(), new Instructor(), new Instructor(), new Instructor()};
		}
	}
}