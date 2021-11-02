using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Devoir_01.Models
{
    public class Temperature
    {
        public DateTime Date { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public int Temp { get; set; }

        public static List<Temperature> Init()
        {
            List<Temperature> temperatures = new List<Temperature>();

            // Lecture du fichier et itération sur les lignes lues
            // File.ReadAllLines crée un tableau de string
            // représentant chaque ligne
            int count = 0;
            foreach (var line in File.ReadAllLines("weather_montreal.txt"))
            {
                // Certaines lignes sont vides
                // et doivent être filtrées
                if (string.IsNullOrEmpty(line) || count == 0)
                {
                    count++;
                    continue;
                }
                // split construit un tableau de string à partir
                // d'une ligne découpée suivant les tabulations
                var entries = line.Split('\t');


                // Ajout de l'instance dans le conteneur
                temperatures.Add(new Temperature
                {
                    Date = new DateTime(int.Parse(entries[0]),int.Parse(entries[1]),int.Parse(entries[2])),
                    MaxTemp = int.Parse(entries[3]),
                    MinTemp = int.Parse(entries[4]),
                    Temp = int.Parse(entries[5])
                });
            }
            // La liste d'objets est lue, on peut commencer à jouer
            return temperatures;
        }
    }


}
