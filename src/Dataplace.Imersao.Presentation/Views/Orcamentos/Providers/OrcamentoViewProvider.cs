using Dataplace.Core.Comunications;
using Dataplace.Core.Domain.Notifications;
using Dataplace.Core.Infra.CrossCutting.EventAggregator.Contracts;
using Dataplace.Core.win.Controls.Commands;
using Dataplace.Core.win.Views.Controllers;
using Dataplace.Core.win.Views.Extensions;
using Dataplace.Core.win.Views.Providers;
using Dataplace.Core.win.Views.Providers.Configurations;
using Dataplace.Core.win.Views.Providers.Contracts;
using Dataplace.Imersao.Core.Application.Orcamentos.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.Queries;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Presentation.Views.Orcamentos;
using Dataplace.Imersao.Presentation.Views.Orcamentos.Messages;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Presentation.Views.Providers
{
    public class OrcamentoViewProvider : RegisterViewProvider<OrcamentoViewModel, OrcamentoQuery>,
        IDisposable,
        IRegisterViewProvider<OrcamentoViewModel, OrcamentoQuery>,
        ISubscriber<OrcamentoSelecionadoMessage>
    {
        #region fields

        #endregion


        #region contructors
        public OrcamentoViewProvider(IServiceProvider serviceProvider, IEventAggregator eventAggregator) : base(serviceProvider)
        {
            this.OnInit += (object sender, EventArgs e) =>
            {
                this.RegisterViewController.View.Disposed += (object _sender, EventArgs _e) =>
                {
                    this.Dispose();
                };

            };

            eventAggregator.SubscribeMe(this);
        }
        #endregion


        #region methods
        public override void Configure(RegisterViewConfigurationBuilder<OrcamentoViewModel, OrcamentoQuery> builder)
        {

            builder.HasCaption("Orçamentos");
            builder.HasSecurityId(467);

            // views
            builder.UseLayoutView<OrcamentoView>();
            builder.WithSearch(opt =>
            {
                opt.Add(new DelegateCommand("Pesquisa", (p) => this.Search(), (p) => true));
            });


            // output
            builder.WithQueryItem<OrcamentoRefreshQuery>(q =>
            {
                q.NumOrcamento = q.CurrentItem.NumOrcamento;
            });
            builder.WithQueryMove<OrcamentoMoveQuery>(q =>
            {
                
            });

            // inputs
            builder.OnInsertItem((x, c) => {

                x.CdEmpresa = dpLibrary05.mGenerico.SymPRM.cdempresa;
                x.CdFilial = dpLibrary05.mGenerico.SymPRM.cdfilial;

            });
            builder.WithRegisterCommand<AdicionarOrcamentoCommand>();
            builder.WithUpdateCommand<AtualizarOrcamentoCommand>();
            builder.WithDeleteCommand<ExcluirOrcamentoCommand>();


            // tools
            builder.WithTools(options =>
            {
                options
                    .Add(new DelegateCommand("Fechar orçamento", (p) => FecharOrcamento((OrcamentoViewModel)p), (p) => PermiteFecharOrcamento((OrcamentoViewModel)p), () => this.GetItem()))
                    .Add(new DelegateCommand("Reabrir orçamento", (p) => ReabrirOrcamento((OrcamentoViewModel)p), (p) => PermiteReabrirOrcamento((OrcamentoViewModel)p), () => this.GetItem()))
                    .Add(new DelegateCommand("Cancelar orçamento", (p) => CancelarOrcamento((OrcamentoViewModel)p), (p) => PermiteCancelarOrcamento((OrcamentoViewModel)p), () => this.GetItem()));
            });

        }





        #endregion

        #region tooles
        private bool PermiteFecharOrcamento(OrcamentoViewModel p)
        {
            return p != null && p.Situacao.ToOrcamentoStatusEnum() == OrcamentoStatusEnum.Aberto;
        }

        private void FecharOrcamento(OrcamentoViewModel p)
        {
            RegisterViewController.Main.Process(
                (e) => { }, 
                async (e) => {
                    using (var scope = this.RegisterViewController.CreateScope())
                    {
                        var _b = scope.Container.GetInstance<IMediatorHandler>();
                        var _n = scope.Container.GetInstance<INotificationHandler<DomainNotification>>();


                        var c = new FecharOrcamentoCommand(p);
                        await _b.SendCommand(c);


                        var r = Dataplace.Core.Application.Services.Results.Result.ResultFactory.New(_n.GetNotifications());
                        e.AddParameter(r);
                    }
                }, 
                (e) => {
                    var r = e.GetParameter<Dataplace.Core.Application.Contracts.Results.IResult>();
                    if (r == null)
                        return;

                    if (!r.Success)
                    {
                        ShowMessage(r);
                        e.Cancel = true;
                        return;
                    }

                    this.RegisterViewController.Refresh();

                });
        }

 
        private bool PermiteReabrirOrcamento(OrcamentoViewModel p)
        {
            return p != null && p.Situacao.ToOrcamentoStatusEnum() == OrcamentoStatusEnum.Fechado;
        }
        private void ReabrirOrcamento(OrcamentoViewModel p)
        {
            RegisterViewController.Main.Process(
               (e) => { },
               async (e) => {
                   using (var scope = this.RegisterViewController.CreateScope())
                   {
                       var _b = scope.Container.GetInstance<IMediatorHandler>();
                       var _n = scope.Container.GetInstance<INotificationHandler<DomainNotification>>();


                       var c = new ReabrirOrcamentoCommand(p);
                       await _b.SendCommand(c);


                       var r = Dataplace.Core.Application.Services.Results.Result.ResultFactory.New(_n.GetNotifications());
                       e.AddParameter(r);
                   }
               },
               (e) => {
                   var r = e.GetParameter<Dataplace.Core.Application.Contracts.Results.IResult>();
                   if (r == null)
                       return;

                   if (!r.Success)
                   {
                       ShowMessage(r);
                       e.Cancel = true;
                       return;
                   }

                   this.RegisterViewController.Refresh();

               });
         }
        


        private bool PermiteCancelarOrcamento(OrcamentoViewModel p)
        {
            return p != null && p.Situacao.ToOrcamentoStatusEnum() == OrcamentoStatusEnum.Aberto;
        }

        private void CancelarOrcamento(OrcamentoViewModel p)
        {
            RegisterViewController.Main.Process(
             (e) => { },
             async (e) => {
                 using (var scope = this.RegisterViewController.CreateScope())
                 {
                     var _b = scope.Container.GetInstance<IMediatorHandler>();
                     var _n = scope.Container.GetInstance<INotificationHandler<DomainNotification>>();


                     var c = new CancelarOrcamentoCommand(p);
                     await _b.SendCommand(c);


                     var r = Dataplace.Core.Application.Services.Results.Result.ResultFactory.New(_n.GetNotifications());
                     e.AddParameter(r);
                 }
             },
             (e) => {
                 var r = e.GetParameter<Dataplace.Core.Application.Contracts.Results.IResult>();
                 if (r == null)
                     return;

                 if (!r.Success)
                 {
                     ShowMessage(r);
                     e.Cancel = true;
                     return;
                 }

                 this.RegisterViewController.Refresh();

             });
        }





        #endregion


        #region message

        public void OnEventHandler(OrcamentoSelecionadoMessage e)
        {
            if(e != null)
                this.Load(new OrcamentoViewModel() { NumOrcamento = e.NumOrcamento });
        }

        #endregion


        #region dispose
        public bool IsDisposed { get; set; }
        public void Dispose()
        {
            IsDisposed = true;
        }

        #endregion


    }
}
