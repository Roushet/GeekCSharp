using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class QuestionData
    {
        private string question;
        private string answer;
        private string description;

        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
        public string Description { get => description; set => description = value; }

        public QuestionData()
        {
            question = "";
            answer = "";
            description = "";
        }

    }

}
