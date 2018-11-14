using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.Interface.CatGenerales;
using AppXamarinForms.Services.CatGenerales;
using AppXamarinForms.Services;
using Autofac;
using AppXamarinForms.ViewModels.CatGenerales;

namespace AppXamarinForms.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------           
            FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosAdd>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosUpdate>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosView>();
            FicContainerBuilder.RegisterType<FicVmExportarWebApi>();
            FicContainerBuilder.RegisterType<FicVmImportarWebApi>();

            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------

            FicContainerBuilder.RegisterType<FicSrvNavigationCatEdificios>().As<IFicSrvNavegationCatEdificiosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCatEdificiosList>().As<IFicSvrCatEdificiosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCatEdificiosAdd>().As<IFicSrvCatEdificiosAdd>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCatEdificiosUpdate>().As<IFicSrvCatEdificiosUpdate>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvImportarWebApi>().As<IFicSrvImportarWebApi>().SingleInstance();


            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List
       
        public FicVmCatEdificiosList FicVmCatEdificiosList
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosList>(); }
        }

        public  FicVmCatEdificiosAdd FicVmCatEdificiosAdd
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosAdd>();  }
        }

        public FicVmCatEdificiosUpdate FicVmCatEdificiosUpdate
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosUpdate>(); }
        }

        public FicVmCatEdificiosView FicVmCatEdificiosView
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosView>(); }
        }

        public FicVmExportarWebApi FicVmExportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmExportarWebApi>(); }
        }

        public FicVmImportarWebApi FicVmImportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmImportarWebApi>(); }
        }        
    }
}
