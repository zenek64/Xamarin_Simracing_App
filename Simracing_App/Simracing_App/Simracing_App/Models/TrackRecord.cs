﻿using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Simracing_App.Models
{
    class TrackRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TrackName { get; set; }
        public string CarName { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }


    }
}
