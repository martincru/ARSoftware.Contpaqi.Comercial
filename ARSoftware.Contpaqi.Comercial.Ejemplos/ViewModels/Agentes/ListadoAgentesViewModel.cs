﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using ARSoftware.Contpaqi.Comercial.Ejemplos.Views.Agentes;
using ARSoftware.Contpaqi.Comercial.Sdk.Extras.Interfaces;
using ARSoftware.Contpaqi.Comercial.Sdk.Extras.Models;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ARSoftware.Contpaqi.Comercial.Ejemplos.ViewModels.Agentes;

public class ListadoAgentesViewModel : ObservableRecipient
{
    private readonly IAgenteRepository<Agente> _agenteRepository;
    private readonly IDialogCoordinator _dialogCoordinator;
    private Agente _agenteSeleccionado;
    private string _duracionBusqueda;
    private string _filtro;

    public ListadoAgentesViewModel(IAgenteRepository<Agente> agenteRepository, IDialogCoordinator dialogCoordinator)
    {
        _agenteRepository = agenteRepository;
        _dialogCoordinator = dialogCoordinator;
        Agentes = new ObservableCollection<Agente>();
        AgentesView = CollectionViewSource.GetDefaultView(Agentes);
        AgentesView.Filter = AgentesView_Filter;

        BuscarAgentesCommand = new AsyncRelayCommand(BuscarAgentesAsync);
        CrearAgenteCommand = new AsyncRelayCommand(CrearAgenteAsync);
        EditarAgenteCommand = new AsyncRelayCommand(EditarAgenteAsync, CanEditarAgenteAsync);
    }

    public string Title => "Agentes";

    public string Filtro
    {
        get => _filtro;
        set
        {
            SetProperty(ref _filtro, value);
            AgentesView.Refresh();
            OnPropertyChanged(nameof(NumeroAgentes));
        }
    }

    public ObservableCollection<Agente> Agentes { get; }

    public ICollectionView AgentesView { get; }

    public Agente AgenteSeleccionado
    {
        get => _agenteSeleccionado;
        set
        {
            SetProperty(ref _agenteSeleccionado, value);
            RaiseGuards();
        }
    }

    public int NumeroAgentes => AgentesView.Cast<object>().Count();

    public string DuracionBusqueda
    {
        get => _duracionBusqueda;
        private set => SetProperty(ref _duracionBusqueda, value);
    }

    public IAsyncRelayCommand BuscarAgentesCommand { get; }
    public IAsyncRelayCommand CrearAgenteCommand { get; }
    public IAsyncRelayCommand EditarAgenteCommand { get; }

    private async Task BuscarAgentesAsync()
    {
        ProgressDialogController progressDialogController = await _dialogCoordinator.ShowProgressAsync(this, "Buscando", "Buscando");
        await Task.Delay(1000);

        try
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Agentes.Clear();
            foreach (Agente agente in _agenteRepository.TraerTodo())
            {
                Agentes.Add(agente);
                progressDialogController.SetMessage($"Numero de agentes: {Agentes.Count}");
                await Task.Delay(20);
            }

            stopwatch.Stop();
            DuracionBusqueda = stopwatch.Elapsed.ToString("g");
        }
        catch (Exception e)
        {
            await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
        }
        finally
        {
            await progressDialogController.CloseAsync();
            OnPropertyChanged(nameof(NumeroAgentes));
        }
    }

    private async Task CrearAgenteAsync()
    {
        try
        {
            var window = new EditarAgenteView();
            window.ViewModel.Inicializar();
            window.ShowDialog();

            await _dialogCoordinator.ShowMessageAsync(this,
                "Volver A Buscar Catalogo",
                "Para ver los cambios reflejados volver a buscar el catalogo.");
        }
        catch (Exception e)
        {
            await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
        }
    }

    private async Task EditarAgenteAsync()
    {
        try
        {
            var window = new EditarAgenteView();
            window.ViewModel.Inicializar(AgenteSeleccionado.CIDAGENTE);
            window.ShowDialog();

            await _dialogCoordinator.ShowMessageAsync(this,
                "Volver A Buscar Catalogo",
                "Para ver los cambios reflejados volver a buscar el catalogo.");
        }
        catch (Exception e)
        {
            await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
        }
    }

    private bool CanEditarAgenteAsync()
    {
        return AgenteSeleccionado != null;
    }

    private void RaiseGuards()
    {
        BuscarAgentesCommand.NotifyCanExecuteChanged();
        CrearAgenteCommand.NotifyCanExecuteChanged();
        EditarAgenteCommand.NotifyCanExecuteChanged();
    }

    private bool AgentesView_Filter(object obj)
    {
        if (obj is not Agente agente)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        return agente.Contains(Filtro);
    }
}