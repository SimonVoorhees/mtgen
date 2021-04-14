﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace mtgen.Models
{
    [DebuggerDisplay("Code:{Code} Name:{Name} Block:{Block} IsFutureSet:{IsFutureSet}")]
    public class Set
    {
        //public Set()
        //{
        //}

        public string Code { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }
        public string CardCountClass { get; set; }
        public bool Incomplete { get; set; } = false;
        public string CreatedText { get; set; }
        public string SetFile { get; set; } = "/sets.json";
        public IList<string> CardFiles { get; set; } = new List<string>() { "cardsMain.json", "cardsToken.json", "cardsOther.json" };
        public IList<string> PackFiles { get; set; } = new List<string>() { "packs.json" };
        public string ProductFile { get; set; } = "products.json";
        public string StartProductName { get; set; }

        public IList<Update> Updates { get; set; } = new List<Update>();

        public string Image { set; get; }
        public DateTime? GeneratorCreatedDate { set; get; }
        public DateTime? PrereleaseDate { get; set; }
        public DateTime? ReleaseDate { set; get; }

        public bool IsCoreSet { get; set; }
        public string Block { get; set; }
        public bool IsBlockSet => !string.IsNullOrEmpty(Block);
        public IList<Set> BlockSets { get; set; } // will be filled in by HomeController for the Index page

        public bool IsFutureSet { get; set; }
        public bool IsCurrentSet { get; set; }
        public bool IsHidden { get; set; } = false;

        public Set(string code, string name, string image, int cardCount,
            string generatorCreatedDate, string prereleaseDate, string releaseDate, 
            bool isCoreSet, string block, bool isCurrentSet, bool isFutureSet, bool isHidden = false)
        {
            Code = code?.ToLower();
            Name = name;
            Image = image;
            CardCount = cardCount;
            IsCoreSet = isCoreSet;
            Block = block;
            IsCurrentSet = isCurrentSet;
            IsFutureSet = isFutureSet;
            IsHidden = isHidden;

            DateTime date;
            if (DateTime.TryParse(generatorCreatedDate, out date))
            {
                GeneratorCreatedDate = date;
            }
            if (DateTime.TryParse(prereleaseDate, out date))
            {
                PrereleaseDate = date;
            }
            if (DateTime.TryParse(releaseDate, out date))
            {
                ReleaseDate = date;
            }
        }
    }
}