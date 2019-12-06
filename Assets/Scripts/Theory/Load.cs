using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine.UI;


public class Load : MonoBehaviour
{
    public GameObject textTitle;
    public GameObject textBody;

    private static Dictionary<string, List<string>> bodiesByTitles;

    private void Start()
    {
        //LoadTheoryData();
    }

    private void Update()
    {
        
    }

    public void LoadTheoryData(string lessonName)
    {
        bodiesByTitles = new Dictionary<string, List<string>>();

        TextAsset xmlData = (TextAsset)Resources.Load("Theory");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlData.text);

        foreach (XmlNode theory in xmlDocument["theories"].ChildNodes)
        {
            string theoryName = theory.Attributes["name"].Value;
            if (theoryName == lessonName)
            {
                theoryName = lessonName;
                List<string> bodies = new List<string>();
                foreach (XmlNode body in theory["bodies"].ChildNodes)
                {
                    bodies.Add(body.InnerText);
                }

                bodiesByTitles[theoryName] = bodies;
            }

           
        }
    }

    public void PopulateText(int numberTheory)
    {
        foreach(KeyValuePair<string, List<string>> bodiesByTitle in bodiesByTitles)
        {
            textTitle.GetComponent<Text>().text = bodiesByTitle.Key;
            textBody.GetComponent<Text>().text = bodiesByTitle.Value[numberTheory];

        }
    }

}
