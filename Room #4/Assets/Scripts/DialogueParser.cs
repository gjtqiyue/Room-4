using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour {


	struct DialogueLine {
		public string name;
		public string content;
        //public string music;
		public string[] options;

		public DialogueLine (string Name, string Content) {
			name = Name;
			content = Content;
            //music = Music;
			options = new string[0];
		}
	}
		
	List <DialogueLine> lines;

    public TextAsset dialogue;

	void Start () {
		lines = new List<DialogueLine> ();
		Debug.Log ("start loading");
		LoadDialogue ();
	}

	void Update () {
		
	}

	void LoadDialogue () {
		string[] line;
        //StreamReader r = new StreamReader (filename);
        int j = 0;

       
            
        line = dialogue.text.Split('\n');
		while (j < line.Length) {
			string[] lineData = line[j].Split (';');
            j++;
			if (lineData [0] == "Player") {
				DialogueLine lineEntry = new DialogueLine (lineData [0], "");
				lineEntry.options = new string[lineData.Length - 1];

				for (int i = 1; i < lineData.Length; i++) {
					lineEntry.options [i - 1] = lineData [i];
				}
				lines.Add (lineEntry);
			} else {
				DialogueLine lineEntry = new DialogueLine (lineData [0], lineData [1]);
				lines.Add (lineEntry);
			}
		}
		
		
	}

	public string GetName (int lineNumber) {
		if (lineNumber < lines.Count)
			return lines [lineNumber].name;
		
		return "";
	}

	public string GetContent (int lineNumber) {
		if (lineNumber < lines.Count)
			return lines[lineNumber].content;

		return "";
	}


    //public string GetMusic(int lineNumber)
    //{
    //    if (lineNumber < lines.Count)
    //        return lines[lineNumber].music;

    //    return "";
    //}

    public string[] GetOptions (int lineNumber) {
		if (lineNumber < lines.Count)
			return lines [lineNumber].options;

		return new string[0];
	}
}
