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
    
    public partial class Zayvka
    {
        public int Cod { get; set; }
        public string Number { get; set; }
        public int id { get; set; }
    
        public virtual Disciplina Disciplina { get; set; }
        public virtual Specialnost Specialnost { get; set; }
    }
}