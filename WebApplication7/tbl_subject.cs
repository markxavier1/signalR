//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication7
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_subject
    {
        public int sub_id { get; set; }
        public string sub_name { get; set; }
        public string sub_address { get; set; }
        public string sub_sex { get; set; }
        public string sub_email { get; set; }
        public string sub_anti_national { get; set; }
        public string sub_organization { get; set; }
        public string sub_position { get; set; }
        public string sub_source { get; set; }
        public byte[] sub_profile_pic { get; set; }
    
        public virtual tbl_subject tbl_subject1 { get; set; }
        public virtual tbl_subject tbl_subject2 { get; set; }
    }
}
