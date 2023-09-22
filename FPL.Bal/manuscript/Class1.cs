using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPL.Bal.manuscript
{
    public class Class1
    {
        public class abc
        {
            public string authorname;
            public string contactnum;
            public string email;
            public string title;
            public string abstracts;
            public string body;
            public string reference;

            public int id { get; set; }
            public Nullable<int> ManuscriptNo { get; set; }
            public string Subject { get; set; }
            public string Title { get; set; }
            public string ManuscriptType { get; set; }
            public string Abstract { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
        }
    }
}
