﻿using System;
using System.Collections.Generic;

namespace Contpaqi.Comercial.Sql.Models.Generales
{
    public partial class MantenimientoBDDProcesos
    {
        public string cGuidProceso { get; set; }
        public DateTime? cFechaInicial { get; set; }
        public DateTime? cFechaFinal { get; set; }
        public int? cLogsEliminados { get; set; }
        public int? cIndicesReorganizados { get; set; }
        public int? cIndicesReconstruidos { get; set; }
        public int? cUpdStatix { get; set; }
    }
}
