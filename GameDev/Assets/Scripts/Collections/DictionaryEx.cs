using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryEx : MonoBehaviour {

	public Dictionary<string,string> statesDict;

	// Use this for initialization
	void Start () {
		statesDict = new Dictionary<string, string>();

		statesDict.Add("MD", "Maryland");
		statesDict.Add("TX", "Texas");
		statesDict.Add("PA", "Pennsylvania");
		statesDict.Add("CA", "California");
		statesDict.Add("MI", "Michigan");

		print("There are "+ statesDict.Count+ " elements in Drctionary statesDict");

		foreach(KeyValuePair<string,string> kvp in statesDict){ // KeyValuePair - тип переменной для прохода по словарю с ключём и его содержимым, <> должны совпадать с указанными в объявлении переменной словаря 
			print(kvp.Key + ": "+ kvp.Value);										  
		}

		print("MI is " +statesDict["MI"] );

		statesDict["BC"] = "British Columbia";

		foreach(string k in statesDict.Keys){
			print(k+" is "+ statesDict[k]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
