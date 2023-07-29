﻿namespace ARSoftware.Contpaqi.Comercial.Sdk.Extras.Models.ValueObjects;

public class ImpuestosMovimiento
{
    /// <summary>
    ///     Impuesto 1 del movimiento. Normalmente es el IVA.
    /// </summary>
    public Impuesto Impuesto1 { get; set; }

    /// <summary>
    ///     Impuesto 2 del movimiento. Normalmente es el IEPS.
    /// </summary>
    public Impuesto Impuesto2 { get; set; }

    /// <summary>
    ///     Impuesto 3 del movimiento.
    /// </summary>
    public Impuesto Impuesto3 { get; set; }
}