using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGetter : MonoBehaviour {
    public static Event beforeBoss;
	
	//tower
	public static Event representative;
	public static Event admin;
	public static Event twoCS;
	public static Event history;
	public static Event business;
	public static Event criminal;
	public static Event polSci;
	public static Event pizzaParty;
	public static Event rescue;
	public static Event hologram;
	public static Event centralUnit;
	public static Event admission;
	
	//dining
	public static Event driver;
	public static Event rocketScience;
	public static Event cultist;
	public static Event culinary;
	public static Event chef;
	public static Event janitor;
	public static Event cultLeader;
	public static Event cookParty;
	public static Event food;
	public static Event donuts;
	public static Event feast;
	
	//research
	public static Event researcher;
	public static Event chemistry;
	public static Event janislime;
	public static Event robot;
	public static Event expirimentor;
	public static Event slimeGoo;
	public static Event strengthUp;
	public static Event flasks;
	public static Event poisonParty;
	public static Event shortcut;
	public static Event superPotions;
	
	//sports
	public static Event football;
	public static Event coach;
	public static Event cop;
	public static Event manyFootball;
	public static Event mechE;
	public static Event aerospace;
	public static Event fans1;
	public static Event quarterback;
	public static Event fans2;
	public static Event weights;
	public static Event treadmill;
	public static Event champion;
	
	//arts
	public static Event conductor;
	public static Event music;
	public static Event dance;
	public static Event english;
	public static Event writingPair;
	public static Event marching;
	public static Event aggressiveArt;
	public static Event symphony;
	public static Event begger;
	public static Event show;
	public static Event musicStorage;
	public static Event painting;
	
	//health
	public static Event premed;
	public static Event doctor;
	public static Event patients;
	public static Event slime;
	public static Event criminalCop;
	public static Event medicalResearch;
	public static Event medicalDrama;
	public static Event surgeon;
	public static Event germRoom;
	public static Event treatment;
	public static Event secretaryDesk;
	public static Event revives;
	
	//lecture
	public static Event instructor;
	public static Event ta;
	public static Event gradingTeam;
	public static Event cjMajor;
	public static Event psych;
	public static Event math;
	public static Event cs;
	public static Event tenured;
	public static Event zombieClass;
	public static Event coffeeStash;
	public static Event stemVarts;
	public static Event exam;
	
	//bosses
	public static Event politician;
	public static Event general;
	public static Event ceo;
	
	//extras
	public static Event coachAndOther;
	public static Event faculty;
    public static Event roboticist;
	public static Event cultBrutes;
	public static Event polGuarded;
	public static Event productionTeam;
	public static Event bothBusiness;
	public static Event doubleHealer;
	public static Event potionThrowers;
	public static Event rehabHelp;
	public static Event foodTruck;
	public static Event antiHack;
	public static Event headTA;
	public static Event twinArt;
	public static Event marketing;
	public static Event tinyBand;
	public static Event lawyers;
	public static Event susMeal;
	public static Event er;
	public static Event fourEngineers;
	public static Event mainSubjects;
	public static Event fullBus;
	public static Event lectureLab;
	public static Event headCoach;
			
	public static void BeginGame() {
		//Bosses
		beforeBoss = new TextEvent("The next room is the deepest part of the building. Whatever controls this place lies ahead");
		ceo = new BattleEvent(new Character[] {new CEO()}, "It's the CEO");
		general = new BattleEvent(new Character[] {new General()}, "It's the general");
		politician = new BattleEvent(new Character[] {new Politician()}, "It's the politician");
		centralUnit = new BattleEvent(new Character[] {new CentralAI()}, "The room guarded by the central AI awaits");
		cultLeader = new CultLeaderEvent();
		expirimentor = new ExpirimentorEvent();
		quarterback = new QuarterbackEvent();
		symphony = new SymphonyEvent();
		surgeon = new BattleEvent(new Character[] {new Surgeon()}, "The surgeon");
		tenured = new TenuredEvent();
		
		//Single Enemy
		researcher = new BattleEvent(new Character[] {new Researcher()}, "Researcher");
		chemistry = new BattleEvent(new Character[] {new ChemistryMajor()}, "Chemist");
		mechE = new BattleEvent(new Character[] {new MechanicalEngineer()}, "Mechanical Engineer");
		robot = new BattleEvent(new Character[] {new LabRobot()}, "Robot");
		cultist = new BattleEvent(new Character[] {new PizzaCultist()}, "Pizza Cultist");
		culinary = new BattleEvent(new Character[] {new CulinaryMajor()}, "Culinary Major");
		chef = new BattleEvent(new Character[] {new Chef()}, "Chef");
		ta = new BattleEvent(new Character[] {new TeachingAssistant()}, "Teaching Assistant");
		dance = new BattleEvent(new Character[] {new DanceMajor()}, "Dance Major");
		history = new BattleEvent(new Character[] {new HistoryMajor()}, "History Major");
	    music = new BattleEvent(new Character[] {new MusicMajor()}, "Music Major");
	    driver = new BattleEvent(new Character[] {new ShuttleDriver()}, "Shuttle Driver");
		football = new BattleEvent(new Character[] {new FootballPlayer()}, "Football");
		representative = new BattleEvent(new Character[] {new Representative()}, "Representative");
		admin = new BattleEvent(new Character[] {new Administrator()}, "Administrator");
		criminal = new BattleEvent(new Character[] {new Criminal()}, "Robber");
		polSci = new BattleEvent(new Character[] {new PoliticalScientist()}, "Political Scientist");
		janitor = new BattleEvent(new Character[] {new Janitor()}, "Janitor");
		coach = new BattleEvent(new Character[] {new Coach()}, "Coach");
		cop = new BattleEvent(new Character[] {new Cop()}, "Cop");
		conductor = new BattleEvent(new Character[] {new Conductor()}, "Conductor");
		english = new BattleEvent(new Character[] {new EnglishMajor()}, "English");
		cjMajor = new BattleEvent(new Character[] {new CJMajor()}, "Criminal Justice");
		premed = new BattleEvent(new Character[] {new PreMed()}, "PreMed");
		doctor = new BattleEvent(new Character[] {new Doctor()}, "Doctor");
		hologram = new BattleEvent(new Character[] {new SecurityHologram()}, "Security System");
		psych = new BattleEvent(new Character[] {new PsychMajor()}, "Psychology");
		math = new BattleEvent(new Character[] {new MathMajor()}, "Math");
	    cs = new BattleEvent(new Character[] {new CSMajor()}, "CS");
		slime = new BattleEvent(new Character[] {new Slime()}, "Slime");
		aerospace = new BattleEvent(new Character[] {new AerospaceEngineer()}, "Aerospace Engineer");
		business = new BattleEvent(new Character[] {new BusinessMajor()}, "Business");
	    instructor = new BattleEvent(new Character[] {new Instructor()}, "Instructor");
		
		//Medium Difficulty Fights
		janislime = new BattleEvent(new Character[] {new Janitor(), new Slime()}, "Janitor with slime waste");
		rocketScience = new BattleEvent(new Character[] {new MathMajor(), new AerospaceEngineer()}, "Rocket science pair");
		twoCS = new BattleEvent(new Character[] {new CSMajor(), new CSMajor()}, "Two CS");
		writingPair = new BattleEvent(new Character[] {new HistoryMajor(), new EnglishMajor()}, "Writing Pair");
		criminalCop = new BattleEvent(new Character[] {new Criminal(), new Cop()}, "Criminal and cop");
		coachAndOther = new BattleEvent(new Character[] {new Coach(), new FootballPlayer()}, "Coach with Player");
		faculty = new BattleEvent(new Character[] {new Instructor(), new Researcher()}, "Faculty");
		roboticist = new BattleEvent(new Character[] {new LabRobot(), new MechanicalEngineer()}, "Dude with robot");
		cultBrutes = new BattleEvent(new Character[] {new PizzaCultist(), new Criminal()}, "The cult's mercenary");
		polGuarded = new BattleEvent(new Character[] {new CJMajor(), new PoliticalScientist()}, "Future president with bodyguard");
		productionTeam = new BattleEvent(new Character[] {new Conductor(), new Administrator()}, "Production team");
		bothBusiness = new BattleEvent(new Character[] {new BusinessMajor(), new Representative()}, "Double business");
		doubleHealer = new BattleEvent(new Character[] {new Chef(), new Doctor()}, "Possessed healers");
		potionThrowers = new BattleEvent(new Character[] {new ChemistryMajor(), new Researcher()}, "Potion throwers");
		rehabHelp = new BattleEvent(new Character[] {new PreMed(), new PsychMajor()}, "Rehab help");
		foodTruck = new BattleEvent(new Character[] {new ShuttleDriver(), new CulinaryMajor()}, "Food Truck");
		antiHack = new BattleEvent(new Character[] {new SecurityHologram(), new CSMajor()}, "Anti-Hacking");
		headTA = new BattleEvent(new Character[] {new TeachingAssistant(), new Instructor()}, "Assistant and Actual");
		twinArt = new BattleEvent(new Character[] {new MusicMajor(), new DanceMajor()}, "Twin arts");
		tinyBand = new BattleEvent(new Character[] {new Conductor(), new MusicMajor()}, "Tiny band");
		lawyers = new BattleEvent(new Character[] {new EnglishMajor(), new CJMajor()}, "Lawyering");
		susMeal = new BattleEvent(new Character[] {new Slime(), new Chef()}, "Suspicious meal");
		er = new BattleEvent(new Character[] {new Cop(), new Doctor()}, "Emergency");
		
		//Difficult Battles
		poisonParty = new BattleEvent(new Character[] {new Janitor(), new ChemistryMajor(), new Slime(), new ChemistryMajor()},
		    "The poison party");
		cookParty = new BattleEvent(new Character[] {new CulinaryMajor(),new PizzaCultist(), new Chef()}, "The cooking party");
		manyFootball = new BattleEvent(new Character[] {new FootballPlayer(),new FootballPlayer(), new FootballPlayer()}, "Several football players");
		fans1 = new BattleEvent(new Character[] {new HistoryMajor(),new CulinaryMajor(), new MathMajor()}, "Some fans");
		fans2 = new BattleEvent(new Character[] {new Instructor(), new Representative(), new TeachingAssistant()}, "Some possessed fans");
        marching = new BattleEvent(new Character[] {new Conductor(), new MusicMajor(), new DanceMajor()}, "Marching Band Selection");
		patients = new BattleEvent(new Character[] {new BusinessMajor(),new FootballPlayer(), new ChemistryMajor()}, "Hospital Patients");
		gradingTeam = new BattleEvent(new Character[] {
			new TeachingAssistant(),new TeachingAssistant(), new TeachingAssistant(), new TeachingAssistant()}, "Grading Team");
		fourEngineers = new BattleEvent(new Character[] {
			new MechanicalEngineer(), new AerospaceEngineer(), new MechanicalEngineer(), new AerospaceEngineer()}, "ENGINEERS");
		mainSubjects = new BattleEvent(new Character[] {
			new MathMajor(), new EnglishMajor(), new ChemistryMajor(), new HistoryMajor()}, "Standard crew");
	    fullBus = new BattleEvent(new Character[] {new ShuttleDriver(), new Representative(), new Cop(), new Doctor()}, "Full bus");
		lectureLab = new BattleEvent(new Character[] {new Instructor(), new Researcher(), new TeachingAssistant(), new LabRobot()}, "Lecture and lab");
		headCoach = new BattleEvent(new Character[] {new Coach(), new FootballPlayer(), new Representative(), new MusicMajor()}, "Head coach");
		aggressiveArt = new BattleEvent(new Character[] {new EnglishMajor(), new DanceMajor(), new CulinaryMajor(), new MusicMajor()},
    		"Art proponents");
		medicalDrama = new BattleEvent(new Character[] {new PreMed(), new EnglishMajor(), new Janitor(), new Doctor()}, "Medical soap opera");
		marketing = new BattleEvent(new Character[] {new PsychMajor(), new Representative(), new Representative(), new Representative()},
    		"Marketing");
		
		//Non-Battle events
		admission = new Event("A desk with huge stacks of admission letters is before you. Someone is very inspired by this",
    		new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who is inspired?",
			new TimedMethod[] {new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 2}), new TimedMethod(0, "StatChange", new object[] {
			"GainStrength", 2}), new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strength +2, Dex +2")})})})}), null, null, null, "Wow!", null, null, null);
		feast = new ItemEvent(new Item[] {new GoldenPizza(), new MegaCurry(), new Meatloaf(), new IronSpinach(), new Coffee()},
		    "You have fought your way to the untouched food supplies fed only to grant winners");
		superPotions = new ItemEvent(new Item[] {new StrengthPotion(), new DexPotion(), new AccuracyPotion(), new HealthPotion()},
		    "Finally, where they keep the good stuff");
		champion = new Event("The championship winnings are here. Who will don the title?", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Choose (+4 strength)", new TimedMethod[] {
			new TimedMethod(0, "StatChange", new object[] {"GainStrength", 4}),
			new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strength + 4")})})})}), null, null, null,"Decide", null, null, null);
		painting = new Event("The art gallery is so peaceful", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "GainSP", new object[] {25}), new TimedMethod(0, "Heal", new object[] {10}),
			new TimedMethod("Resolve")}), null, null, null, "Relax (+25 sp and 10 hp per member)", null, null, null);
		revives = new ItemEvent(new Item[] {new Defibrilator(), new Defibrilator(), new HealthPotion(), new HealthPotion()},
		    "A collection of unlooted, very useful survival tools");
		exam = new ItemEvent(new Item[] {new Exam()}, "Wow! it's a graded exam that got a 105");
		germRoom = new Event("A room marked as contaminated appears to contain some useful supplies", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "Poison", new object[] {3}), new TimedMethod(0, "Item", new object[] {new Item[] {new Defibrilator(),
		    new ToxicSolution(), new Wire(), new MysterySolution()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}),
			null, null, "Gather supplies (become poisoned next fight)", "Move on", null, null);
		treatment = new Event("A standard treatment room is here. There is enough supplies for one person", new LinkedList<TimedMethod>(
		    new TimedMethod[] {new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will be treated?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"Heal", 15}), new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("15 hp restored")})
			})})}), null, null, null, "Heal", null, null, null);
		secretaryDesk = new ItemEvent(new Item[] {new Pencil(), new PinkSlip(), new Sanitizer()}, "This is an empty front desk, unlooted");
		coffeeStash = new ItemEvent(new Item[] {new Coffee()}, "While snooping around, you find a legendary cup of coffee");
		stemVarts = new Event("2 groups of students are arguing about stem vs liberal arts. They immediatly demand you take a side",
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Heal", new object[] {5}), 
			new TimedMethod(0, "CauseEvent", new object[] {new BattleEvent(new Character[] {
			new ChemistryMajor(), new CSMajor(), new AerospaceEngineer(), new MathMajor()}, "The STEM majors are enranged and attack")})}),
			new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "GainSP", new object[] {15}), new TimedMethod(
			0, "CauseEvent", new object[] {new BattleEvent( new Character[] {
			new EnglishMajor(), new CulinaryMajor(), new DanceMajor(), new MusicMajor()},
			"The liberal arts majors are enranged and attack")})}), null, null, "Side with the arts (Party heals)", "Side with stem (Gain SP)",
			null, null);
		show = new Event("Students are attempting to put together a show to take mind off the times", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "GainSP", new object[] {3}), new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "GainSP", new object[] {-5}), new TimedMethod(0, "Item", new object[] {new Item[] {new VotedBadge(), new Donut()}}),
			new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Battle", new object[] {
			new Character[] {new DanceMajor(), new MusicMajor(), new HistoryMajor(), new EnglishMajor()}}),
			new TimedMethod(0, "Item", new object[] {new Item[] {new Tuba(), new Heels(), new Donut(), new Textbook()}})}),
			null, "Watch the show. Gain 3 SP", "Assist the group. Lose 5 SP and gain 2 items", "Mug them for all the items", null);
		musicStorage = new ItemEvent(new Item[] {new Tuba(), new Tuba(), new Metronome(), new Baton()},
    		"You found the storage room for the music building");
		begger = new BeggerEvent();
		weights = new Event("You find the weight room, but it is occupied", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "NextEvent", new object[] {new SelectMember("Who will lift?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"GainStrength", 1}),
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strength + 1")})})}),
			new TimedMethod(0, "Battle", new object[] {new Character[] {new PreMed(), new MathMajor()}})}),
			new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Fight for the weights", "Skip", null, null);
		treadmill = new Event("You find the cardio room", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "CauseEvent", new object[] {new SelectMember("Who will run?", new TimedMethod[] {
	    	new TimedMethod(0, "StatChange", new object[] {"GainDexterity", 1}), new TimedMethod(0, "StatChange", new object[] {"SetPower", -5}),
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Dexterity + 1. Power down next fight")})})})}), new LinkedList<TimedMethod>(
			new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Have somebody run. It's very tiring", "Skip", null, null);	
		slimeGoo = new Event("You find a room fludded with slime goop", new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("LoseItems"), new TimedMethod(0, "Item", new object[] {new Item[] {new MysteryGoo(), new MysteryGoo(),
			new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(), new MysteryGoo(),
	        new MysteryGoo(),}})}), new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(0, "Battle", new object[] {new Character[] {
    		new Slime(), new Slime(), new Slime(), new Slime()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("Resolve")}), null, "Sacrifice your items to the slime", "insult the slime", "ignore the slime", null);
		strengthUp = new Event("Strength up event", new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(
		    0, "CauseEvent", new object[] {new SelectMember("Who will be altered?", new TimedMethod[] {new TimedMethod(
		    0, "StatChange", new object[] {"GainStrength", 1}), new TimedMethod(0, "StatChange", new object[] {"GainMaxHP", -1}), 
		    new TimedMethod(0, "CauseEvent", new object[] {new TextEvent("Strengh + 1, maxHP - 1")})})})}), new LinkedList<TimedMethod>(
			new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Send someone to the machine", "No unethical science", null, null);
		flasks = new ItemEvent(new Item[] {new Flask(), new Flask(), new Flask()}, "Some chemistry supplies are left untouched");
		shortcut = new Event("You find a shortcut guarded by 2 Lab Robots", new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod(
		    0, "Shortcut", new object[] {3}), new TimedMethod(0, "Battle", new object[] {new Character[] {new LabRobot(), new LabRobot()}})}),
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}),
		    null, null, "Go through the shortcut", "Go the normal way", null, null);
		food = new ItemEvent(new Item[] {new Pizza(), new Celery(), new Curry(), new ProteinBar()}, "Tons of food is here untouched");
		donuts = new Event("TA's are guarding some donuts", new LinkedList<TimedMethod>(
	        new TimedMethod[] {new TimedMethod(0, "Item", new object[] {new Item[] {new Donut(), new Donut(), new Donut()}}),
			new TimedMethod(0, "Battle", new object[] { new Character[] {new TeachingAssistant(), new TeachingAssistant(),
			new TeachingAssistant(), new TeachingAssistant()}})}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod("Resolve")}), null, null, "It's for the donuts", "Don't bother", null, null);
	    pizzaParty = new Event("You find a fully cooked pizza", new LinkedList<TimedMethod>(new TimedMethod[] {
		    new TimedMethod(0, "Heal", new object[] {5}), new TimedMethod("Resolve")}), new LinkedList<TimedMethod>(new TimedMethod[] {
			new TimedMethod(0, "Item", new object[] {new Item[] {new Pizza()}})}), null, null, "Feast (5 hp to party)", "Take with you", null, null);
	    rescue = new Event("2 Instructors are attacking a student", new LinkedList<TimedMethod>(
	        new TimedMethod[] {new TimedMethod(0, "Ally", new object[] {new Character[] {new HistoryMajor()}}),
			new TimedMethod(0, "Battle", new object[] { new Character[] {new Instructor(), new Instructor()}})}),
		    new LinkedList<TimedMethod>(new TimedMethod[] {new TimedMethod("Resolve")}), null, null, "Help - Gain an ally", "Move on", null, null);
	}
	
	
	public static Event[] CreateTower() {
		List<Event> easy = new List<Event>(new Event[] {cjMajor, representative, business, polSci, hologram});
		List<Event> medium = new List<Event>(new Event[] {admin, rescue, bothBusiness, antiHack, productionTeam});
		List<Event> hard = new List<Event>(new Event[] {fourEngineers, marketing});
		List<Event> reward = new List<Event>(new Event[] {pizzaParty});
		return Create(easy, medium, hard, reward, centralUnit, admission);
	}
	
	public static Event[] CreateDining() {
		List<Event> easy = new List<Event>(new Event[] {chef, culinary, janitor, driver, cultist});
		List<Event> medium = new List<Event>(new Event[] {donuts, doubleHealer, cultBrutes, susMeal});
		List<Event> hard = new List<Event>(new Event[] {fullBus, cookParty});
		List<Event> reward = new List<Event>(new Event[] {food});
		return Create(easy, medium, hard, reward, cultLeader, feast);
	}
	
	public static Event[] CreateResearch() {
		List<Event> easy = new List<Event>(new Event[] {robot, researcher, chemistry, shortcut, aerospace});
		List<Event> medium = new List<Event>(new Event[] {slimeGoo, janislime, potionThrowers, roboticist});
		List<Event> hard = new List<Event>(new Event[] {poisonParty, lectureLab});
		List<Event> reward = new List<Event>(new Event[] {flasks, strengthUp});
		return Create(easy, medium, hard, reward, expirimentor, superPotions);
	}
	
	public static Event[] CreateSports() {
		List<Event> easy = new List<Event>(new Event[] {football, coach, cop, treadmill, mechE});
		List<Event> medium = new List<Event>(new Event[] {coachAndOther, foodTruck, weights, fans1, fans2});
		List<Event> hard = new List<Event>(new Event[] {manyFootball, headCoach});
		List<Event> reward = new List<Event>(new Event[] {treadmill, weights});
		return Create(easy, medium, hard, reward, quarterback, champion);
	}
	
	public static Event[] CreateArts() {
		List<Event> easy = new List<Event>(new Event[] {history, music, dance, english, begger});
		List<Event> medium = new List<Event>(new Event[] {writingPair, tinyBand, twinArt, polGuarded});
		List<Event> hard = new List<Event>(new Event[] {marching, aggressiveArt});
		List<Event> reward = new List<Event>(new Event[] {show, musicStorage});
		return Create(easy, medium, hard, reward, symphony, painting);
	}
	
	public static Event[] CreateHealth() {
		List<Event> easy = new List<Event>(new Event[] {doctor, premed, slime, criminal, treatment});
		List<Event> medium = new List<Event>(new Event[] {criminalCop, medicalResearch, germRoom, rehabHelp, er});
		List<Event> hard = new List<Event>(new Event[] {patients, medicalDrama});
		List<Event> reward = new List<Event>(new Event[] {treatment, secretaryDesk});
		return Create(easy, medium, hard, reward, surgeon, revives);
	}
	
	public static Event[] CreateLecture() {
		List<Event> easy = new List<Event>(new Event[] {instructor, ta, math, psych, cs});
		List<Event> medium = new List<Event>(new Event[] {faculty, headTA, twoCS, stemVarts, rocketScience});
		List<Event> hard = new List<Event>(new Event[] {gradingTeam, mainSubjects});
		List<Event> reward = new List<Event>(new Event[] {coffeeStash});
		return Create(easy, medium, hard, reward, tenured, exam);
	}
	
	public static Event[] Create(List<Event> easy, List<Event> medium, List<Event> hard, List<Event> reward, Event boss, Event final) {
		Event[] arr = new Event[10];
		System.Random rng = new System.Random();
		int index;
		for (int i = 0; i < 3; i++) {
		    index = rng.Next(easy.Count - i);
			if (i == 2) {arr[4] = easy[index];} else {arr[i] = easy[index];}
			easy[index] = easy[easy.Count - 1 - i];
		}
		index = rng.Next(reward.Count);
		arr[3] = reward[index];
		index = rng.Next(medium.Count);
		arr[2] = medium[index];
		medium[index] = medium[medium.Count - 1];
		index = rng.Next(medium.Count - 1);
		arr[5] = medium[index];
		index = rng.Next(hard.Count);
		arr[6] = hard[index];
		arr[7] = beforeBoss;
		arr[8] = boss;
		arr[9] = final;
		return arr;
	}
	
	public static void PlaceBosses(Event[] first, Event[] second, Event[] third, Event[] fourth,
    	Event[] fifth, Event[] sixth, Event[] seventh) {
		
		System.Random rng = new System.Random();
		int index;
		List<Event[]> areas = new List<Event[]>();
		areas.Add(first); areas.Add(second); areas.Add(third); areas.Add(fourth); areas.Add(fifth); areas.Add(sixth); areas.Add(seventh);
		index = rng.Next(7);
		areas[index][8] = politician;
		areas[index] = areas[6];
		index = rng.Next(6);
		areas[index][8] = ceo;
		areas[index] = areas[5];
		index = rng.Next(5);
		areas[index][8] = general;
	}
}
