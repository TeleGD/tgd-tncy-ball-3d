using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamWheel : MonoBehaviour
{
    public Material mat1, mat2;

    Ray ray;
    RaycastHit hit;

    Collider coll;
    string selected;
    public int i = 0;

    public string q, d;

    public static Material logo1, logo2;

    public struct Team
    {
        private readonly string name;
        private readonly string fileId;

        public Team(string n, string id)
        {
            this.name = n;
            this.fileId = id;
        }

        public string getName()
        {
            return this.name;
        }

        public string getFileId()
        {
            return this.fileId;
        }

    }

    public static readonly IList<Team> teams = new ReadOnlyCollection<Team>(
        new[]
        {
            new Team("Alisé", "alise"),                         // 0
            new Team("Anim'Est", "animest"),
            new Team("Bureau des Sports", "bds"),
            new Team("Ceten", "ceten"),
            new Team("ÉcoleNonÉcole", "ecolenonecole"),
            new Team("Humani'TN", "humanitn"),                  // 5
            new Team("TELECOM Nancy\nServices", "tns"),
            new Team("Abso'ludique", "jeux"),
            new Team("Aquacité", "aquacite"),
            new Team("Bar'Bapapa", "bar"),
            new Team("Conférences", "conference"),              // 10
            new Team("Gala", "gala"),
            new Team("HackIn'TN", "hacking"),
            new Team("Langues", "langues"),
            new Team("Les Baroudeurs", "baroudeurs"),
            new Team("L'Inté de l'Olympe", "integration"),      // 15
            new Team("MadPad", "madpad"),
            new Team("Marché de TELECOM", "marche"),
            new Team("Mini Tel'", "minitel"),
            new Team("Œnologie", "oenologie"),
            new Team("Pix'Art", "bda"),                         // 20
            new Team("Solidarité", "solidarite"),
            new Team("Studio", "studio"),
            new Team("Tek'TN", "tektn"),
            new Team("Telecom Air Force", "telecomeairforce"),
            new Team("Telecome Cooking", "cooking"),            // 25
            new Team("Télécube", "telecube"),
            new Team("TeleGame Design", "tgd"),
            new Team("Téloquencia", "teloquencia"),
            new Team("Thélécom", "thelecom"),
            new Team("TN 24", "24"),                            // 30
            new Team("Voyage", "voyage"),
            new Team("Aléatoire", "random")
        });

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TeamSelector")
        {
            timer = 0;
            mat1 = Resources.Load<Material>("Arrow");
            mat2 = Resources.Load<Material>("GoldenArrow");

            this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", teams[i].getFileId())));
            this.gameObject.transform.GetChild(1).Find("Name").GetComponent<TextMesh>().text = teams[i].getName();
            updateLogos();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TeamSelector")
        {

            // Check mouse controls
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                coll = hit.collider;
            }

                if (timer >= 0.1)
            {
                gameObject.transform.GetChild(1).Find(selected).GetComponent<MeshRenderer>().material = mat1;
                timer = 0;
            }
            else if (timer > 0)
            {
                timer = timer + Time.deltaTime;
            }
            else if (Input.GetKeyDown(q) || (Input.GetMouseButtonUp(0) && coll.name == "Left" && gameObject.name == coll.gameObject.transform.parent.parent.name))
            {
                i -= 1;
                if (i < 0) i = teams.Count - 1;
                this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", teams[i].getFileId())));
                this.gameObject.transform.GetChild(1).Find("Name").GetComponent<TextMesh>().text = teams[i].getName();
                updateLogos();
                gameObject.transform.GetChild(1).Find("Left").GetComponent<MeshRenderer>().material = mat2;
                selected = "Left";
                timer = timer + Time.deltaTime;
            }
            else if (Input.GetKeyDown(d) || (Input.GetMouseButtonUp(0) && coll.name == "Right" && gameObject.name == coll.gameObject.transform.parent.parent.name))
            {
                i += 1;
                if (i >= teams.Count) i = 0;
                this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", teams[i].getFileId())));
                this.gameObject.transform.GetChild(1).Find("Name").GetComponent<TextMesh>().text = teams[i].getName();
                updateLogos();
                gameObject.transform.GetChild(1).Find("Right").GetComponent<MeshRenderer>().material = mat2;
                selected = "Right";
                timer = timer + Time.deltaTime;
            }

        }
    }

    private void updateLogos()
    {
        if (this.gameObject.name == "Team1")
        {
            logo1 = this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material;
        }
        if (this.gameObject.name == "Team2")
        {
            logo2 = this.gameObject.transform.Find("Team_Logo").GetComponent<MeshRenderer>().material;
        }
    }

}
