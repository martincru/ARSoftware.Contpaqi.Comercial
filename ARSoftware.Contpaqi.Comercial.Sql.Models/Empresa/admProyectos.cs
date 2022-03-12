﻿using System;
using System.Collections.Generic;

namespace Contpaqi.Comercial.Sql.Models.Empresa
{
    public partial class admProyectos
    {
        public int CIDPROYECTO { get; set; }
        public string CCODIGOPROYECTO { get; set; }
        public string CNOMBREPROYECTO { get; set; }
        public DateTime CFECHAALTA { get; set; }
        public DateTime CFECHABAJA { get; set; }
        public int CESTATUS { get; set; }
        public int CIDVALORCLASIFICACION1 { get; set; }
        public int CIDVALORCLASIFICACION2 { get; set; }
        public int CIDVALORCLASIFICACION3 { get; set; }
        public int CIDVALORCLASIFICACION4 { get; set; }
        public int CIDVALORCLASIFICACION5 { get; set; }
        public int CIDVALORCLASIFICACION6 { get; set; }
        public double CIMPORTE1 { get; set; }
        public double CIMPORTE2 { get; set; }
        public string CSEGCONT1 { get; set; }
        public string CSEGCONT2 { get; set; }
        public string CSEGCONT3 { get; set; }
        public string CTEXTOEXTRA1 { get; set; }
        public string CTEXTOEXTRA2 { get; set; }
        public string CTEXTOEXTRA3 { get; set; }
        public DateTime CFECHAEXTRA { get; set; }
        public double CIMPORTEEXTRA1 { get; set; }
        public double CIMPORTEEXTRA2 { get; set; }
        public double CIMPORTEEXTRA3 { get; set; }
        public double CIMPORTEEXTRA4 { get; set; }
        public string CTIMESTAMP { get; set; }
        public int CTIPOCATALOGO { get; set; }
        public int CIDCATALOGO { get; set; }
    }
}
