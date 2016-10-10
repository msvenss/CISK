﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvOfCode5.NiceStringRules;

namespace AdvOfCode5
{
    public class StringChecker
    {
        public bool IAmNice => CheckIfStringIsNice();
        private readonly string _stringToCheck;
        private readonly IEnumerable<INiceRule> _rules;

        public StringChecker(string stringToCeck, IEnumerable<INiceRule> rules)
        {
            _stringToCheck = stringToCeck;
            _rules = rules;
        }

        public bool CheckIfStringIsNice()
        {
                var iAmNice = true;
                foreach (var rule in _rules)
                {
                   
                if (rule.SubStringIsAllowed(_stringToCheck) == false)
                {
                    iAmNice = false;
                    break;
                }
            }
                return iAmNice;
        }
    }
}

