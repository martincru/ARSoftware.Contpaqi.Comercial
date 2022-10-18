﻿using System.Collections.Generic;
using ARSoftware.Contpaqi.Comercial.Sdk.Extras.Models.Enums;

namespace ARSoftware.Contpaqi.Comercial.Sdk.Extras.Interfaces
{
    public interface IDireccionRepository<T> where T : class, new()
    {
        T BuscarPorCliente(string codigoClienteProveedor, byte tipoDireccion);
        T BuscarPorDocumento(int idDocumento, byte tipoDireccion);
        T BuscarPorId(int idDireccion);
        IEnumerable<T> TraerPorTipo(TipoCatalogoDireccion tipoCatalogoDireccion);
        IEnumerable<T> TraerPorTipoYIdCatalogo(TipoCatalogoDireccion tipoCatalogoDireccion, int idCatalogo);
        IEnumerable<T> TraerTodo();
    }
}