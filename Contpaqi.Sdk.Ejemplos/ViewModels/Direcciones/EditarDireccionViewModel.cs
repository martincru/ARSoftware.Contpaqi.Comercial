﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contpaqi.Comercial.Sql.Models.Empresa;
using Contpaqi.Sdk.DatosAbstractos;
using Contpaqi.Sdk.Ejemplos.Messages;
using Contpaqi.Sdk.Extras.Extensions;
using Contpaqi.Sdk.Extras.Interfaces;
using Contpaqi.Sdk.Extras.Models;
using Contpaqi.Sdk.Extras.Models.Enums;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace Contpaqi.Sdk.Ejemplos.ViewModels.Direcciones;

public class EditarDireccionViewModel : ObservableRecipient
{
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly IDireccionRepository<Direccion> _direccionRepository;
    private readonly IDireccionService _direccionService;
    private Direccion _direccion;

    public EditarDireccionViewModel(IDireccionService direccionService,
                                    IDialogCoordinator dialogCoordinator,
                                    IDireccionRepository<Direccion> direccionRepository)
    {
        _direccionService = direccionService;
        _dialogCoordinator = dialogCoordinator;
        _direccionRepository = direccionRepository;

        GuardarCommand = new AsyncRelayCommand(GuardarAsync);
        CancelarCommand = new RelayCommand(CerrarVista);
    }

    public string Title { get; } = "Editar Direccion";

    public string CodigoClienteProveedor { get; set; }

    public Direccion Direccion
    {
        get => _direccion;
        private set => SetProperty(ref _direccion, value);
    }

    public IEnumerable<TipoDireccion> TiposDireccion { get; } = Enum.GetValues(typeof(TipoDireccion)).Cast<TipoDireccion>().ToList();

    public IAsyncRelayCommand GuardarCommand { get; }
    public IRelayCommand CancelarCommand { get; }

    private void CargarDireccion(int idDireccion)
    {
        Direccion = _direccionRepository.BuscarPorId(idDireccion);
    }

    private void CerrarVista()
    {
        Messenger.Send(new ViewModelVisibilityChangedMessage(this, false));
    }

    private async Task GuardarAsync()
    {
        try
        {
            MessageDialogResult messageDialogResult = await _dialogCoordinator.ShowMessageAsync(this,
                "Usar funciones de Alto Nivel o de Bajo Nivel?",
                "Usar funciones de Alto Nivel o de Bajo Nivel?",
                MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings { AffirmativeButtonText = "Alto Nivel", NegativeButtonText = "Bajo Nivel" });

            int idDireccion = messageDialogResult == MessageDialogResult.Affirmative ? GuardarUsandoAltoNivel() : GuardarUsandoBajoNivel();

            await _dialogCoordinator.ShowMessageAsync(this, "Direccion Guardada", "Direccion guardada exitosamente.");

            CargarDireccion(idDireccion);
        }
        catch (Exception e)
        {
            await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
        }
        finally
        {
            RaiseGuards();
        }
    }

    private int GuardarUsandoAltoNivel()
    {
        int idDireccion = Direccion.CIDDIRECCION;
        tDireccion tDireccion = Direccion.ToTDireccion();
        tDireccion.cCodCteProv = CodigoClienteProveedor;

        if (idDireccion == 0)
        {
            idDireccion = _direccionService.Crear(tDireccion);
        }
        else
        {
            _direccionService.Actualizar(tDireccion);
        }

        return idDireccion;
    }

    private int GuardarUsandoBajoNivel()
    {
        int idDireccion = Direccion.CIDDIRECCION;

        Dictionary<string, string> datosDireccion = Direccion.ToDatosDictionary<admDomicilios>();

        if (Direccion.CIDDIRECCION == 0)
        {
            idDireccion = _direccionService.Crear(datosDireccion);
        }
        else
        {
            _direccionService.Actualizar(Direccion.CIDDIRECCION, datosDireccion);
        }

        return idDireccion;
    }

    public void Inicializar(TipoCatalogoDireccion tipoCatalogoDireccion, string codigoClienteProveedor, int idCatalogo)
    {
        CodigoClienteProveedor = codigoClienteProveedor;
        Direccion = new Direccion { TipoCatalogo = tipoCatalogoDireccion, CIDCATALOGO = idCatalogo };
    }

    public void Inicializar(int idDireccion)
    {
        CargarDireccion(idDireccion);
    }

    private void RaiseGuards()
    {
        GuardarCommand.NotifyCanExecuteChanged();
        CancelarCommand.NotifyCanExecuteChanged();
    }
}
