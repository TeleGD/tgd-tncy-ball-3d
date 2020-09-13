using System.Collections.Generic;
using UnityEngine;

public class TeamSelector
{
    public static int[] selectedTeam;

    static TeamSelector()
    {
        selectedTeam = new int[2];
        selectedTeam[0] = Random.Range(0, teams.Count - 1);
        selectedTeam[1] = Random.Range(0, teams.Count - 1);
    }

    public static Team GetSelection(int teamID)
    {
        return teams[selectedTeam[teamID]];
    }

    public struct Team
    {
        private string name;
        private Texture2D logo;

        public Team(string n, string file)
        {
            this.name = n;
            this.logo = Resources.Load<Texture2D>(string.Concat("Logos/", file));
        }

        public string GetName()
        {
            return this.name;
        }

        public Texture2D GetLogo()
        {
            return this.logo;
        }

    }

    public static readonly List<Team> teams = new List<Team>(
        new[]
        {
            new Team("Anim'Est", "animest"),
            new Team("Airsoft", "airsoft"),
            new Team("Bar", "bar"),
            new Team("Les Baroudeurs", "baroudeurs"),
            new Team("BDA", "bda"),
            new Team("BDE", "bde"),
            new Team("BDS", "bds"),
            new Team("Conférences", "conference"),
            new Team("ÉcoleNonÉcole", "ecolenonecole"),
            new Team("Gala", "gala"),
            new Team("Hackitaine", "hackintn"),
            new Team("Humani'TN", "humanitn"),
            new Team("Intégration", "integration"),
            new Team("Jeux", "jeux"),
            new Team("Langues", "langues"),
            new Team("MadPad", "madpad"),
            new Team("Mini Tel'", "minitel"),
            new Team("Œnologie", "oenologie"),
            new Team("Solidarité", "solidarite"),
            new Team("Studio", "studio"),
            new Team("Tek'TN", "tektn"),
            new Team("Telecom Air Force", "telecomeairforce"),
            new Team("Telecome Cooking", "cooking"),
            new Team("TeleGame Design", "tgd"),
            new Team("TN 24", "24"),
            new Team("TELECOM Nancy\nServices", "tns"),
            new Team("Voyage", "voyage"),
            new Team("Aléatoire", "random")
        });
}
