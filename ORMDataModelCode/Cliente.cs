﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Ejemplo1ORM.bdventa
{

    public partial class Cliente
    {
        public Cliente(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
