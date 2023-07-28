﻿using System.Collections.Generic;
using ARSoftware.Contpaqi.Comercial.Sdk.DatosAbstractos;
using ARSoftware.Contpaqi.Comercial.Sdk.Extras.Models;

namespace ARSoftware.Contpaqi.Comercial.Sdk.Extras.Interfaces;

public interface IDireccionService
{
    void Actualizar(tDireccion direccion);
    void Actualizar(int idDireccion, Dictionary<string, string> datosDireccion);
    int Crear(tDireccion direccion);
    int Crear(Dictionary<string, string> datosDireccion);
    int Crear(string codigoClienteProveedor, Direccion direccion);
}