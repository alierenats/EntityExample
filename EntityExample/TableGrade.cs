//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityExample
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableGrade
    {
        public int GRADEID { get; set; }
        public Nullable<int> STDNT { get; set; }
        public Nullable<int> CLASS { get; set; }
        public Nullable<short> EXAM1 { get; set; }
        public Nullable<short> EXAM2 { get; set; }
        public Nullable<short> EXAM3 { get; set; }
        public Nullable<decimal> AVERAGE { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public object CLASSNAME { get; internal set; }
    }
}
