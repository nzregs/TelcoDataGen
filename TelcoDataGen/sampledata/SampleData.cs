﻿using System.Collections.Generic;
using TelcoDataGen.model;

namespace TelcoDataGen.sampledata
{
        public static class SampleData
        {
            public static IEnumerable<Tower> GetTowers()
            {
                // tower info discovered at http://beta.gis.geek.nz
                yield return new Tower { TowerId = "100000", Name = "MATIATIA", Description = "Matiatia tower", City = "Auckland", Address = "9 Oceanview Road, Oneroa, Auckland 1081, New Zealand", Latitude = "-36.779823", Longitude = "174.992032" };
                yield return new Tower { TowerId = "100001", Name = "WAIHEKE ISLAND 2", Description = "Waiheke Island #2 Tower", City = "Auckland", Address = "127 Oceanview Road, Oneroa, Auckland 1081, New Zealand", Latitude = "-36.7814232", Longitude = "175.0068099" };
                yield return new Tower { TowerId = "100002", Name = "ONEROA TOWNSHIP", Description = "Oneroa Township Tower", City = "Auckland", Address = "2 Tui Street, Oneroa. Auckland 1081, New Zealand", Latitude = "-36.783767", Longitude = "175.0107831" };
                yield return new Tower { TowerId = "100003", Name = "BLACKPOOL", Description = "Blackpool tower", City = "Auckland", Address = "10 Moa Ave, Oneroa, Auckland 1081, New Zealand", Latitude = "-36.7861592", Longitude = "175.0132661" };
                yield return new Tower { TowerId = "100004", Name = "SURFDALE", Description = "Surfdale tower", City = "Auckland", Address = "5 Hamilton Road, Surfdale, Auckland 1081, New Zealand", Latitude = "-36.7923971", Longitude = "175.0211514" };
                yield return new Tower { TowerId = "100005", Name = "PALM BEACH BTS", Description = "Palm Beach tower", City = "Auckland", Address = "Little Palm Beach, Miro Road, Auckland 1081, New Zealand", Latitude = "-36.7811811", Longitude = "175.034491" };
                yield return new Tower { TowerId = "100006", Name = "OKAHUTI CREEK", Description = "Okahuti Creek tower", City = "Auckland", Address = "6 Belgium Street, Ostend, Auckland 1081, New Zealand", Latitude = "-36.79559", Longitude = "175.044882" };
                yield return new Tower { TowerId = "100007", Name = "TANK FARM", Description = "Tank Farm tower", City = "Auckland", Address = "10 Madden Street, Auckland 1010, New Zealand", Latitude = "-36.842066", Longitude = "174.7569239" };
                yield return new Tower { TowerId = "209064", Name = "POINT JERNINGHAM (VFNZ)", Description = "Point Jerningham tower", City = "Wellington", Address = "Point Jerningham, Roseneath, Wellington 6021, New Zealand", Latitude = "-41.2920115", Longitude = "174.7937954" };
                yield return new Tower { TowerId = "239042", Name = "HERD ST (VFNZ)", Description = "Herd St tower", City = "Wellington", Address = "Herd St, Wellington 6011, New Zealand", Latitude = "-41.291100000", Longitude = "174.784000000" };
                yield return new Tower { TowerId = "233462", Name = "CIVIC CENTRE (VFNZ)", Description = "Civic Centre tower", City = "Wellington", Address = "Wharewaka Function Centre, 2 Taranaki Street, Wellington 6011, New Zealand", Latitude = "-41.289215", Longitude = "174.7790228" };
                yield return new Tower { TowerId = "236663", Name = "COURTENAY PLACE (VFNZ)", Description = "Courtenay Place tower", City = "Wellington", Address = "11 Courtenay Place, Te Aro, Wellington 6011, New Zealand", Latitude = "-41.2941276", Longitude = "174.780592" };
                yield return new Tower { TowerId = "209653", Name = "COURTENAY WEST (VFNZ)", Description = "Courtenay Place West tower", City = "Wellington", Address = "69 Inglewood Place, Te Aro, Wellington 6011, New Zealand", Latitude = "-41.2930437", Longitude = "174.7782451" };
                yield return new Tower { TowerId = "209051", Name = "MAJESTIC TOWERS (VFNZ)", Description = "Majestic Towers tower", City = "Wellington", Address = "15 Boulcott St, Wellington 6011, New Zealand", Latitude = "-41.2885477", Longitude = "174.7719846" };
                yield return new Tower { TowerId = "244292", Name = "WILLESTON 2 (VFNZ)", Description = "Willeston Centre tower", City = "Wellington", Address = "Willeston Centre, Willeston St, Wellington 6011, New Zealand", Latitude = "-41.2864928", Longitude = "174.7764585" };
                yield return new Tower { TowerId = "244121", Name = "Gloucester Street", Description = "Gloucester Street", City = "Christchurch", Address = "333 Gloucester Street, Christchurch, New Zealand", Latitude = "-43.5298803", Longitude = "172.6504103" };
                yield return new Tower { TowerId = "244107", Name = "Churchill Street", Description = "Churchill Street", City = "Christchurch", Address = "302 Bealey Ave, Christchurch, New Zealand", Latitude = "-43.52090461523908", Longitude = "172.64806289043804" };
                yield return new Tower { TowerId = "208742", Name = "Edgeware Road", Description = "Edgeware Road", City = "Christchurch", Address = "63 Edgeware Road, Christchurch, New Zealand", Latitude = "-43.51344703354663", Longitude = "172.63700768888998" };

        }
    }
}
