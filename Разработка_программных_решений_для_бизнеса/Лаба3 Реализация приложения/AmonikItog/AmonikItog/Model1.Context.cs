﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmonikItog
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AmonikLastEntities : DbContext
    {

        private static AmonikLastEntities _context;

        public AmonikLastEntities()
            : base("name=AmonikLastEntities")
        {
        }

        public static AmonikLastEntities GetContext()
        {
            if (_context == null)
                _context = new AmonikLastEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SessionTime> SessionTime { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
