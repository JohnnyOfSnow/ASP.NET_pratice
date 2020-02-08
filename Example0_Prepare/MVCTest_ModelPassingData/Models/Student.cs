using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest_ModelPassingData.Models
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int score { get; set; }

        Student()
        {
            id = string.Empty;
            name = string.Empty;
            score = 0;
        }

        public Student(string _id, string _name, int _score)
        {
            id = _id;
            name = _name;
            score = _score;
        }

        public override string ToString()
        {
            return $"學號: " + id + "姓名: " + name + "成績: " + score;
        }
    }
}