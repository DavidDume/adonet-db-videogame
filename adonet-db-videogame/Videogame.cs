﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Videogame(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
