//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comment1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostsHistory
    {
        public int HistoryId { get; set; }
        public int PostID { get; set; }
        public string Message { get; set; }
        public System.DateTime ChangedDate { get; set; }
        public string UserId { get; set; }
    }
}
