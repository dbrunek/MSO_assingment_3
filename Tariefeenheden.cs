using System;

namespace Lab3
{
    public static class Tariefeenheden
    {
        public static int van;
        public static int naar;
        static int[,] tabel = new int[7, 7];
        public static string[] getStations()
        {
            return new string[] {
                "Utrecht Centraal",
                "Gouda",
                "Geldermalsen",
                "Hilversum",
                "Duivendrecht",
                "Weesp"
            };
        }

        public static int getTariefeenheden(string from, string to)
        {
            //sorrry moest ff tabel vullen ;-)
            tabel[0, 0] = 0; tabel[1, 0] = 0; tabel[2, 0] = 0; tabel[3, 0] = 0; tabel[4, 0] = 0; tabel[5, 0] = 0; tabel[6, 0] = 0;
            tabel[0, 1] = 0; tabel[1, 1] = 0; tabel[2, 1] = 32; tabel[3, 1] = 26; tabel[4, 1] = 18; tabel[5, 1] = 31; tabel[6, 1] = 33;
            tabel[0, 2] = 0; tabel[1, 2] = 32; tabel[2, 2] = 0; tabel[3, 2] = 58; tabel[4, 2] = 45; tabel[5, 2] = 10; tabel[6, 2] = 23;
            tabel[0, 3] = 0; tabel[1, 3] = 20; tabel[2, 3] = 32; tabel[3, 3] = 0; tabel[4, 3] = 18; tabel[5, 3] = 41; tabel[6, 3] = 33;
            tabel[0, 4] = 0; tabel[1, 4] = 20; tabel[2, 4] = 12; tabel[3, 4] = 26; tabel[4, 4] = 0; tabel[5, 4] = 31; tabel[6, 4] = 33;
            tabel[0, 5] = 0; tabel[1, 5] = 24; tabel[2, 5] = 22; tabel[3, 5] = 26; tabel[4, 5] = 18; tabel[5, 5] = 0; tabel[6, 5] = 63;
            tabel[0, 6] = 0; tabel[1, 6] = 34; tabel[2, 6] = 35; tabel[3, 6] = 56; tabel[4, 6] = 27; tabel[5, 6] = 31; tabel[6, 6] = 0;

            switch (from)
            {
                case "Utrecht Centraal": van = 1; break;
                case "Gouda": van = 2; break;
                case "Geldermalsen": van = 3; break;
                case "Hilversum": van = 4; break;
                case "Duivendrecht": van = 5; break;
                case "Weesp": van = 6; break;
                default: van = 0; break;
            }

            switch (to)
            {
                case "Utrecht Centraal": naar = 1; break;
                case "Gouda": naar = 2; break;
                case "Geldermalsen": naar = 3; break;
                case "Hilversum": naar = 4; break;
                case "Duivendrecht": naar = 5; break;
                case "Weesp": naar = 6; break;
                default: naar = 0; break;
            }

            return tabel[van, naar];
        }
    }
}

