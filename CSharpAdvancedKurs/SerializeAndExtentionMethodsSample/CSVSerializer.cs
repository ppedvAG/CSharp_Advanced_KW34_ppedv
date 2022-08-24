﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAndExtentionMethodsSample
{
    public static class CSVSerializer
    {
        public static void Speichern(this Person p, string savePath)
        {
            File.WriteAllText(savePath, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLimit};");
        }

        public static void Laden(this Person p, string loadPath)
        {
            string content = File.ReadAllText(loadPath);

            string[] csvPart = content.Split(';');

            p.Vorname = csvPart[0];
            p.Nachname = csvPart[1];
            p.Alter = int.Parse(csvPart[2]);
            p.Kontostand = Convert.ToInt32(csvPart[3]);
            p.KreditLimit = Convert.ToInt32(csvPart[4]);

        }
    }
}
