﻿using System;
using System.Collections.Generic;

namespace Contpaqi.Comercial.Sql.Models.Generales
{
    public partial class admVistasConsultas
    {
        public int CIDCONSULTA { get; set; }
        public int CIDSISTEMA { get; set; }
        public int CIDIDIOMA { get; set; }
        public int CIDMODULO { get; set; }
        public int CTIPO { get; set; }
        public int CCOLUMNASOCULTAR { get; set; }
        public string CNOMBRECONSULTA { get; set; }
        public string CSENTENCIASQL { get; set; }
    }
}
