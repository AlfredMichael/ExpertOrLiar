using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exol.Model
{
    public class QuizQuestion 
    {

        public string Text { get; set; }
         public ObservableCollection<string> Options { get; set; }
         public string SelectedOption { get; set; }
         public string CorrectAnswer { get; set; }
         public string Category { get; set; }
    }
}
