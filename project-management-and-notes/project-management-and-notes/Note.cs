using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management_and_notes
{
    public class Note
    {
        private String Name { get; set; }
        private String content { get; set; }

        public Note(String name, String content)
        {
            this.Name = name;
            this.content =
@"Html<>
<head>
    <p>watch your head<p>
<head/>
<body>
    <h1>take care for your body<h1>
</body>

" + this.ToString();
        }


        public string GetContent()
        {
            return content;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
