using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_management_and_notes
{
    public class CssCode
    {
        private String code;
        private String description;     // the gay who use this sowtware use function as name for the description
                                        // description is being used for searching

        public CssCode()
        {
            // default constructor
            this.code = "";
            this.description = "";
        }

        public String GetCode()
        {
            return this.code;
        }

        public void SetCode(String code)
        {
            this.code = code;
        }

        public String GetDescription()
        {
            return this.description;
        }

        public void SetDescription(String s)
        {
            this.description = s;
        }

        public override string ToString()
        {
            return this.GetDescription();
        }
    }
}
