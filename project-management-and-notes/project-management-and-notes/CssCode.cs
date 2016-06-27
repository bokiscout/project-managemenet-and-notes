//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_management_and_notes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public partial class CSSCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Function { get; set; }
        public Nullable<int> ProjectId { get; set; }
    
        public virtual Project Project { get; set; }

        public override string ToString()
        {
            return Function;
        }

        internal string toBackUpFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + "____");
            sb.Append(ProjectId + "____");
            sb.Append(Function + "____");
            sb.Append(Code + "EOL\n");

            return sb.ToString();
        }
    }
}
