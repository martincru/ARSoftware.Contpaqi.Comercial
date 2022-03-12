﻿using System.Collections.Generic;
using Contpaqi.Sdk.DatosAbstractos;
using Contpaqi.Sdk.Extras.Models.Enums;

namespace Contpaqi.Sdk.Extras.Interfaces
{
    public interface IValorClasificacionService
    {
        void Actualizar(int idValorClasificacion, Dictionary<string, string> datosValorClasificacion);
        void Actualizar(string codigoValorClasificacion, ref tValorClasificacion valorClasificacion);
        int Crear(tValorClasificacion valorClasificacion);
        int Crear(Dictionary<string, string> datosValorClasificacion);
        void Eliminar(int idValorClasificacion);
        void Eliminar(TipoClasificacion tipoClasificacion, NumeroClasificacion numeroClasificacion, string codigoValorClasificacion);
    }
}
