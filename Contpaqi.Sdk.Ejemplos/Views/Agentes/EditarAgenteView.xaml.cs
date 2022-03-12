﻿using Contpaqi.Sdk.Ejemplos.Messages;
using Contpaqi.Sdk.Ejemplos.ViewModels.Agentes;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace Contpaqi.Sdk.Ejemplos.Views.Agentes;

public partial class EditarAgenteView
{
    public EditarAgenteView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<EditarAgenteViewModel>();
        WeakReferenceMessenger.Default.Register<ViewModelVisibilityChangedMessage>(this,
            (recipient, message) =>
            {
                if (message.Sender == ViewModel && message.IsOpen == false)
                {
                    var view = (EditarAgenteView)recipient;
                    view.Close();
                }
            });
    }

    public EditarAgenteViewModel ViewModel => (EditarAgenteViewModel)DataContext;
}
