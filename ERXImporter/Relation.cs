﻿using System;
using System.Collections.Generic;

namespace ERXImporter
{
    public class Relation
    {
        public string fromTable { get; set; }
        public string fromColumn { get; set; }
        public string toTable { get; set; }
        public string toColumn { get; set; }
        public string joinSpecification
        {
            get
            {
                var joinSpec = string.Empty;
                int i = 0;
                foreach (var fromcolum in this.fromColumns)
                {
                    //add newline if needed
                    if (!string.IsNullOrEmpty(joinSpec))
                    {
                        joinSpec += Environment.NewLine;
                    }
                    joinSpec += $"{fromcolum} = ";
                    if (this.toColumns.Count >= i)
                    {
                        joinSpec += this.toColumns[i];
                    }
                    //up the counter
                    i++;
                }
                return joinSpec;
              }
        }
        public List<string> fromColumns { get; set; }
        public List<string> toColumns { get; set; }
        public string getCSVLine()
        {
            return string.Join(";", new string[] { this.fromTable, this.fromColumn, this.toTable, this.toColumn, $"\"{this.joinSpecification}\"" });
        }

    }
}
