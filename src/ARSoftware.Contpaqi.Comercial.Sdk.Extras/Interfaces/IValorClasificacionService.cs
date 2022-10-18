﻿using System.Collections.Generic;
using ARSoftware.Contpaqi.Comercial.Sdk.DatosAbstractos;
using ARSoftware.Contpaqi.Comercial.Sdk.Extras.Models.Enums;

namespace ARSoftware.Contpaqi.Comercial.Sdk.Extras.Interfaces
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