//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uchebka322mat.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZavCafedra
    {
        public int id { get; set; }
        public Nullable<int> TabNuber { get; set; }
        public string Spec { get; set; }
    
        public virtual Sotrudnik Sotrudnik { get; set; }
    }
}
